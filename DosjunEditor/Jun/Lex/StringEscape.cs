namespace DosjunEditor.Jun.Lex
{
    public class StringEscape : ILexerState
    {
        public Tokenizer Parent { get; set; }

        public LexerState Process(char ch, LexerState guess)
        {
            switch (ch)
            {
                case 'n':
                    Parent.Append('\n');
                    return LexerState.String;

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
