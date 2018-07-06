using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Safe : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Safe);
        public Argument[] Args => new Argument[0];
        public Argument Returns => Argument.Null;
        public Op Op => Op.Safe;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.Emit(Op);
        }
    }
}
