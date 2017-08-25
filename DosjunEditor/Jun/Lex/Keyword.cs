namespace DosjunEditor.Jun.Lex
{
    public class Keyword : ILexerState
    {
        public Tokenizer Parent { get; set; }

        public LexerState Process(char ch, LexerState guess)
        {
            switch (guess)
            {
                case LexerState.CommentStart:
                    AddToken();
                    Parent.EndLine();
                    return LexerState.None;

                case LexerState.KeywordOrIdent:
                case LexerState.Number:
                    Parent.Append(ch);
                    return LexerState.KeywordOrIdent;

                case LexerState.Operator:
                    AddToken();
                    Parent.Rewind();
                    return LexerState.None;

                case LexerState.EndOfLine:
                case LexerState.Whitespace:
                    AddToken();
                    return LexerState.None;

                default: throw Parent.Error("Invalid character in keyword/identifier");
            }
        }

        private void AddToken()
        {
            Parent.AddToken(Parent.IsKeyword() ? TokenType.Keyword : TokenType.Identifier);
        }
    }
}
