using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class GetBestWeaponRange : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Combatant", ArgumentType.Expression),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(GetBestWeaponRange);
        public Argument[] Args => args;
        public Argument Returns => new Argument("Range", ArgumentType.Number);
        public Op Op => Op.GetBestWeaponRange;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Combatant"]);
            p.Emit(Op);
        }
    }
}
