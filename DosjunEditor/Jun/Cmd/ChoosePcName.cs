using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class ChoosePcName : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("PC", ArgumentType.PC),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(ChoosePcName);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.ChoosePcName;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["PC"]);
            p.Emit(Op);
        }
    }
}
