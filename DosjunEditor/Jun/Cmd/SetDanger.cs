using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class SetDanger : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Danger", ArgumentType.Number),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SetDanger);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.SetDanger;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Danger"]);
            p.Emit(Op);
        }
    }
}
