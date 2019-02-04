using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class SelectRandomTarget : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SelectRandomTarget);
        public Op Op => Op.SelectTarget;
        public Argument[] Args => new Argument[0];
        public Argument Returns => Argument.Success;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(Env.SelectRandom);
            p.Emit(Op);
        }
    }
}
