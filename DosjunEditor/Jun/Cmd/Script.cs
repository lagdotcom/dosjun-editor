using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class Script : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("Identifier", ArgumentType.Identifier),
        };

        public bool IsGlobal => true;
        public bool IsScript => false;
        public string Name => nameof(Script);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.NOP;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            Token identifier = a["Identifier"];

            p.CurrentScript = new Jun.Script { Name = identifier.Value, Type = ScriptType.Script };
            p.AddConstant(identifier.Value, (short)p.GetScriptId(identifier.Value, ScriptType.Script));
            p.Scripts.Add(p.CurrentScript);

            p.InScript = true;
        }
    }
}
