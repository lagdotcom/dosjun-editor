using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class GetPCInSlot : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Slot", ArgumentType.Number)
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(GetPCInSlot);
        public Op Op => Op.GetPCInSlot;
        public Argument[] Args => args;
        public Argument Returns => new Argument("PC", ArgumentType.PC);

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Slot"]);
            p.Emit(Op);
        }
    }
}
