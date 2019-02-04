using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class FilterTargetsByRange : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Range", ArgumentType.Expression),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(FilterTargetsByRange);
        public Op Op => Op.FilterTargets;
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(Env.FilterRange);
            p.EmitArgument(a["Range"]);
            p.Emit(Op);
        }
    }
}
