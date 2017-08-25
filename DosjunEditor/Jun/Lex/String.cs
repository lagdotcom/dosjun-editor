namespace DosjunEditor.Jun.Lex
{
    public class String : ILexerState
    {
        public Tokenizer Parent { get; set; }

        public LexerState Process(char ch, LexerState guess)
        {
            switch (ch)
            {
                case '\\': return LexerState.StringEscape;

                case '"':
                    Parent.AddToken(TokenType.String);
                    return LexerState.None;

                case '\n':
                case '\r':
                case '\0':
                    throw Parent.Error("EOL during string literal");

                default:
                    Parent.Append(ch);
                    return LexerState.String;
            }
        }
    }
}
