using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class SetTileColour : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("X", ArgumentType.Number),
            new Argument("Y", ArgumentType.Number),
            new Argument("Face", ArgumentType.Number),
            new Argument("Texture", ArgumentType.Texture),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SetTileColour);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.SetTileColour;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["X"]);
            p.EmitArgument(a["Y"]);
            p.EmitArgument(a["Face"]);
            p.EmitArgument(a["Texture"]);
            p.Emit(Op);
        }
    }
}
