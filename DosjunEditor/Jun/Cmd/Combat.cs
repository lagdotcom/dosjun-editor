namespace DosjunEditor.Jun.Cmd
{
    class Combat : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Combat);
        public Op Op => Op.Combat;

        public void Apply(Parser p)
        {
            p.Consume();
            Token combat = p.Expression();

            p.EmitArgument(combat);
            p.Emit(Op);
        }
    }
}
