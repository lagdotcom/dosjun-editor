using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class SelectEnemies : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SelectEnemies);
        public Op Op => Op.SelectTargets;
        public Argument[] Args => new Argument[0];
        public Argument Returns => Argument.Null;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(Env.SelectEnemies);
            p.Emit(Op);
        }
    }
}
