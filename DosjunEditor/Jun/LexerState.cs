namespace DosjunEditor.Jun
{
    public enum LexerState
    {
        None,
        CommentStart,
        Number,
        String,
        StringEscape,
        KeywordOrIdent,
        Internal,
        Operator,
        Whitespace,
        EndOfLine
    }
}
