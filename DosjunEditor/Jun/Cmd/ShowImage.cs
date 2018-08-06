using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class ShowImage : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Image", ArgumentType.Graphic),
            new Argument("X", ArgumentType.Number),
            new Argument("Y", ArgumentType.Number),
            new Argument("Index", ArgumentType.Number),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(ShowImage);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.ShowImage;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Image"]);
            p.EmitArgument(a["X"]);
            p.EmitArgument(a["Y"]);
            p.EmitArgument(a["Index"]);
            p.Emit(Op);
        }
    }
}
