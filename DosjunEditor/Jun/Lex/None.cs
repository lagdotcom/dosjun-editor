namespace DosjunEditor.Jun.Lex
{
    public class None : ILexerState
    {
        public Tokenizer Parent { get; set; }

        public LexerState Process(char ch, LexerState guess)
        {
            LexerState next = Parent.State;

            switch (guess)
            {
                case LexerState.CommentStart:
                case LexerState.EndOfLine:
                    Parent.EndLine();
                    break;

                case LexerState.Whitespace:
                    break;

                case LexerState.String:
                case LexerState.Internal:
                    next = guess;
                    break;

                case LexerState.Number:
                case LexerState.Operator:
                case LexerState.KeywordOrIdent:
                    next = guess;
                    Parent.Append(ch);
                    break;

                default: throw Parent.Error("Invalid character");
            }

            return next;
        }
    }
}
