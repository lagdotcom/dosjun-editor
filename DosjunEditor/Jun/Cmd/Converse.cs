using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Converse : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("NPC", ArgumentType.NPC),
            new Argument("State", ArgumentType.State),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Converse);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.Converse;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["NPC"]);
            p.EmitArgument(a["State"]);
            p.Emit(Op);
        }
    }
}
