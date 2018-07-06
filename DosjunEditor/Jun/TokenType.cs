namespace DosjunEditor.Jun
{
    public enum TokenType
    {
        Unknown,
        Expression,

        EOL,
        Separator,

        Keyword,
        Identifier,
        Internal,
        String,
        Number,

        Assignment,
        Equals,
        NotEqual,
        LT,
        LTE,
        GT,
        GTE,

        Add,
        Subtract,
        Multiply,
        Divide,
        And,
        Or,

        LeftParens,
        RightParens,
        ArgumentListBegin,
        ArgumentListEnd,

        Reference,
        Invert,
    }
}
