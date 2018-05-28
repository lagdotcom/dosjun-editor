namespace DosjunEditor.Jun.Cmd
{
    class RemoveWall : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(RemoveWall);
        public Op Op => Op.RemoveWall;

        public void Apply(Parser p)
        {
            p.Consume();
            Token x = p.Expression();
            Token y = p.Expression();
            Token dir = p.Expression();

            p.EmitArgument(x);
            p.EmitArgument(y);
            p.EmitArgument(dir);
            p.Emit(Op);
        }
    }
}
