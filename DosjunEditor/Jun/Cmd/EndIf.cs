namespace DosjunEditor.Jun.Cmd
{
    class EndIf : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(EndIf);
        public Op Op => Op.NOP;

        public void Apply(Parser p)
        {
            if (p.Contexts.Count == 0)
                throw p.Error("EndIf without If");
            p.Consume();

            p.ResolveJump();
            p.ResolveOffsets();
            p.Contexts.Pop();
        }
    }
}
