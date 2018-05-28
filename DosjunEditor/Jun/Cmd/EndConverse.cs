namespace DosjunEditor.Jun.Cmd
{
    class EndConverse : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(EndConverse);
        public Op Op => Op.EndConverse;

        public void Apply(Parser p)
        {
            p.Consume();
            p.Emit(Op);
        }
    }
}
