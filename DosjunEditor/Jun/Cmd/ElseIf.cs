namespace DosjunEditor.Jun.Cmd
{
    class ElseIf : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(ElseIf);
        public Op Op => Op.NOP;

        public void Apply(Parser p)
        {
            if (p.Contexts.Count == 0)
                throw p.Error("ElseIf without If");
            p.Consume();

            p.Emit(Op.Jump);
            p.AddOffset();
            p.ResolveJump(2);
            p.EmitUnknown();

            Token expression = p.Expression();
            p.EmitArgument(expression);
            p.Emit(Op.JumpFalse);
            p.RenewContext();
            p.EmitUnknown();
        }
    }
}
