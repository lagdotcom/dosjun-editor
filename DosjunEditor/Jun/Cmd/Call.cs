namespace DosjunEditor.Jun.Cmd
{
    class Call : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Call);
        public Op Op => Op.Call;

        public void Apply(Parser p)
        {
            p.Consume();
            Token script = p.Expression();

            if (!p.ScriptExists(script))
                throw p.Error($"Unknown script: {script}");

            p.EmitArgument(script);
            p.Emit(Op);
        }
    }
}
