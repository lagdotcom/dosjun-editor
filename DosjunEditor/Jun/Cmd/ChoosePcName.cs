namespace DosjunEditor.Jun.Cmd
{
    class ChoosePcName : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(ChoosePcName);
        public Op Op => Op.ChoosePcName;

        public void Apply(Parser p)
        {
            p.Consume();
            Token pc = p.Expression();

            p.EmitArgument(pc);
            p.Emit(Op);
        }
    }
}
