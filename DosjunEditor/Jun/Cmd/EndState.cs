namespace DosjunEditor.Jun.Cmd
{
    class EndState : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(EndState);
        public Op Op => Op.NOP;

        public void Apply(Parser p)
        {
            if (p.Contexts.Count > 0)
                throw p.Error($"Unclosed scope: {p.Contexts.Peek().Name}");

            if (p.CurrentScript.Type != ScriptType.State)
                throw p.Error($"{Name} inside {p.CurrentScript.Type}");

            p.Consume();
            p.Emit(Op.Return);
            p.InScript = false;
            p.CurrentScript = null;
        }
    }
}
