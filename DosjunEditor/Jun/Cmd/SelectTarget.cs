using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class SelectTarget : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Combatant", ArgumentType.Expression),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SelectTarget);
        public Op Op => Op.SelectTarget;
        public Argument[] Args => args;
        public Argument Returns => Argument.Success;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Combatant"]);
            p.Emit(Op);
        }
    }
}
