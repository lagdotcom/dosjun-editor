using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Listen : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Event", ArgumentType.Number),
            new Argument("Script", ArgumentType.Script),
            new Argument("Expiration", ArgumentType.Number),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Listen);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.Listen;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Event"]);
            p.EmitArgument(a["Script"]);
            p.EmitArgument(a["Expiration"]);
            p.Emit(Op);
        }
    }
}
