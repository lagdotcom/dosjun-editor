namespace DosjunEditor.Jun.Cmd
{
    class SetDanger : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(SetDanger);
        public Op Op => Op.SetDanger;

        public void Apply(Parser p)
        {
            p.Consume();
            Token danger = p.Expression();

            p.EmitArgument(danger);
            p.Emit(Op);
        }
    }
}
