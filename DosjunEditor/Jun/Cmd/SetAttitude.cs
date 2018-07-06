using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class SetAttitude : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Character", ArgumentType.Character),
            new Argument("Attitude", ArgumentType.Number),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SetAttitude);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.SetAttitude;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Character"]);
            p.EmitArgument(a["Attitude"]);
            p.Emit(Op);
        }
    }
}
