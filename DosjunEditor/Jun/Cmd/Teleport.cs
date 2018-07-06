using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Teleport : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Zone", ArgumentType.Zone),
            new Argument("X", ArgumentType.Number),
            new Argument("Y", ArgumentType.Number),
            new Argument("Facing", ArgumentType.Number),
            new Argument("Transition", ArgumentType.Number),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Teleport);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.Teleport;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Zone"]);
            p.EmitArgument(a["X"]);
            p.EmitArgument(a["Y"]);
            p.EmitArgument(a["Facing"]);
            p.EmitArgument(a["Transition"]);
            p.Emit(Op);
        }
    }
}
