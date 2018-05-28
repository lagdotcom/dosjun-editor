namespace DosjunEditor.Jun.Cmd
{
    class NpcSpeak : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(NpcSpeak);
        public Op Op => Op.NpcSpeak;

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
