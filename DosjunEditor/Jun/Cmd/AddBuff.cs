using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class AddBuff : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("PC", ArgumentType.PC),
            new Argument("Buff", ArgumentType.Number),
            new Argument("Duration", ArgumentType.Number),
            new Argument("Arg1", ArgumentType.Number),
            new Argument("Arg2", ArgumentType.Number)
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(AddBuff);
        public Op Op => Op.AddBuff;
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["PC"]);
            p.EmitArgument(a["Buff"]);
            p.EmitArgument(a["Duration"]);
            p.EmitArgument(a["Arg1"]);
            p.EmitArgument(a["Arg2"]);
            p.Emit(Op);
        }
    }
}
