namespace DosjunEditor.Jun.Cmd
{
    class JoinParty : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(JoinParty);
        public Op Op => Op.JoinParty;

        public void Apply(Parser p)
        {
            p.Consume();
            Token pc = p.Expression();

            p.EmitArgument(pc);
            p.Emit(Op);
        }
    }
}
