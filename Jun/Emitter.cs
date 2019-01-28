using System;
using System.Collections.Generic;

namespace Jun
{
    public class Emitter
    {
        private const short UnknownJump = -1;

        public Emitter()
        {
            Handlers = new Dictionary<string, Action<Emitter, int, bool>>();
            Scripts = new Dictionary<string, Script>();

            CompoundOps.Initialise(Handlers);
        }

        public Dictionary<string, Action<Emitter, int, bool>> Handlers { get; private set; }
        public Dictionary<string, Script> Scripts { get; private set; }
        public Script Current { get; private set; }

        public void BeginScript(string name)
        {
            Current = new Script(name);
            Scripts[name] = Current;
        }

        public void EndScript()
        {
            Current.Write(Op.Return);
            Current = null;
        }

        public void Emit(Op o)
        {
            Current.Write(o);
        }

        public void Builtin(string name, int args, bool returnResult)
        {
            // TODO: args, returnResult
            if (Handlers.ContainsKey(name))
                Handlers[name](this, args, returnResult);
            else
                Current.Write(AsBuiltin(name));
        }

        public void Call(Var v, int args, bool returnResult)
        {
            // TODO: args, returnResult

            Literal(v.Index);
            Emit(Op.Call);
        }

        public short Jump()
        {
            Emit(Op.Jump);
            short pos = Current.Length;
            Current.Write(UnknownJump);

            return pos;
        }

        public short JumpIfFalse()
        {
            Emit(Op.JumpFalse);
            short pos = Current.Length;
            Current.Write(UnknownJump);

            return pos;
        }

        public void UpdateJump(short loc)
        {
            Current.Replace(Current.Length, loc);
        }

        public void Negate()
        {
            Emit(Op.Invert);
        }

        public void Literal(short n)
        {
            Emit(Op.PushLiteral);
            Current.Write(n);
        }

        public void Operator(string s)
        {
            Emit(AsOp(s));
        }

        public void Push(Var v)
        {
            Emit(AsPush(v.Scope));

            if (v.Scope == VarScope.Temp)
                Current.Write((byte)v.Index);
            else
                Current.Write(v.Index);
        }

        public void Push(Internal i)
        {
            Emit(Op.PushInternal);
            Current.Write((byte)i);
        }

        public void Pop(Var v)
        {
            Emit(AsPop(v.Scope));

            if (v.Scope == VarScope.Temp)
                Current.Write((byte)v.Index);
            else
                Current.Write(v.Index);
        }

        private Op AsOp(string s)
        {
            switch (s)
            {
                case "==": return Op.EQ;
                case "!=": case "<>": return Op.NEQ;
                case ">": return Op.GT;
                case ">=": return Op.GTE;
                case "<": return Op.LT;
                case "<=": return Op.LTE;
                case "+": return Op.Add;
                case "-": return Op.Sub;
                case "*": return Op.Mul;
                case "/": return Op.Div;
                case "&": return Op.And;
                case "|": return Op.Or;
                default: throw new Exception($"Invalid operator: {s}");
            }
        }

        private Op AsPush(VarScope s)
        {
            switch (s)
            {
                case VarScope.Flag: return Op.PushFlag;
                case VarScope.Global: return Op.PushGlobal;
                case VarScope.Local: return Op.PushLocal;
                case VarScope.Temp: return Op.PushTemp;
                default: throw new Exception($"Invalid var scope to push: {s}");
            }
        }

        private Op AsPop(VarScope s)
        {
            switch (s)
            {
                case VarScope.Flag: return Op.PopFlag;
                case VarScope.Global: return Op.PopGlobal;
                case VarScope.Local: return Op.PopLocal;
                case VarScope.Temp: return Op.PopTemp;
                default: throw new Exception($"Invalid var scope to pop: {s}");
            }
        }

        private Op AsBuiltin(string s)
        {
            switch (s)
            {
                case "ABLE": return Op.Able;
                case "GETBESTWEAPONRANGE": return Op.GetBestWeaponRange;
                case "INPARTY": return Op.InParty;
                case "RANDOM": return Op.Random;
                case "RETURN": return Op.Return;
                case "SELECTACTION": return Op.SelectAction;
                case "SELECTTARGET": return Op.SelectTarget;

                default: throw new Exception($"No opcode for builtin: {s}");
            }
        }
    }
}
