using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class SelectAll : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SelectAll);
        public Op Op => Op.SelectTargets;
        public Argument[] Args => new Argument[0];
        public Argument Returns => Argument.Null;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(Env.SelectAll);
            p.EmitArgument(0);
            p.Emit(Op);
        }
    }
}
