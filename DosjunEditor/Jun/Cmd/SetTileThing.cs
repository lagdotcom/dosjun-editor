namespace DosjunEditor.Jun.Cmd
{
    class SetTileThing : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SetTileThing);
        public Op Op => Op.SetTileThing;

        public void Apply(Parser p)
        {
            p.Consume();
            Token x = p.Expression();
            Token y = p.Expression();
            Token thing = p.Expression();

            p.EmitArgument(x);
            p.EmitArgument(y);
            p.EmitArgument(thing);
            p.Emit(Op);
        }
    }
}
