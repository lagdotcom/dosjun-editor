using System;
using System.Collections.Generic;

namespace DosjunEditor.Jun
{
    public class Parser
    {
        public const int MaxLocals = 20;
        public const int MaxTemps = 20;

        private Dictionary<string, Action> globalKeywordAction;
        private Dictionary<string, Action> scriptKeywordAction;
        private Dictionary<TokenType, Op> comparators;
        private Dictionary<TokenType, int> precedence;

        public Parser(DosjunEditor.Context ctx)
        {
            globalKeywordAction = new Dictionary<string, Action>
            {
                ["Const"] = DefineConst,
                ["Global"] = DefineGlobal,
                ["Local"] = DefineLocal,
                ["Script"] = DefineScript,
                ["State"] = DefineState,
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
                ["RemoveWall"] = CallRemoveWall,
                ["Refresh"] = CallRefresh,
                ["AddItem"] = CallAddItem,
                ["Music"] = CallMusic,
                ["Converse"] = CallConverse,
                ["EndConverse"] = CallEndConverse,
                ["NpcAction"] = CallNpcAction,
                ["NpcSpeak"] = CallNpcSpeak,
                ["Option"] = CallOption,
                ["PcAction"] = CallPcAction,
                ["ChangeState"] = CallChangeState,
                ["Call"] = CallCall,

                ["If"] = If,
                ["Else"] = Else,
                ["ElseIf"] = ElseIf,
                ["EndIf"] = EndIf,

                ["Return"] = Return,
                ["EndScript"] = EndScript,
                ["EndState"] = EndState,
            };

            comparators = new Dictionary<TokenType, Op>
            {
                [TokenType.Add] = Op.Add,
                [TokenType.And] = Op.And,
                [TokenType.Divide] = Op.Div,
                [TokenType.Equals] = Op.EQ,
                [TokenType.GT] = Op.GT,
                [TokenType.GTE] = Op.GTE,
                [TokenType.LT] = Op.LT,
                [TokenType.LTE] = Op.LTE,
                [TokenType.Multiply] = Op.Mul,
                [TokenType.NotEqual] = Op.NEQ,
                [TokenType.Or] = Op.Or,
                [TokenType.Subtract] = Op.Sub,
            };

            // these precedences are taken from C
            precedence = new Dictionary<TokenType, int>
            {
                [TokenType.Divide] = 3,
                [TokenType.Multiply] = 3,
                [TokenType.Add] = 4,
                [TokenType.Subtract] = 4,
                [TokenType.GT] = 6,
                [TokenType.GTE] = 6,
                [TokenType.LT] = 6,
                [TokenType.LTE] = 6,
                [TokenType.Equals] = 7,
                [TokenType.NotEqual] = 7,
                [TokenType.And] = 8,
                [TokenType.Or] = 10,
                [TokenType.LeftParens] = 100,
            };

            Constants = new Dictionary<string, ushort>();
            Context = ctx;
            Contexts = new Stack<Context>();
            Counts = new Dictionary<Scope, byte>();
            Scripts = new List<Script>();
            Strings = new List<string>();
            TemporaryScripts = new List<CompiledScript>();
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
                Token tok = Peek();
                switch (tok.Type)
                {
                    case TokenType.Keyword:
                        Keyword();
                        break;

                    case TokenType.Identifier:
                        Identifier();
                        break;

                    // Ignore EOL tokens entirely
                    case TokenType.EOL:
                        Consume();
                        break;

                    default:
                        throw Error($"Cannot start line with {tok}");
                }
            }
        }

