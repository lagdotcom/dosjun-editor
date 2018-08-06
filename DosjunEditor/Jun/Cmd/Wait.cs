using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Wait : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Wait);
        public Argument[] Args => new Argument[0];
        public Argument Returns => Argument.Null;
        public Op Op => Op.Wait;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.Emit(Op);
        }
    }
}
