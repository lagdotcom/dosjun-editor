namespace DosjunEditor.Jun
{
    public enum LexerState
    {
        None,
        CommentStart,
        Separator,
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
