using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Music : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Music", ArgumentType.Music),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Music);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.Music;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Music"]);
            p.Emit(Op);
        }
    }
}
