namespace DosjunEditor.Jun.Cmd
{
    class Safe : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Safe);
        public Op Op => Op.Safe;

        public void Apply(Parser p)
        {
            p.Consume();
            p.Emit(Op);
        }
    }
}
