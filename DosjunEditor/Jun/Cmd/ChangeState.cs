namespace DosjunEditor.Jun.Cmd
{
    class ChangeState : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(ChangeState);
        public Op Op => Op.ChangeState;

        public void Apply(Parser p)
        {
            p.Consume();
            Token state = p.Expression();

            if (!p.ScriptExists(state, ScriptType.State))
                throw p.Error($"Unknown state: {state}");

            p.EmitArgument(state);
            p.Emit(Op);
        }
    }
}
