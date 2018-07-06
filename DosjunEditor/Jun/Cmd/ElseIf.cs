using System.Collections.Generic;
using DosjunEditor.Jun.Ex;

namespace DosjunEditor.Jun.Cmd
{
    class ElseIf : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Expression", ArgumentType.Expression),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(ElseIf);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.NOP;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            if (p.Contexts.Count == 0)
                throw new ScopeException("ElseIf without If");

            p.Emit(Op.Jump);
            p.AddOffset();
            p.ResolveJump(2);
            p.EmitUnknown();

            p.EmitArgument(a["Expression"]);
            p.Emit(Op.JumpFalse);
            p.RenewContext();
            p.EmitUnknown();
        }
    }
}
