using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class SelectAllies : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Combatant", ArgumentType.Number),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SelectAllies);
        public Op Op => Op.SelectTargets;
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(Env.SelectAllies);
            p.EmitArgument(a["Combatant"]);
            p.Emit(Op);
        }
    }
}
