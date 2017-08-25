namespace DosjunEditor.Jun.Lex
{
    public class Number : ILexerState
    {
        public Tokenizer Parent { get; set; }

        public LexerState Process(char ch, LexerState guess)
        {
            switch (ch)
            {
                case '#':
                    Parent.AddToken(TokenType.Number);
                    Parent.EndLine();
                    return LexerState.None;

                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    Parent.Append(ch);
                    return LexerState.Number;

                case ' ':
                case '\t':
                case ',':
                case '\n':
                case '\r':
                case '\0':
                    Parent.AddToken(TokenType.Number);
                    return LexerState.None;

                default: throw Parent.Error("Invalid character in numeric literal");
            }
        }
    }
}