        public void Keyword()
        {
            string top = Peek().Value;
            if (!InScript)
            {
                if (globalKeywordAction.ContainsKey(top)) globalKeywordAction[top]();
                else throw Error($"Unexpected global keyword: {top}");
            }
            else
            {
                if (scriptKeywordAction.ContainsKey(top)) scriptKeywordAction[top]();
                else throw Error($"Unexpected keyword: {top}");
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
            Token tok = Consume();
            if (tok.Type != expected) throw Error($"Wanted {expected}, got {tok.Type}");

            return tok;
        }

        private Token Expression()
        {
            List<Token> tokens = new List<Token>();
            Token next;
            bool isEnd = false;
            bool lastWasOperator = false;

            // grab tokens until we have a whole expression
            while (!isEnd)
            {
                next = Peek();
                
                switch (next.Type)
                {
                    case TokenType.EOL:
                    case TokenType.Separator:
                        if (lastWasOperator) throw Error("Ended expression after an operator");
                        Consume();
                        isEnd = true;
                        break;

                    case TokenType.Assignment: throw Error("Can't assign in an expression");

                    case TokenType.Add:
                    case TokenType.And:
                    case TokenType.Divide:
                    case TokenType.Equals:
                    case TokenType.GT:
                    case TokenType.GTE:
                    case TokenType.LT:
                    case TokenType.LTE:
                    case TokenType.Multiply:
                    case TokenType.NotEqual:
                    case TokenType.Or:
                    case TokenType.Subtract:
                        lastWasOperator = true;
                        tokens.Add(next);
                        Consume();
                        break;

                    default:
                        lastWasOperator = false;
                        tokens.Add(next);
                        Consume();
                        break;
                }
            }

            if (tokens.Count == 1) return tokens[0];
            return new ExpressionToken(tokens);
        }

        public void AddConstant(string name, ushort value)
        {
            if (Constants.ContainsKey(name)) throw Error($"Redefinition of constant: {name}");
            Constants[name] = value;
            AddVariable(Scope.Const, name);
        }

        public void AddConstant(string name, string value)
        {
            AddConstant(name, ushort.Parse(value));
        }

        public int ScopeLimit(Scope scope)
        {
            switch (scope)
            {
                case Scope.Global: return Context.Djn.Campaign.NumGlobals;
                case Scope.Local: return MaxLocals;
                case Scope.Temp: return MaxTemps;
            }

            // there is no real maximum for Consts
            return int.MaxValue;
        }

        public Variable AddVariable(Scope scope, string name)
        {
            if (Variables.ContainsKey(name)) throw Error($"Redefinition of {scope} variable: {name}");
            Variables[name] = new Variable { Scope = scope, Name = name, Index = Counts[scope] };
            Counts[scope]++;

            if (Counts[scope] > ScopeLimit(scope)) throw Error($"Too many {scope} variables");

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
                    if (var == null) throw Error($"Unknown identifier: {tok.Value}");
                    EmitPush(var);
                    break;

                case TokenType.Internal:
                    if (!Env.Internals.ContainsKey(tok.Value)) throw Error($"Unknown internal: {tok.Value}");
                    Emit(Op.PushInternal);
                    Emit((byte)Env.Internals[tok.Value]);
                    break;

                case TokenType.Expression:
                    EmitExpression((tok as ExpressionToken).Tokens);
                    break;

                default: throw Error($"Cannot emit {tok}");
            }
        }

        public void EmitOperator(Token tok)
        {
            if (comparators.ContainsKey(tok.Type))
            {
                Emit(comparators[tok.Type]);
                return;
            }

            throw Error($"Not a comparison: {tok}");
        }
        
