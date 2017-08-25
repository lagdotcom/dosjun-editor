namespace DosjunEditor.Jun
{
    public struct Token
    {
        public string Value { get; set; }
        public TokenType Type { get; set; }

        public override string ToString() => $"{Value} ({Type})";
    }
}
