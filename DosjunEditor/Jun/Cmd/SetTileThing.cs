using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class SetTileThing : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("X", ArgumentType.Number),
            new Argument("Y", ArgumentType.Number),
            new Argument("Thing", ArgumentType.Thing),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SetTileThing);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.SetTileThing;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["X"]);
            p.EmitArgument(a["Y"]);
            p.EmitArgument(a["Thing"]);
            p.Emit(Op);
        }
    }
}
