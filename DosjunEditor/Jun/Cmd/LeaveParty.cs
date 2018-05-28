namespace DosjunEditor.Jun.Cmd
{
    class LeaveParty : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(LeaveParty);
        public Op Op => Op.LeaveParty;

        public void Apply(Parser p)
        {
            p.Consume();
            Token pc = p.Expression();

            p.EmitArgument(pc);
            p.Emit(Op);
        }
    }
}
