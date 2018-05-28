namespace DosjunEditor.Jun.Cmd
{
    class Text : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Text);
        public Op Op => Op.Text;

        public void Apply(Parser p)
        {
            p.Consume();
            Token index = p.Expression();

            p.EmitArgument(index);
            p.Emit(Op);
        }
    }
}
