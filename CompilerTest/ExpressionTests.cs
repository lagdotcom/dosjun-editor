using Microsoft.VisualStudio.TestTools.UnitTesting;
using DosjunEditor.Jun;
using DosjunEditor.Jun.Ex;
using System.Collections.Generic;

namespace CompilerTest
{
    [TestClass]
    public class ExpressionTests : CompilerTests
    {
        [TestMethod]
        public void TestSimpleExpression()
        {
            AssertTokenization("a = 2 + 3 * 4",
                Tk(TokenType.Identifier, "a"),
                Tk(TokenType.Assignment),
                Tk(TokenType.Number, "2"),
                Tk(TokenType.Add),
                Tk(TokenType.Number, "3"),
                Tk(TokenType.Multiply),
                Tk(TokenType.Number, "4")
            );
        }

        [TestMethod]
        public void TestBadExpressions()
        {
            AssertException<TokenizationException>("a =", "Invalid transition: Operator => EndOfLine");
        }

        [TestMethod]
        public void TestComplexExpression()
        {
            IList<Token> tokens = AssertTokenization("a = (@X + @Y) + 4 * SetDanger((3 + 11) * 8)",
                Tk(TokenType.Identifier, "a"),
                Tk(TokenType.Assignment),
                Tk(TokenType.LeftParens),
                Tk(TokenType.Internal, "X"),
                Tk(TokenType.Add),
                Tk(TokenType.Internal, "Y"),
                Tk(TokenType.RightParens),
                Tk(TokenType.Add),
                Tk(TokenType.Number, "4"),
                Tk(TokenType.Multiply),
                Tk(TokenType.Keyword, "SetDanger"),
                Tk(TokenType.ArgumentListBegin),
                Tk(TokenType.LeftParens),
                Tk(TokenType.Number, "3"),
                Tk(TokenType.Add),
                Tk(TokenType.Number, "11"),
                Tk(TokenType.RightParens),
                Tk(TokenType.Multiply),
                Tk(TokenType.Number, "8"),
                Tk(TokenType.ArgumentListEnd)
            );

            AssertParse(tokens,
                Co(Op.PushInternal), Co(Internal.X),
                Co(Op.PushInternal), Co(Internal.Y),
                Co(Op.Add),
                Co(Op.PushLiteral), 4, 0,
                Co(Op.PushLiteral), 3, 0,
                Co(Op.PushLiteral), 11, 0,
                Co(Op.Add),
                Co(Op.PushLiteral), 8, 0,
                Co(Op.Mul),
                Co(Op.SetDanger),
                Co(Op.Mul),
                Co(Op.Add),
                Co(Op.PopTemp), 0,
                Co(Op.Return)
            );
        }
    }
}
