namespace DosjunEditor.Jun.Cmd
{
    class Const : ICmd
    {
        public bool IsGlobal => true;
        public bool IsScript => false;
        public string Name => nameof(Const);
        public Op Op => Op.NOP;

        public void Apply(Parser p)
        {
            p.Consume();
            Token identifier = p.Consume(TokenType.Identifier);
            p.Consume(TokenType.Assignment);
            Token value = p.Consume(TokenType.Number);

            p.AddConstant(identifier.Value, value.Value);
        }
    }
}
