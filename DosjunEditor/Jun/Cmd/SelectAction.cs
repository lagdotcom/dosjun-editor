using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class SelectAction : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Action", ArgumentType.Number),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SelectAction);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.SelectAction;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Action"]);
            p.Emit(Op);
        }
    }
}
