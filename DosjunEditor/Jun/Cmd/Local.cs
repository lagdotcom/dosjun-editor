using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Local : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Identifier", ArgumentType.Identifier),
        };

        public bool IsGlobal => true;
        public bool IsScript => false;
        public string Name => nameof(Local);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.NOP;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.AddVariable(Scope.Local, a["Identifier"].Value);
        }
    }
}
