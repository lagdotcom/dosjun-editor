using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Option : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("State", ArgumentType.State),
            new Argument("String", ArgumentType.String),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Option);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.Option;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["State"]);
            p.EmitArgument(a["String"]);
            p.Emit(Op);
        }
    }
}
