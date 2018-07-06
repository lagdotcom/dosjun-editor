using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Global : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Identifier", ArgumentType.Identifier),
        };

        public bool IsGlobal => true;
        public bool IsScript => false;
        public string Name => nameof(Global);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.NOP;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.AddVariable(Scope.Global, a["Identifier"].Value);
        }
    }
}
