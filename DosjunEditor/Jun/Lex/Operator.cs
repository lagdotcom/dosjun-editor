namespace DosjunEditor.Jun.Lex
{
    public class Operator : ILexerState
    {
        public Tokenizer Parent { get; set; }

        public LexerState Process(char ch, LexerState guess)
        {
            switch (guess)
            {
                case LexerState.Operator:
                    Parent.Append(ch);
                    return LexerState.Operator;

                case LexerState.KeywordOrIdent:
                case LexerState.Number:
                case LexerState.String:
                case LexerState.Internal:
                case LexerState.CommentStart:
                    Parent.Rewind();
                    AddToken();
                    return LexerState.None;

                case LexerState.EndOfLine:
                case LexerState.Whitespace:
                    AddToken();
                    return LexerState.None;

                default: throw Parent.Error("Invalid character in internal");
            }
        }

        private void AddToken()
        {
            TokenType tt = Parent.OperatorType();
            if (tt == TokenType.Unknown) throw Parent.Error("Unknown operator type");
            Parent.AddToken(tt);
        }
    }
}
