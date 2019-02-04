using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class AIProfile : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Identifier", ArgumentType.Identifier),
        };

        public bool IsGlobal => true;
        public bool IsScript => false;
        public string Name => nameof(AIProfile);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.NOP;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            Token identifier = a["Identifier"];

            p.CurrentScript = new Jun.Script { Name = identifier.Value, Type = ScriptType.AIProfile };
            p.AddConstant(identifier.Value, (short)p.GetScriptId(identifier.Value, true));
            p.Scripts.Add(p.CurrentScript);

            p.InScript = true;
        }
    }
}
