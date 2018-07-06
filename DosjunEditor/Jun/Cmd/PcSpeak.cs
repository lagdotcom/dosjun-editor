using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class PcSpeak : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("PC", ArgumentType.PC),
            new Argument("String", ArgumentType.String),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(PcSpeak);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.PcSpeak;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["PC"]);
            p.EmitArgument(a["String"]);
            p.Emit(Op);
        }
    }
}
