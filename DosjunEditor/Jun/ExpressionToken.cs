using System.Collections.Generic;

namespace DosjunEditor.Jun
{
    internal class ExpressionToken : Token
    {
        public List<Token> Tokens { get; private set; }

        public ExpressionToken(List<Token> tokens)
        {
            Tokens = tokens;
            Type = TokenType.Expression;
            Value = "...";
        }
    }
}
