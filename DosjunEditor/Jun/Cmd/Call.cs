using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Call : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Script", ArgumentType.Script),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Call);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.Call;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Script"]);
            p.Emit(Op);
        }
    }
}
