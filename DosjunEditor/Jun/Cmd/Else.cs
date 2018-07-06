using System.Collections.Generic;
using DosjunEditor.Jun.Ex;

namespace DosjunEditor.Jun.Cmd
{
    class Else : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Else);
        public Argument[] Args => new Argument[0];
        public Argument Returns => Argument.Null;
        public Op Op => Op.NOP;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            if (p.Contexts.Count == 0)
                throw new ScopeException("Else without If");

            p.Emit(Op.Jump);
            p.ResolveJump(2);
            p.RenewContext(0, Name);
            p.EmitUnknown();
        }
    }
}
