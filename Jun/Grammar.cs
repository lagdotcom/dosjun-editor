namespace Jun
{
    static class Grammar
    {
        public const string EOF = "\0";

        public const string IF = "IF";
        public const string ELSE = "ELSE";
        public const string ENDIF = "ENDIF";
        public const string GLOBAL = "GLOBAL";
        public const string LOCAL = "LOCAL";
        public const string FLAG = "FLAG";

        public const char NUL = '\0';
        public const char HTAB = '\t';
        public const char CR = '\r';
        public const char LF = '\n';
        public const char SP = ' ';
        public const char COMMA = ',';
        public const char LP = '(';
        public const char RP = ')';
        public const char PLUS = '+';
        public const char MINUS = '-';
        public const char STAR = '*';
        public const char SLASH = '/';
        public const char EQ = '=';
        public const char QUOTE = '"';
        public const char LT = '<';
        public const char GT = '>';
        public const char UNDERSCORE = '_';
        public const char AT = '@';
        public const char AMP = '&';
        public const char PIPE = '|';
        public const char DOLLAR = '$';
        public const char EXCL = '!';
        public const char HASH = '#';
        public const char BS = '\\';

        public readonly static char[] WhiteSpace = { SP, HTAB };
        public readonly static char[] Operators = { PLUS, MINUS, STAR, SLASH, LT, GT, EQ, AMP, PIPE };
    }
}
