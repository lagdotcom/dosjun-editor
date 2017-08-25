namespace DosjunEditor.Jun.Lex
{
    public class Internal : ILexerState
    {
        public Tokenizer Parent { get; set; }

        public LexerState Process(char ch, LexerState guess)
        {
            switch (guess)
            {
                case LexerState.KeywordOrIdent:
                case LexerState.Number:
                    Parent.Append(ch);
                    return LexerState.Internal;

                case LexerState.EndOfLine:
                case LexerState.Whitespace:
                    Parent.AddToken(TokenType.Internal);
                    return LexerState.None;

                case LexerState.CommentStart:
                    Parent.AddToken(TokenType.Internal);
                    Parent.EndLine();
                    return LexerState.None;

                default: throw Parent.Error("Invalid character in internal");
            }
        }
    }
}
