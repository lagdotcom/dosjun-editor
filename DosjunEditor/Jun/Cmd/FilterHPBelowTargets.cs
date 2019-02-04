using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class FilterHPBelowTargets : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Percentage", ArgumentType.Expression),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(FilterHPBelowTargets);
        public Op Op => Op.FilterTargets;
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(Env.FilterHPBelow);
            p.EmitArgument(a["Percentage"]);
            p.Emit(Op);
        }
    }
}
