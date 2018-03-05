using DosjunEditor.Jun;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CompilerTest
{
    public abstract class CompilerTests
    {
        protected Token Tk(TokenType ty, string value) => new Token { Type = ty, Value = value };

        protected void AssertTokenization(string source, params Token[] specs)
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

        protected void AssertException<T>(string source, string message = null) where T : Exception
        {
            string modified = $"Script test\n{source}\nEndScript";
            Tokenizer tk = new Tokenizer();

            Assert.ThrowsException<T>(() =>
            {
                try
                {
                    tk.Tokenize(modified.Split('\n'));

                    System.Diagnostics.Debug.WriteLine($"no exception! {tk.Tokens}");
                }
                catch (T ex)
                {
                    if (message != null)
                        Assert.AreEqual(message, ex.Message.Substring(0, message.Length));

                    throw ex;
                }
            });
        }

        protected void AssertParseException<T>(string source, string message = null) where T : Exception
        {
            string modified = $"Script test\n{source}\nEndScript";
            Tokenizer tk = new Tokenizer();
            tk.Tokenize(modified.Split('\n'));
            Parser pr = new Parser();

            Assert.ThrowsException<T>(() =>
            {
                try
                {
                    pr.Parse(tk.Tokens);

                    System.Diagnostics.Debug.WriteLine($"no exception! {tk.Tokens}");
                }
                catch (T ex)
                {
                    if (message != null)
                        Assert.AreEqual(message, ex.Message.Substring(0, message.Length));

                    throw ex;
                }
            });
        }
    }
}
