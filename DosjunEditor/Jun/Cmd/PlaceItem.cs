using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class PlaceItem : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Item", ArgumentType.Item),
            new Argument("X", ArgumentType.Number),
            new Argument("Y", ArgumentType.Number),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(PlaceItem);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.PlaceItem;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Item"]);
            p.EmitArgument(a["X"]);
            p.EmitArgument(a["Y"]);
            p.Emit(Op);
        }
    }
}
