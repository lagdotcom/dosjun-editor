namespace DosjunEditor.Jun
{
    public class Token
    {
        public string Value { get; set; }
        public TokenType Type { get; set; }

        public override string ToString() => $"{Value}.{Type.ToString().Substring(0, 3)}";
    }
}
