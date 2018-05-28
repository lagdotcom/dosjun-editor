namespace DosjunEditor.Jun.Cmd
{
    class Local : ICmd
    {
        public bool IsGlobal => true;
        public bool IsScript => false;
        public string Name => nameof(Local);
        public Op Op => Op.NOP;

        public void Apply(Parser p)
        {
            p.Consume();
            Token identifier = p.Consume(TokenType.Identifier);

            p.AddVariable(Scope.Local, identifier.Value);
        }
    }
}
