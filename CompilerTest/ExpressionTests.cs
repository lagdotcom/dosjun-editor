using Microsoft.VisualStudio.TestTools.UnitTesting;
using DosjunEditor.Jun;
using DosjunEditor.Jun.Ex;

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
                Tk(TokenType.Assignment, "="),
                Tk(TokenType.Number, "2"),
                Tk(TokenType.Add, "+"),
                Tk(TokenType.Number, "3"),
                Tk(TokenType.Multiply, "*"),
                Tk(TokenType.Number, "4")
            );
        }

        [TestMethod]
        public void TestBadExpressions()
        {
            AssertException<TokenizationException>("a =", "Invalid transition: Operator => EndOfLine");
        }
    }
}
