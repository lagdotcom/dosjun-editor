using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class AddItem : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Item", ArgumentType.Item),
            new Argument("Quantity", ArgumentType.Number),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(AddItem);
        public Argument[] Args => args;
        public Argument Returns => Argument.Success;
        public Op Op => Op.AddItem;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Item"]);
            p.EmitArgument(a["Quantity"]);
            p.Emit(Op);
        }
    }
}
