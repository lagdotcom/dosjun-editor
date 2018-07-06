using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class NpcSpeak : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("NPC", ArgumentType.NPC),
            new Argument("String", ArgumentType.String),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(NpcSpeak);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.NpcSpeak;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["NPC"]);
            p.EmitArgument(a["String"]);
            p.Emit(Op);
        }
    }
}
