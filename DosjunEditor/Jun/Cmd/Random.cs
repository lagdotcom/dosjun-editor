using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Random : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Maximum", ArgumentType.Expression),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Random);
        public Op Op => Op.Random;
        public Argument[] Args => args;
        public Argument Returns => new Argument("Result", ArgumentType.Number);

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Maximum"]);
            p.Emit(Op);
        }
    }
}
