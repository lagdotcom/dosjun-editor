namespace DosjunEditor.Jun.Cmd
{
    class GetAttitude : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(GetAttitude);
        public Op Op => Op.GetAttitude;

        public void Apply(Parser p)
        {
            p.Consume();
            Token pc = p.Expression();

            p.EmitArgument(pc);
            p.Emit(Op);
        }
    }
}
