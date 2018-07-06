using System.Collections.Generic;
using DosjunEditor.Jun.Ex;

namespace DosjunEditor.Jun.Cmd
{
    class EndScript : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(EndScript);
        public Argument[] Args => new Argument[0];
        public Argument Returns => Argument.Null;
        public Op Op => Op.NOP;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            if (p.Contexts.Count > 0)
                throw new ScopeException($"Unclosed scope: {p.Contexts.Peek().Name}");

            if (p.CurrentScript.Type != ScriptType.Script)
                throw new ScopeException($"{Name} inside {p.CurrentScript.Type}");

            p.Emit(Op.Return);
            p.InScript = false;
            p.CurrentScript = null;
        }
    }
}
