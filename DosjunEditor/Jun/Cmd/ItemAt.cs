using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class ItemAt : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Item", ArgumentType.Item),
            new Argument("X", ArgumentType.Number),
            new Argument("Y", ArgumentType.Number),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(ItemAt);
        public Argument[] Args => args;
        public Argument Returns => Argument.Success;
        public Op Op => Op.ItemAt;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Item"]);
            p.EmitArgument(a["X"]);
            p.EmitArgument(a["Y"]);
            p.Emit(Op);
        }
    }
}
