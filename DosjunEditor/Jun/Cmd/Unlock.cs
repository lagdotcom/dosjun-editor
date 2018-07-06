using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Unlock : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("X", ArgumentType.Number),
            new Argument("Y", ArgumentType.Number),
            new Argument("Face", ArgumentType.Number),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Unlock);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.Unlock;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["X"]);
            p.EmitArgument(a["Y"]);
            p.EmitArgument(a["Face"]);
            p.Emit(Op);
        }
    }
}