        public void EmitExpression(IEnumerable<Token> tokens)
        {
            Stack<Token> operators = new Stack<Token>();
            int topPrecedence;

            // convert Infix to Postfix
            foreach (Token tok in tokens)
            {
                switch (tok.Type)
                {
                    case TokenType.LeftParens:
                        operators.Push(tok);
                        break;

                    case TokenType.RightParens:
                        while (true)
                        {
                            if (operators.Count == 0)
                                throw Error("Right parenthesis without left");

                            Token important = operators.Pop();
                            if (important.Type == TokenType.LeftParens) break;
                            else EmitOperator(important);
                        }
                        break;

                    case TokenType.Add:
                    case TokenType.And:
                    case TokenType.Divide:
                    case TokenType.Equals:
                    case TokenType.GT:
                    case TokenType.GTE:
                    case TokenType.LT:
                    case TokenType.LTE:
                    case TokenType.Multiply:
                    case TokenType.NotEqual:
                    case TokenType.Or:
                    case TokenType.Subtract:
                        topPrecedence = operators.Count > 0 ? precedence[operators.Peek().Type] : 100;
                        if (topPrecedence < precedence[tok.Type])
                        {
                            Token important = operators.Pop();
                            EmitOperator(important);
                        }

                        operators.Push(tok);
                        break;

                    default:
                        EmitArgument(tok);
                        break;
                }
            }

            while (operators.Count > 0)
                EmitOperator(operators.Pop());
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

        public bool ScriptExists(Token script, ScriptType type = ScriptType.Any)
        {
            Script sc = Scripts.Find(s => s.Name == script.Value);

            if (type != ScriptType.Any) return sc?.Type == type;

            return sc != null;
        }

        public void RenewContext(int mod = 0, string name = null)
        {
            Context con = Contexts.Peek();
            con.Start = CurrentScript.Code.Count + mod;
            if (name != null) con.Name = name;
        }

        public Dictionary<string, ushort> Constants { get; private set; }
        public Dictionary<Scope, byte> Counts { get; private set; }

        public Stack<Context> Contexts { get; private set; }
        public List<Script> Scripts { get; private set; }
        public List<string> Strings { get; private set; }
        public List<CompiledScript> TemporaryScripts { get; }
        public Dictionary<string, Variable> Variables { get; private set; }

        public IList<Token> Tokens { get; private set; }
        public int Index { get; private set; }
        public bool InScript { get; private set; }
        public Script CurrentScript { get; private set; }
        public DosjunEditor.Context Context { get; private set; }

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

            CurrentScript = new Script { Name = identifier.Value, Type = ScriptType.Script };
            AddConstant(identifier.Value, GetScriptId(identifier.Value));
            Scripts.Add(CurrentScript);

            InScript = true;
        }

        private void DefineState()
        {
            Consume();
            Token identifier = Consume(TokenType.Identifier);

            CurrentScript = new Script { Name = identifier.Value, Type = ScriptType.State };
            AddConstant(identifier.Value, GetScriptId(identifier.Value));
            Scripts.Add(CurrentScript);

            InScript = true;
        }

        private ushort GetScriptId(string name)
        {
            CompiledScript scr = Context.Djn.FindByName<CompiledScript>(name);

            if (scr == null)
            {
                scr = new CompiledScript();
                scr.Resource.Name = name;
                scr.Resource.OnlyDesign = true;
                Context.Djn.Add(scr);

                TemporaryScripts.Add(scr);
            }

            return scr.Resource.ID;
        }

        private void CallCombat()
        {
            Consume();
            Token combat = Expression();

            EmitArgument(combat);
            Emit(Op.Combat);
        }

        private void CallPcSpeak()
        {
            Consume();
            Token speaker = Expression();
            Token index = Expression();

            EmitArgument(speaker);
            EmitArgument(index);
            Emit(Op.PcSpeak);
        }

        private void CallText()
        {
            Consume();
            Token index = Expression();

            EmitArgument(index);
            Emit(Op.Text);
        }

        private void CallUnlock()
        {
            Consume();
            Token x = Expression();
            Token y = Expression();
            Token dir = Expression();

            EmitArgument(x);
            EmitArgument(y);
            EmitArgument(dir);
            Emit(Op.Unlock);
        }

        private void CallGiveItem()
        {
            Consume();
            Token pc = Expression();
            Token item = Expression();
            Token qty = Expression();

            EmitArgument(pc);
            EmitArgument(item);
            EmitArgument(qty);
            Emit(Op.GiveItem);
        }

        private void CallEquipItem()
        {
            Consume();
            Token pc = Expression();
            Token item = Expression();

            EmitArgument(pc);
            EmitArgument(item);
            Emit(Op.EquipItem);
        }

        private void CallAddItem()
        {
            Consume();
            Token item = Expression();
            Token qty = Expression();

            EmitArgument(item);
            EmitArgument(qty);
            Emit(Op.AddItem);
        }

        private void CallSetTileDescription()
        {
            Consume();
            Token x = Expression();
            Token y = Expression();
            Token index = Expression();

            EmitArgument(x);
            EmitArgument(y);
            EmitArgument(index);
            Emit(Op.SetTileDescription);
        }

