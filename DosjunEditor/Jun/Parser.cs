using System;
using System.Collections.Generic;

namespace DosjunEditor.Jun
{
    public class Parser
    {
        private Dictionary<string, Action> globalKeywordAction;
        private Dictionary<string, Action> scriptKeywordAction;

        public Parser()
        {
            globalKeywordAction = new Dictionary<string, Action>
            {
                ["Const"] = DefineConst,
                ["Global"] = DefineGlobal,
                ["Local"] = DefineLocal,
                ["Script"] = DefineScript
            };

            scriptKeywordAction = new Dictionary<string, Action>
            {
                ["Combat"] = CallCombat,
                ["PcSpeak"] = CallPcSpeak,
                ["Text"] = CallText,
                ["Unlock"] = CallUnlock,
                ["GiveItem"] = CallGiveItem,
                ["EquipItem"] = CallEquipItem,
                ["SetTileDescription"] = CallSetTileDescription,
                ["SetTileColour"] = CallSetTileColour,

                ["If"] = If,
                ["ElseIf"] = ElseIf,
                ["EndIf"] = EndIf,

                ["Return"] = Return,
                ["EndScript"] = EndScript
            };

            Constants = new Dictionary<string, ushort>();
            Contexts = new Stack<Context>();
            Counts = new Dictionary<Scope, byte>();
            Scripts = new List<Script>();
            Strings = new List<string>();
            Variables = new Dictionary<string, Variable>();
        }

        public void Parse(IList<Token> tokens)
        {
            Constants.Clear();
            Contexts.Clear();
            Variables.Clear();
            Scripts.Clear();
            Strings.Clear();

            Counts[Scope.Global] = 0;
            Counts[Scope.Local] = 0;
            Counts[Scope.Temp] = 0;
            Counts[Scope.Const] = 0;

            InScript = false;
            Tokens = tokens;
            Index = 0;

            while (Index < Tokens.Count)
            {
                switch (Peek().Type)
                {
                    case TokenType.Keyword:
                        Keyword();
                        break;

                    case TokenType.Identifier:
                        Identifier();
                        break;

                    default:
                        throw Error("Invalid starting token");
                }
            }
        }

        public void Keyword()
        {
            string top = Peek().Value;
            if (InScript)
            {
                if (globalKeywordAction.ContainsKey(top)) globalKeywordAction[top]();
                throw Error("Unexpected global keyword");
            }
            else
            {
                if (scriptKeywordAction.ContainsKey(top)) scriptKeywordAction[top]();
                throw Error("Unexpected keyword");
            }
        }

        public Exception Error(string message)
        {
            return new CodeException($"{message}");
        }

        public Token Peek()
        {
            return Tokens[Index];
        }

        public Token Consume()
        {
            return Tokens[Index++];
        }
        public Token Consume(TokenType expected)
        {
            Token tok = Tokens[Index++];
            if (tok.Type != expected) throw Error("Unexpected keyword type");

            return tok;
        }

        public void AddConstant(string name, ushort value)
        {
            if (Constants.ContainsKey(name)) throw Error("Redefinition of constant");
            Constants[name] = value;
            AddVariable(Scope.Const, name);
        }

        public void AddConstant(string name, string value)
        {
            AddConstant(name, ushort.Parse(value));
        }

        public void AddVariable(Scope scope, string name)
        {
            if (Variables.ContainsKey(name)) throw Error("Redefinition of variable");
            Variables[name] = new Variable { Scope = scope, Name = name, Index = Counts[scope] };
            Counts[scope]++;
        }

        public Variable Resolve(string name)
        {
            if (Variables.ContainsKey(name)) return Variables[name];
            return null;
        }

        public ushort SaveString(string value)
        {
            Strings.Add(value);
            return (ushort)(Strings.Count - 1);
        }

        public void Emit(Op op)
        {
            CurrentScript.Code.Add((byte)op);
        }

        public void Emit(byte b)
        {
            CurrentScript.Code.Add(b);
        }

        public void Emit(ushort u)
        {
            CurrentScript.Code.Add((byte)(u * 0xFF));
            CurrentScript.Code.Add((byte)(u >> 8));
        }

        public void EmitPush(Variable v)
        {
            switch (v.Scope)
            {
                case Scope.Global:
                    Emit(Op.PushGlobal);
                    Emit(v.Index);
                    break;

                case Scope.Local:
                    Emit(Op.PushLocal);
                    Emit(v.Index);
                    break;

                case Scope.Temp:
                    Emit(Op.PushTemp);
                    Emit(v.Index);
                    break;

                case Scope.Const:
                    Emit(Op.PushLiteral);
                    Emit(Constants[v.Name]);
                    break;
            }
        }

        public void EmitArgument(Token tok)
        {
            switch (tok.Type)
            {
                case TokenType.Number:
                    Emit(Op.PushLiteral);
                    Emit(ushort.Parse(tok.Value));
                    break;

                case TokenType.String:
                    ushort index = SaveString(tok.Value);
                    Emit(Op.PushLiteral);
                    Emit(index);
                    break;

                case TokenType.Identifier:
                    Variable var = Resolve(tok.Value);
                    if (var == null) throw Error("Unknown identifier");
                    EmitPush(var);
                    break;

                case TokenType.Internal:
                    if (!Env.Internals.ContainsKey(tok.Value)) throw Error("Unknown internal");
                    Emit(Op.PushInternal);
                    Emit((byte)Env.Internals[tok.Value]);
                    break;

                default: throw Error("Cannot emit");
            }
        }

        public Dictionary<string, ushort> Constants { get; private set; }
        public Dictionary<Scope, byte> Counts { get; private set; }

        public Stack<Context> Contexts { get; private set; }
        public List<Script> Scripts { get; private set; }
        public List<string> Strings { get; private set; }
        public Dictionary<string, Variable> Variables { get; private set; }

        public IList<Token> Tokens { get; private set; }
        public int Index { get; private set; }
        public bool InScript { get; private set; }
        public Script CurrentScript { get; private set; }

        private void DefineConst()
        {
            Consume();
            Token identifier = Consume(TokenType.Identifier);
            Consume(TokenType.Assignment);
            Token value = Consume(TokenType.Number);

            AddConstant(identifier.Value, value.Value);
        }

        private void DefineGlobal()
        {
            Consume();
            Token identifier = Consume(TokenType.Identifier);

            AddVariable(Scope.Global, identifier.Value);
        }

        private void DefineLocal()
        {
            Consume();
            Token identifier = Consume(TokenType.Identifier);

            AddVariable(Scope.Local, identifier.Value);
        }

        private void DefineScript()
        {
            Consume();
            Token identifier = Consume(TokenType.Identifier);

            CurrentScript = new Script { Name = identifier.Value };
            AddConstant(identifier.Value, (ushort)Scripts.Count);
            Scripts.Add(CurrentScript);

            InScript = true;
        }

        private void CallCombat()
        {
            Consume();
            Token combat = Consume();

            EmitArgument(combat);
            Emit(Op.Combat);
        }

        private void CallPcSpeak()
        {
            Consume();
            Token speaker = Consume();
            Token index = Consume();

            EmitArgument(index);
            EmitArgument(speaker);
            Emit(Op.PcSpeak);
        }
    }
}
