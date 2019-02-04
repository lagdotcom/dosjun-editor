using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class FilterAliveTargets : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(FilterAliveTargets);
        public Op Op => Op.FilterTargets;
        public Argument[] Args => new Argument[0];
        public Argument Returns => Argument.Null;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(Env.FilterAlive);
            p.EmitArgument(1);
            p.Emit(Op);
        }
    }
}
