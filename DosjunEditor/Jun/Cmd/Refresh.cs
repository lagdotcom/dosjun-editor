using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Refresh : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Refresh);
        public Argument[] Args => new Argument[0];
        public Argument Returns => Argument.Null;
        public Op Op => Op.Refresh;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.Emit(Op);
        }
    }
}
