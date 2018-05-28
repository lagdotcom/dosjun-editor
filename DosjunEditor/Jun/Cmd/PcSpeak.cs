namespace DosjunEditor.Jun.Cmd
{
    class PcSpeak : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(PcSpeak);
        public Op Op => Op.PcSpeak;

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
