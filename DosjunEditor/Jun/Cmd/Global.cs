namespace DosjunEditor.Jun.Cmd
{
    class Global : ICmd
    {
        public bool IsGlobal => true;
        public bool IsScript => false;
        public string Name => nameof(Global);
        public Op Op => Op.NOP;

        public void Apply(Parser p)
        {
            p.Consume();
            Token identifier = p.Consume(TokenType.Identifier);

            p.AddVariable(Scope.Global, identifier.Value);
        }
    }
}
