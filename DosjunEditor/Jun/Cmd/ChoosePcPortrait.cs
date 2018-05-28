namespace DosjunEditor.Jun.Cmd
{
    class ChoosePcPortrait : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(ChoosePcPortrait);
        public Op Op => Op.ChoosePcPortrait;

        public void Apply(Parser p)
        {
            p.Consume();
            Token pc = p.Expression();

            p.EmitArgument(pc);
            p.Emit(Op);
        }
    }
}
