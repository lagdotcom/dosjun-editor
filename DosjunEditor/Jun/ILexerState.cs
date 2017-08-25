namespace DosjunEditor.Jun
{
    public interface ILexerState
    {
        Tokenizer Parent { get; set; }

        LexerState Process(char ch, LexerState guess);
    }
}
