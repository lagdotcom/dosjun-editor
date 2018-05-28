namespace DosjunEditor.Jun.Cmd
{
    class ChoosePcPronouns : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(ChoosePcPronouns);
        public Op Op => Op.ChoosePcPronouns;

        public void Apply(Parser p)
        {
            p.Consume();
            Token pc = p.Expression();

            p.EmitArgument(pc);
            p.Emit(Op);
        }
    }
}
