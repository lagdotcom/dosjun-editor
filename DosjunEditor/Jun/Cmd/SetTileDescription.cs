using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class SetTileDescription : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("X", ArgumentType.Number),
            new Argument("Y", ArgumentType.Number),
            new Argument("Description", ArgumentType.String),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SetTileDescription);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.SetTileDescription;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["X"]);
            p.EmitArgument(a["Y"]);
            p.EmitArgument(a["Description"]);
            p.Emit(Op);
        }
    }
}
