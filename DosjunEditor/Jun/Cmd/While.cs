using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class While : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Expression", ArgumentType.Expression),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(While);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.NOP;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            int offset = p.CurrentScript.Code.Count;

            p.EmitArgument(a["Expression"]);
            p.Emit(Op.JumpFalse);
            p.AddContext(Name);
            p.Contexts.Peek().Before = offset;
            p.EmitUnknown();
        }
    }
}
