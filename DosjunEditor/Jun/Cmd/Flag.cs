using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Flag : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Identifier", ArgumentType.Identifier),
        };

        public bool IsGlobal => true;
        public bool IsScript => false;
        public string Name => nameof(Flag);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.NOP;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.AddVariable(Scope.Flag, a["Identifier"].Value);
        }
    }
}
