using System;
using System.Collections.Generic;
using System.Linq;

namespace Jun
{
    public class Parser
    {
        private readonly Emitter emitter;
        private readonly Reader initialReader;
        private readonly Stack<Reader> readers;
        private readonly Dictionary<string, Var> variables;

        public Parser()
        {
            emitter = new Emitter();
            readers = new Stack<Reader>();
            variables = new Dictionary<string, Var>();
        }

        public Parser(string module, string source) : this()
        {
            initialReader = new Reader(module, source);
        }

        public void Process()
        {
            readers.Push(initialReader);
            Program();
            readers.Pop();
        }
        
        public IIncludeResolver IncludeResolver { get; set; }
        public INameResolver NameResolver { get; set; }
        public IStringResolver StringResolver { get; set; }

        public Reader Reader => readers.Peek();
        protected char Next => Reader.Look;
        public string Current { get; private set; }

        public IEnumerable<Script> DefinedScripts => emitter.Scripts.Values;

        protected void Program()
        {
            Scan();

            Includes();
            Definitions();
            Scripts();
        }

        protected void Includes()
        {
            while (Current == "INCLUDE")
                Include();
        }

        protected void Include()
        {
            Match("INCLUDE");

            GetString();
            string module = Current;

            if (IncludeResolver == null)
                throw new Exception("Tried to Include without resolver set");

            readers.Push(new Reader(module, IncludeResolver.GetSourceCode(module)));
            Program();
            readers.Pop();

            Scan();
        }

        protected void Definitions()
        {
            while (IsDefinitionType(Current))
                Definition();
        }

        protected void Definition()
        {
            string deftype = Current;

            if (!IsDefinitionType(Current))
                throw new ExpectedException("Definition type");

            GetName();
            if (deftype == Grammar.GLOBAL)
                AddVar(Current, VarScope.Global);
            else if (deftype == Grammar.LOCAL)
                AddVar(Current, VarScope.Local);
            else if (deftype == Grammar.FLAG)
                AddVar(Current, VarScope.Flag);

            Scan();
        }

        protected void Scripts()
        {
            while (Current != Grammar.EOF)
                Script();
        }

        protected void Script()
        {
            string scripttype = Current;
            string endtag = "END" + scripttype;

            if (!IsScriptType(scripttype))
                throw new ExpectedException("Script Type");

            GetName();
            string scriptname = Current;
            AddVar("$" + scriptname, VarScope.Script);
            emitter.BeginScript(scriptname);

            OptionalNameList();
            Block();

            Consume(endtag);
            emitter.EndScript();

            foreach (Var v in variables.Values.Where(v => v.Scope == VarScope.Temp).ToArray())
                variables.Remove(v.Name);
        }

        protected void OptionalNameList()
        {
            if (Next == Grammar.LP)
            {
                Consume(Grammar.LP);
                NameList();
                Consume(Grammar.RP);
            }

            Scan();
        }

        protected int NameList()
        {
            int count = 1;

            GetName();
            SkipComma();

            AddVar(Current, VarScope.Temp);

            while (Next != Grammar.RP)
            {
                GetName();
                SkipComma();

                AddVar(Current, VarScope.Temp);
                count++;
            }

            return count;
        }

        protected void Block()
        {
            while (true)
            {
                if (IsIf(Current)) IfStatement();
                else if (IsBuiltin(Current)) Builtin();
                else if (IsScript(Current)) ScriptCall();
                else if (!IsEndBlockType(Current)) Assignment();
                else break;
            }
        }

        protected void IfStatement()
        {
            short ifTag, elseTag;
            if (!IsIf(Current)) throw new ExpectedException(Grammar.IF);

            Expression();
            Fin();

            ifTag = emitter.JumpIfFalse();
            Scan();
            Block();
            if (Current == Grammar.ELSE)
            {
                elseTag = emitter.Jump();
                emitter.UpdateJump(ifTag);

                Consume(Grammar.ELSE);
                Block();
                emitter.UpdateJump(elseTag);
            }
            else emitter.UpdateJump(ifTag);

            Consume(Grammar.ENDIF);
        }

        protected void Assignment()
        {
            Var v;
            string name = Current;

            if (!variables.ContainsKey(name))
                v = AddVar(name, VarScope.Temp);
            else
                v = variables[name];

            SkipWhite();

            Consume(Grammar.EQ);

            Expression();
            emitter.Pop(v);
            Scan();
        }

