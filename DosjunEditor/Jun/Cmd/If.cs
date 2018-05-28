namespace DosjunEditor.Jun.Cmd
{
    class If : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(If);
        public Op Op => Op.NOP;

        public void Apply(Parser p)
        {
            p.Consume();
            Token expression = p.Expression();

            p.EmitArgument(expression);
            p.Emit(Op.JumpFalse);
            p.AddContext(Name);
            p.EmitUnknown();
        }
    }
}
