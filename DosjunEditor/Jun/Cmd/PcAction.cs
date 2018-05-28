namespace DosjunEditor.Jun.Cmd
{
    class PcAction : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(PcAction);
        public Op Op => Op.PcAction;

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
