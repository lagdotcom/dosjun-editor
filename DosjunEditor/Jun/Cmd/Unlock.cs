namespace DosjunEditor.Jun.Cmd
{
    class Unlock : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Unlock);
        public Op Op => Op.Unlock;

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
