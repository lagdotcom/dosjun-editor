using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Fade : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("PaletteIndex", ArgumentType.Number),
            new Argument("Delay", ArgumentType.Number),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Fade);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.Fade;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["PaletteIndex"]);
            p.EmitArgument(a["Delay"]);
            p.Emit(Op);
        }
    }
}
