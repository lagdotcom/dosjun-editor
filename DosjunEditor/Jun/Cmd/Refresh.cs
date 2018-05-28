namespace DosjunEditor.Jun.Cmd
{
    class Refresh : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Refresh);
        public Op Op => Op.Refresh;

        public void Apply(Parser p)
        {
            p.Consume();
            p.Emit(Op);
        }
    }
}
