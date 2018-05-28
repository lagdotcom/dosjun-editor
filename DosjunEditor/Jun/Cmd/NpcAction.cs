namespace DosjunEditor.Jun.Cmd
{
    class NpcAction : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(NpcAction);
        public Op Op => Op.NpcAction;

        public void Apply(Parser p)
        {
            p.Consume();
            Token speaker = p.Expression();
            Token index = p.Expression();

            p.EmitArgument(speaker);
            p.EmitArgument(index);
            p.Emit(Op);
        }
    }
}