        protected void Builtin()
        {
            int argcount = 0;
            string builtin = Current;
            SkipWhite();

            if (Next != Grammar.CR && Next != Grammar.LF)
                argcount = ArgumentList();

            Scan();
            emitter.Builtin(builtin, argcount, false);
        }

        protected int ArgumentList()
        {
            int count = 0;

            while (Next != Grammar.CR && Next != Grammar.LF)
            {
                Expression();
                SkipComma();

                count++;
            }

            return count;
        }

        protected void Expression()
        {
            Term();

            while (IsOp(Next))
            {
                GetOp();
                string op = Current;

                Term();
                emitter.Operator(op);
            }
        }

        protected void Term()
        {
            bool minus = false;
            bool not = false;
            SkipWhite();

            if (Next == Grammar.MINUS)
            {
                Consume(Grammar.MINUS);
                minus = true;
            }
            else if (Next == Grammar.EXCL)
            {
                Consume(Grammar.EXCL);
                not = true;
            }

            if (IsDigit(Next))
            {
                GetNum();

                short value = short.Parse(Current);
                if (minus) value = (short)-value;

                emitter.Literal(value);
            }
            else if (IsString(Next))
            {
                GetString();

                if (StringResolver == null)
                    throw new Exception("Tried to resolve a string without resolver set");

                short sindex = StringResolver.GetStringID(Current);

                emitter.Literal(sindex);
            }
            else
            {
                GetName();
                if (IsBuiltinFunction(Current)) BuiltinFunctionCall();
                else if (IsInternal(Current)) InternalTerm();
                else if (IsScript(Current)) ScriptTerm();
                else if (variables.ContainsKey(Current)) VarTerm();
                else
                {
                    if (NameResolver == null)
                        throw new Exception("Tried to resolve a name without resolver set");

                    short id = NameResolver.GetNameValue(Current);

                    emitter.Literal(id);
                }
            }

            if (not) emitter.Negate();

            SkipWhite();
        }

        protected void BuiltinFunctionCall()
        {
            string name = Current;
            int argcount = BracketedArgumentList();

            emitter.Builtin(name, argcount, true);
        }

        protected void InternalTerm()
        {
            string name = Current;
            Internal i = (Internal)Enum.Parse(typeof(Internal), name.Substring(1), true);

            emitter.Push(i);
        }

        protected void ScriptTerm()
        {
            Var v = variables[Current];
            int argcount = BracketedArgumentList();

            emitter.Call(v, argcount, true);
        }

        protected void VarTerm()
        {
            emitter.Push(variables[Current]);
        }

        protected int BracketedArgumentList()
        {
            int count = 0;

            Consume(Grammar.LP);

            while (Next != Grammar.RP)
            {
                Expression();
                SkipComma();

                count++;
            }

            Consume(Grammar.RP);

            return count;
        }

        protected void ScriptCall()
        {
            Var v = variables[Current];
            int argcount = BracketedArgumentList();

            emitter.Call(v, argcount, false);
            Scan();
        }

        protected void Scan()
        {
            while (Next == Grammar.CR || Next == Grammar.LF || IsWhite(Next))
            {
                Fin();
                SkipWhite();
            }

            if (Next == Grammar.NUL)
            {
                Current = Grammar.EOF;
                return;
            }
            else if (IsNameStart(Next)) GetName();
            else if (IsDigit(Next)) GetNum();
            else if (IsOp(Next)) GetOp();
            else if (IsString(Next)) GetString();

            SkipComma();
        }

        protected void Match(char c)
        {
            if (Next != c) throw new ExpectedException($"'{c}'");
        }

        protected void Match(string check)
        {
            if (Current != check) throw new ExpectedException($"'{check}'");
        }

        protected void Consume(char check)
        {
            Match(check);
            GetChar();
        }

        protected void Consume(string check)
        {
            Match(check);
            Scan();
        }
        
        protected void Fin()
        {
            if (Next == Grammar.CR) GetChar();
            if (Next == Grammar.LF) GetChar();
        }

        protected char GetChar() => Reader.Read();

        protected void GetName()
        {
            Current = string.Empty;
            if (!IsNameStart(Next)) throw new ExpectedException("Name");

            while (IsName(Next))
                Current += UpCase(GetChar());

            SkipWhite();
        }

        protected void GetNum()
        {
            Current = string.Empty;
            if (!IsDigit(Next)) throw new ExpectedException("Integer");

            while (IsDigit(Next))
                Current += GetChar();

            SkipWhite();
        }

        protected void GetOp()
        {
            Current = string.Empty;
            if (!IsOp(Next)) throw new ExpectedException("Operator");

            while (IsOp(Next))
                Current += GetChar();

            SkipWhite();
        }

