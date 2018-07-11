using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class RemoveBuff : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("PC", ArgumentType.PC),
            new Argument("Buff", ArgumentType.Number)
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(RemoveBuff);
        public Op Op => Op.RemoveBuff;
        public Argument[] Args => args;
        public Argument Returns => Argument.Success;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["PC"]);
            p.EmitArgument(a["Buff"]);
            p.Emit(Op);
        }
    }
}
