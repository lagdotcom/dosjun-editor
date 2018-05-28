namespace DosjunEditor.Jun.Cmd
{
    class SetTileColour : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SetTileColour);
        public Op Op => Op.SetTileColour;

        public void Apply(Parser p)
        {
            p.Consume();
            Token x = p.Expression();
            Token y = p.Expression();
            Token surface = p.Expression();
            Token colour = p.Expression();

            p.EmitArgument(x);
            p.EmitArgument(y);
            p.EmitArgument(surface);
            p.EmitArgument(colour);
            p.Emit(Op);
        }
    }
}
