using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class GetAttitude : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("PC", ArgumentType.PC),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(GetAttitude);
        public Argument[] Args => args;
        public Argument Returns => new Argument("Attitude", ArgumentType.Number);
        public Op Op => Op.GetAttitude;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["PC"]);
            p.Emit(Op);
        }
    }
}
