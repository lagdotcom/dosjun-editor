namespace DosjunEditor.Jun.Cmd
{
    class GotoXY : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(GotoXY);
        public Op Op => Op.GotoXY;

        public void Apply(Parser p)
        {
            p.Consume();
            Token x = p.Expression();
            Token y = p.Expression();

            p.EmitArgument(x);
            p.EmitArgument(y);
            p.Emit(Op);
        }
    }
}
