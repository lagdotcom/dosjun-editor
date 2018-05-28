namespace DosjunEditor.Jun.Cmd
{
    class Option : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Option);
        public Op Op => Op.Option;

        public void Apply(Parser p)
        {
            p.Consume();
            Token state = p.Expression();
            Token index = p.Expression();

            if (!p.ScriptExists(state, ScriptType.State))
                throw p.Error($"Unknown state: {state}");

            p.EmitArgument(state);
            p.EmitArgument(index);
            p.Emit(Op);
        }
    }
}