        protected void GetString()
        {
            bool slash = false;
            char c;
            Current = string.Empty;

            if (!IsString(Next)) throw new ExpectedException("String");
            GetChar();

            while (true)
            {
                c = GetChar();
                if (slash)
                {
                    Current += EscapedChar(c);
                    slash = false;
                }
                else
                {
                    if (c == Grammar.BS) slash = true;
                    else if (c == Grammar.QUOTE) break;
                    else Current += c;
                }
            }

            SkipWhite();
        }

        protected void SkipWhite()
        {
            while (IsWhite(Next))
                GetChar();
        }

        protected void SkipComma()
        {
            SkipWhite();
            if (Next == Grammar.COMMA)
            {
                GetChar();
                SkipWhite();
            }
        }

        protected Var AddVar(string name, VarScope scope) => variables[name] = new Var { Name = name, Scope = scope, Index = (short)variables.Count(v => v.Value.Scope == scope) };
        protected bool IsScript(string name) => variables.ContainsKey(name) && variables[name].Scope == VarScope.Script;

        const int InvalidToken = -1;
        static string[] DefinitionTypes =
        {
            Grammar.GLOBAL,
            Grammar.LOCAL,
            Grammar.FLAG,
        };
        static string[] ScriptTypes =
        {
            "SCRIPT",
            "STATE",
            "AIPROFILE",
        };
        static string[] EndScriptTypes = ScriptTypes.Select(t => "END" + t).ToArray();
        static string[] EndBlockTypes = EndScriptTypes.Concat(new string[] {
            Grammar.ELSE,
            Grammar.ENDIF,
        }).ToArray();
        static string[] Builtins =
        {
            "CHOOSEPCNAME",
            "CHOOSEPCPORTRAIT",
            "CHOOSEPCPRONOUNS",
            "COMBAT",
            "CONVERSE",
            "EQUIPITEM",
            "ENDCONVERSE",
            "FILTERALIVETARGETS",
            "FILTERHPBELOWTARGETS",
            "FILTERTARGETSBYRANGE",
            "GIVEITEM",
            "GOTOXY",
            "JOINPARTY",
            "LISTEN",
            "MUSIC",
            "NPCSPEAK",
            "OPTION",
            "PCSPEAK",
            "REFRESH",
            "RETURN",
            "SELECTACTION",
            "SELECTALL",
            "SELECTALLIES",
            "SELECTENEMIES",
            "SELECTRANDOMTARGET",
            "SELECTTARGET",
            "SHOWIMAGE",
            "TELEPORT",
            "TEXT",
            "WAIT",
        };
        static string[] BuiltinFunctions =
        {
            "ABLE",
            "GETBESTWEAPONRANGE",
            "INPARTY",
            "RANDOM",
            "SELECTRANDOMTARGET",
        };
        static string[] InternalNames = Enum.GetNames(typeof(Internal)).Select(n => "@" + n.ToUpper()).ToArray();

        static bool IsAlpha(char c) => char.IsLetter(c);
        static bool IsDigit(char c) => char.IsDigit(c);
        static bool IsNameStart(char c) => IsAlpha(c) || c == Grammar.AT || c == Grammar.DOLLAR;
        static bool IsName(char c) => IsNameStart(c) || IsDigit(c) || c == Grammar.UNDERSCORE;
        static bool IsOp(char c) => Grammar.Operators.Contains(c);
        static bool IsString(char c) => c == Grammar.QUOTE;
        static bool IsWhite(char c) => Grammar.WhiteSpace.Contains(c);

        static bool IsBuiltin(string s) => Builtins.Contains(s);
        static bool IsBuiltinFunction(string s) => BuiltinFunctions.Contains(s);
        static bool IsDefinitionType(string s) => DefinitionTypes.Contains(s);
        static bool IsEndBlockType(string s) => EndBlockTypes.Contains(s);
        static bool IsEndScriptType(string s) => EndScriptTypes.Contains(s);
        static bool IsIf(string s) => s == Grammar.IF;
        static bool IsInternal(string s) => InternalNames.Contains(s);
        static bool IsScriptType(string s) => ScriptTypes.Contains(s);

        static char EscapedChar(char c)
        {
            switch (c)
            {
                case 't': return Grammar.HTAB;
                case 'r': return Grammar.CR;
                case 'n': return Grammar.LF;
                default: return c;
            }
        }
        static char UpCase(char c) => char.ToUpper(c);
    }
}
