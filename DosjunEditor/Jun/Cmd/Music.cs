namespace DosjunEditor.Jun.Cmd
{
    class Music : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Music);
        public Op Op => Op.Music;

        public void Apply(Parser p)
        {
            p.Consume();
            Token index = p.Expression();

            p.EmitArgument(index);
            p.Emit(Op);
        }
    }
}
