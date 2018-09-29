using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class HasItem : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Item", ArgumentType.Item),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(HasItem);
        public Argument[] Args => args;
        public Argument Returns => Argument.Success;
        public Op Op => Op.HasItem;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["Item"]);
            p.Emit(Op);
        }
    }
}
