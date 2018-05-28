namespace DosjunEditor.Jun.Cmd
{
    class Return : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Return);
        public Op Op => Op.Return;

        public void Apply(Parser p)
        {
            p.Consume();
            p.Emit(Op);
        }
    }
}
