using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class EquipItem : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("PC", ArgumentType.PC),
            new Argument("Item", ArgumentType.Item),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(EquipItem);
        public Argument[] Args => args;
        public Argument Returns => Argument.Success;
        public Op Op => Op.EquipItem;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["PC"]);
            p.EmitArgument(a["Item"]);
            p.Emit(Op);
        }
    }
}
