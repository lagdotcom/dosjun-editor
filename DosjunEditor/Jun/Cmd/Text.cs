using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Text : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("String", ArgumentType.String),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Text);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.Text;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["String"]);
            p.Emit(Op);
        }
    }
}
