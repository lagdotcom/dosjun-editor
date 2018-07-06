using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Combat : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Combat", ArgumentType.Number),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Combat);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.Combat;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Combat"]);
            p.Emit(Op);
        }
    }
}
