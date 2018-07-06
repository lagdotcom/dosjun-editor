using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class ChangeState : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("State", ArgumentType.State),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(ChangeState);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.ChangeState;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["State"]);
            p.Emit(Op);
        }
    }
}
