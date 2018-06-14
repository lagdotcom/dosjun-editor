namespace DosjunEditor.Jun.Cmd
{
    class Teleport : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Teleport);
        public Op Op => Op.Teleport;

        public void Apply(Parser p)
        {
            p.Consume();
            Token zone = p.Expression();
            Token x = p.Expression();
            Token y = p.Expression();
            Token facing = p.Expression();
            Token transition = p.Expression();

            p.EmitArgument(zone);
            p.EmitArgument(x);
            p.EmitArgument(y);
            p.EmitArgument(facing);
            p.EmitArgument(transition);
            p.Emit(Op);
        }
    }
}