        private void CallSetTileColour()
        {
            Consume();
            Token x = Expression();
            Token y = Expression();
            Token surface = Expression();
            Token colour = Expression();

            EmitArgument(x);
            EmitArgument(y);
            EmitArgument(surface);
            EmitArgument(colour);
            Emit(Op.SetTileColour);
        }

        private void CallSetTileThing()
        {
            Consume();
            Token x = Expression();
            Token y = Expression();
            Token thing = Expression();

            EmitArgument(x);
            EmitArgument(y);
            EmitArgument(thing);
            Emit(Op.SetTileThing);
        }

        private void CallSetDanger()
        {
            Consume();
            Token danger = Expression();

            EmitArgument(danger);
            Emit(Op.SetDanger);
        }

        private void CallSafe()
        {
            Consume();

            Emit(Op.Safe);
        }

        private void CallRemoveWall()
        {
            Consume();
            Token x = Expression();
            Token y = Expression();
            Token dir = Expression();

            EmitArgument(x);
            EmitArgument(y);
            EmitArgument(dir);
            Emit(Op.RemoveWall);
        }

        private void CallRefresh()
        {
            Consume();

            Emit(Op.Refresh);
        }

        private void CallMusic()
        {
            Consume();
            Token index = Expression();

            EmitArgument(index);
            Emit(Op.Music);
        }

        private void CallConverse()
        {
            Consume();
            Token npc = Expression();
            Token state = Expression();

            if (!ScriptExists(state, ScriptType.State)) throw Error($"Unknown state: {state}");

            EmitArgument(npc);
            EmitArgument(state);
            Emit(Op.Converse);
        }

        private void CallPcAction()
        {
            Consume();
            Token speaker = Expression();
            Token index = Expression();

            EmitArgument(speaker);
            EmitArgument(index);
            Emit(Op.PcAction);
        }

        private void CallOption()
        {
            Consume();
            Token state = Expression();
            Token index = Expression();

            EmitArgument(state);
            EmitArgument(index);
            Emit(Op.Option);
        }

        private void CallNpcSpeak()
        {
            Consume();
            Token speaker = Expression();
            Token index = Expression();

            EmitArgument(speaker);
            EmitArgument(index);
            Emit(Op.NpcSpeak);
        }

        private void CallNpcAction()
        {
            Consume();
            Token speaker = Expression();
            Token index = Expression();

            EmitArgument(speaker);
            EmitArgument(index);
            Emit(Op.NpcAction);
        }

        private void CallEndConverse()
        {
            Consume();

            Emit(Op.EndConverse);
        }

        private void CallChangeState()
        {
            Consume();
            Token state = Expression();

            if (!ScriptExists(state, ScriptType.State)) throw Error($"Unknown state: {state}");

            EmitArgument(state);
            Emit(Op.ChangeState);
        }

        private void CallCall()
        {
            Consume();
            Token script = Expression();

            if (!ScriptExists(script)) throw Error($"Unknown script: {script}");

            EmitArgument(script);
            Emit(Op.Call);
        }

        private void If()
        {
            Consume();
            Token expression = Expression();

            EmitArgument(expression);
            Emit(Op.JumpFalse);
            AddContext("If");
            EmitUnknown();
        }

        private void Else()
        {
            if (Contexts.Count == 0) throw Error("Else without If");
            Consume();

            Emit(Op.Jump);
            ResolveJump(2);
            RenewContext(0, "Else");
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

            Token expression = Expression();

            EmitArgument(expression);
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
            if (Contexts.Count > 0) throw Error($"Unclosed scope: {Contexts.Peek().Name}");
            if (CurrentScript.Type != ScriptType.Script) throw Error($"Wrong sub type: {CurrentScript.Type}, expected {ScriptType.Script}");

            Consume();
            Emit(Op.Return);
            InScript = false;
            CurrentScript = null;
        }

        private void EndState()
        {
            if (Contexts.Count > 0) throw Error($"Unclosed scope: {Contexts.Peek().Name}");
            if (CurrentScript.Type != ScriptType.State) throw Error($"Wrong sub type: {CurrentScript.Type}, expected {ScriptType.State}");

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

            Token equals = Consume(TokenType.Assignment);
            Token destToken = Expression();
            EmitArgument(destToken);
            EmitPop(target);
        }
    }
}
