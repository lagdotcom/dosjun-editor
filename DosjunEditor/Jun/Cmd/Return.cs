using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Return : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Return);
        public Argument[] Args => new Argument[0];
        public Argument Returns => Argument.Null;
        public Op Op => Op.Return;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.Emit(Op);
        }
    }
}
