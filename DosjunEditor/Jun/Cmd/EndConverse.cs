using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class EndConverse : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(EndConverse);
        public Argument[] Args => new Argument[0];
        public Argument Returns => Argument.Null;
        public Op Op => Op.EndConverse;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.Emit(Op);
        }
    }
}
