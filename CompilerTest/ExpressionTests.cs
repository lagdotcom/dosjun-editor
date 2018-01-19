using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DosjunEditor.Jun;
using System.Linq;

namespace CompilerTest
{
    [TestClass]
    public class ExpressionTests
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
            AssertException<CodeException>("a =", "Invalid transition: Operator => EndOfLine");
        }

        private Token Tk(TokenType ty, string value) => new Token { Type = ty, Value = value };

        private void AssertTokenization(string source, params Token[] specs)
        {
            string modified = $"Script test\n{source}\nEndScript";
            Tokenizer tk = new Tokenizer();
            tk.Tokenize(modified.Split('\n'));

            int tokIndex = 3;
            foreach (Token spec in specs)
            {
                Token check = tk.Tokens[tokIndex++];
                Assert.AreEqual(spec.Type, check.Type);
                Assert.AreEqual(spec.Value, check.Value);
            }

            int compiledTokens = tk.Tokens.Count - 6;
            int tokens = specs.Count();
            Assert.AreEqual(tokens, compiledTokens);
        }

        private void AssertException<T>(string source, string message) where T: Exception
        {
            string modified = $"Script test\n{source}\nEndScript";
            Tokenizer tk = new Tokenizer();

            Assert.ThrowsException<T>(() =>
            {
                try
                {
                    tk.Tokenize(modified.Split('\n'));
                }
                catch (T ex)
                {
                    Assert.AreEqual(message, ex.Message.Substring(0, message.Length));
                    throw ex;
                }
            });
        }
    }
}
