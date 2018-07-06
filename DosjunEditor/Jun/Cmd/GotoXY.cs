using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class GotoXY : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("X", ArgumentType.Number),
            new Argument("Y", ArgumentType.Number),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(GotoXY);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.GotoXY;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["X"]);
            p.EmitArgument(a["Y"]);
            p.Emit(Op);
        }
    }
}
