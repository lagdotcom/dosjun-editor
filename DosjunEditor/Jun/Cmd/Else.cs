namespace DosjunEditor.Jun.Cmd
{
    class Else : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(Else);
        public Op Op => Op.NOP;

        public void Apply(Parser p)
        {
            if (p.Contexts.Count == 0)
                throw p.Error("Else without If");
            p.Consume();

            p.Emit(Op.Jump);
            p.ResolveJump(2);
            p.RenewContext(0, Name);
            p.EmitUnknown();
        }
    }
}
