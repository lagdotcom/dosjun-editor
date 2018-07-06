using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Const : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Identifier", ArgumentType.Identifier),
            new Argument("Equals", ArgumentType.Equals),
            new Argument("Value", ArgumentType.Number),
        };

        public bool IsGlobal => true;
        public bool IsScript => false;
        public string Name => nameof(Const);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.NOP;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.AddConstant(a["Identifier"].Value, a["Value"].Value);
        }
    }
}
