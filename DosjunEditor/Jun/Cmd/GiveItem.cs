using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class GiveItem : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("PC", ArgumentType.PC),
            new Argument("Item", ArgumentType.Item),
            new Argument("Quantity", ArgumentType.Number),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(GiveItem);
        public Argument[] Args => args;
        public Argument Returns => Argument.Success;
        public Op Op => Op.GiveItem;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["PC"]);
            p.EmitArgument(a["Item"]);
            p.EmitArgument(a["Quantity"]);
            p.Emit(Op);
        }
    }
}
