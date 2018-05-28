namespace DosjunEditor.Jun.Cmd
{
    class SetTileDescription : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SetTileDescription);
        public Op Op => Op.SetTileDescription;

        public void Apply(Parser p)
        {
            p.Consume();
            Token x = p.Expression();
            Token y = p.Expression();
            Token index = p.Expression();

            p.EmitArgument(x);
            p.EmitArgument(y);
            p.EmitArgument(index);
            p.Emit(Op);
        }
    }
}
