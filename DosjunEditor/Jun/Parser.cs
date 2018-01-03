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
                ["SetTileColour"] = CallSetTileColour,
                ["SetTileDescription"] = CallSetTileDescription,
                ["SetTileThing"] = CallSetTileThing,
                ["SetDanger"] = CallSetDanger,
                ["Safe"] = CallSafe,

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
            if (!InScript)
            {
                if (globalKeywordAction.ContainsKey(top)) globalKeywordAction[top]();
                else throw Error("Unexpected global keyword");
            }
            else
            {
                if (scriptKeywordAction.ContainsKey(top)) scriptKeywordAction[top]();
                else throw Error("Unexpected keyword");
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

        public Variable AddVariable(Scope scope, string name)
        {
            if (Variables.ContainsKey(name)) throw Error("Redefinition of variable");
            Variables[name] = new Variable { Scope = scope, Name = name, Index = Counts[scope] };
            Counts[scope]++;

            return Variables[name];
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
            CurrentScript.Code.Add((byte)(u & 0xFF));
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

        public void EmitPop(Variable v)
        {
            switch (v.Scope)
            {
                case Scope.Global:
                    Emit(Op.PopGlobal);
                    Emit(v.Index);
                    break;

                case Scope.Local:
                    Emit(Op.PopLocal);
                    Emit(v.Index);
                    break;

                case Scope.Temp:
                    Emit(Op.PopTemp);
                    Emit(v.Index);
                    break;

                case Scope.Const: throw Error("Cannot pop a const");
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

        public void EmitComparison(Token tok)
        {
            switch (tok.Type)
            {
                case TokenType.Equals:
                    Emit(Op.EQ);
                    return;

                case TokenType.NotEqual:
                    Emit(Op.NEQ);
                    return;

                case TokenType.LT:
                    Emit(Op.LT);
                    return;

                case TokenType.LTE:
                    Emit(Op.LTE);
                    return;

                case TokenType.GT:
                    Emit(Op.GT);
                    return;

                case TokenType.GTE:
                    Emit(Op.GTE);
                    return;

                default: throw Error("Not a comparison");
            }
        }

        public void EmitUnknown()
        {
            Emit(255);
            Emit(255);
        }

        public void AddContext(string name, int mod = 0)
        {
            Contexts.Push(new Context(name, CurrentScript.Code.Count + mod));
        }

        public void AddOffset(int mod = 0)
        {
            Contexts.Peek().Offsets.Add(CurrentScript.Code.Count + mod);
        }

        public void ResolveJump(int mod = 0)
        {
            Context con = Contexts.Peek();
            int offset = CurrentScript.Code.Count + mod;

            CurrentScript.Code[con.Start] = (byte)(offset & 0xFF);
            CurrentScript.Code[con.Start + 1] = (byte)(offset >> 8);
        }

        public void ResolveOffsets()
        {
            Context con = Contexts.Peek();
            int size = CurrentScript.Code.Count;
            for (var i = 0; i < con.Offsets.Count; i++)
            {
                int offset = con.Offsets[i];
                CurrentScript.Code[offset] = (byte)(size & 0xFF);
                CurrentScript.Code[offset + 1] = (byte)(size >> 8);
            }
        }

        public void RenewContext(int mod = 0)
        {
            Contexts.Peek().Start = CurrentScript.Code.Count + mod;
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

        private void CallText()
        {
            Consume();
            Token index = Consume();

            EmitArgument(index);
            Emit(Op.Text);
        }

        private void CallUnlock()
        {
            Consume();
            Token x = Consume();
            Token y = Consume();
            Token dir = Consume();

            EmitArgument(dir);
            EmitArgument(y);
            EmitArgument(x);
            Emit(Op.Unlock);
        }

        private void CallGiveItem()
        {
            Consume();
            Token pc = Consume();
            Token item = Consume();
            Token qty = Consume();

            EmitArgument(qty);
            EmitArgument(item);
            EmitArgument(pc);
            Emit(Op.GiveItem);
        }

        private void CallEquipItem()
        {
            Consume();
            Token pc = Consume();
            Token item = Consume();

            EmitArgument(item);
            EmitArgument(pc);
            Emit(Op.EquipItem);
        }

        private void CallSetTileDescription()
        {
            Consume();
            Token x = Consume();
            Token y = Consume();
            Token index = Consume();

            EmitArgument(index);
            EmitArgument(y);
            EmitArgument(x);
            Emit(Op.SetTileDescription);
        }

        private void CallSetTileColour()
        {
            Consume();
            Token x = Consume();
            Token y = Consume();
            Token surface = Consume();
            Token colour = Consume();

            EmitArgument(colour);
            EmitArgument(surface);
            EmitArgument(y);
            EmitArgument(x);
            Emit(Op.SetTileColour);
        }

        private void CallSetTileThing()
        {
            Consume();
            Token x = Consume();
            Token y = Consume();
            Token thing = Consume();

            EmitArgument(thing);
            EmitArgument(y);
            EmitArgument(x);
            Emit(Op.SetTileThing);
        }

        private void CallSetDanger()
        {
            Consume();
            Token danger = Consume();

            EmitArgument(danger);
            Emit(Op.SetDanger);
        }

        private void CallSafe()
        {
            Consume();

            Emit(Op.Safe);
        }

        private void If()
        {
            Consume();
            Token left = Consume();
            Token comparator = Consume();
            Token right = Consume();

            EmitArgument(right);
            EmitArgument(left);
            EmitComparison(comparator);
            Emit(Op.JumpFalse);
            AddContext("If");
            EmitUnknown();
        }

        private void ElseIf()
        {
            if (Contexts.Count == 0) throw Error("ElseIf without If");
            Consume();

            Emit(Op.Jump);
            AddOffset();
            ResolveJump(2);
            EmitUnknown();

            Token left = Consume();
            Token comparator = Consume();
            Token right = Consume();

            EmitArgument(right);
            EmitArgument(left);
            EmitComparison(comparator);
            Emit(Op.JumpFalse);
            RenewContext();
            EmitUnknown();
        }

        private void EndIf()
        {
            if (Contexts.Count == 0) throw Error("ElseIf without If");

            Consume();
            ResolveJump();
            ResolveOffsets();
            Contexts.Pop();
        }

        private void Return()
        {
            Consume();
            Emit(Op.Return);
        }

        private void EndScript()
        {
            if (Contexts.Count > 0) throw Error("Unclosed scope");

            Consume();
            Emit(Op.Return);
            InScript = false;
            CurrentScript = null;
        }

        private void Identifier()
        {
            Token targetToken = Consume();
            Variable target = Resolve(targetToken.Value);
            if (target == null)
            {
                // create a new Temp
                target = AddVariable(Scope.Temp, targetToken.Value);
            }

            if (target.Scope == Scope.Const) throw Error("Cannot assign to const");

            Token equals = Consume();
            if (equals.Type != TokenType.Assignment) throw Error("Expected assignment");

            Token destToken = Consume();
            if (destToken.Type == TokenType.Number)
            {
                EmitArgument(destToken);
            }
            else if (destToken.Type == TokenType.Identifier)
            {
                Variable dest = Resolve(destToken.Value);
                if (dest == null) throw Error("Unknown identifier");
                EmitPush(dest);
            }

            EmitPop(target);
        }
    }
}
