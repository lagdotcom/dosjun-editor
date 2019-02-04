using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Able : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Combatant", ArgumentType.Expression),
            new Argument("Ability", ArgumentType.Number),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Able);
        public Op Op => Op.Able;
        public Argument[] Args => args;
        public Argument Returns => Argument.Success;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Combatant"]);
            p.EmitArgument(a["Ability"]);
            p.Emit(Op);
        }
    }
}
