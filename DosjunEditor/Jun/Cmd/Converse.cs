namespace DosjunEditor.Jun.Cmd
{
    class Converse : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Converse);
        public Op Op => Op.Converse;

        public void Apply(Parser p)
        {
            p.Consume();
            Token npc = p.Expression();
            Token state = p.Expression();

            if (!p.ScriptExists(state, ScriptType.State))
                throw p.Error($"Unknown state: {state}");

            p.EmitArgument(npc);
            p.EmitArgument(state);
            p.Emit(Op);
        }
    }
}
