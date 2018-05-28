namespace DosjunEditor.Jun.Cmd
{
    class SetAttitude : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SetAttitude);
        public Op Op => Op.SetAttitude;

        public void Apply(Parser p)
        {
            p.Consume();
            Token pc = p.Expression();
            Token value = p.Expression();

            p.EmitArgument(pc);
            p.EmitArgument(value);
            p.Emit(Op);
        }
    }
}
