using System.Collections.Generic;
using DosjunEditor.Jun.Ex;

namespace DosjunEditor.Jun.Cmd
{
    class EndWhile : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(EndWhile);
        public Argument[] Args => new Argument[0];
        public Argument Returns => Argument.Null;
        public Op Op => Op.NOP;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            Context wh;

            if (p.Contexts.Count == 0)
                throw new ScopeException("EndWhile without While");

            wh = p.Contexts.Peek();
            if (wh.Name != "While")
                throw new ScopeException("EndWhile without While");

            p.Emit(Op.Jump);
            p.Emit((short)wh.Before);

            p.ResolveJump();
            p.ResolveOffsets();
            p.Contexts.Pop();
        }
    }
}
