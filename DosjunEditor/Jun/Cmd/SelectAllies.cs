using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class SelectAllies : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SelectAllies);
        public Op Op => Op.SelectTargets;
        public Argument[] Args => new Argument[0];
        public Argument Returns => Argument.Null;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(Env.SelectAllies);
            p.Emit(Op);
        }
    }
}
