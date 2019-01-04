using DosjunEditor.Jun;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompilerTest
{
    public abstract class CompilerTests
    {
        private Dictionary<TokenType, string> defaultTokenValues = new Dictionary<TokenType, string>
        {
            { TokenType.Add, "+" },
            { TokenType.And, "&" },
            { TokenType.ArgumentListBegin, "(" },
            { TokenType.ArgumentListEnd, ")" },
            { TokenType.Assignment, "=" },
            { TokenType.Divide, "/" },
            { TokenType.Equals, "=" },
            { TokenType.GT, ">" },
            { TokenType.GTE, ">=" },
            { TokenType.Invert, "!" },
            { TokenType.LeftParens, "(" },
            { TokenType.LT, "<" },
            { TokenType.LTE, "<=" },
            { TokenType.Multiply, "*" },
            { TokenType.NotEqual, "!=" },
            { TokenType.Or, "|" },
            { TokenType.RightParens, ")" },
            { TokenType.Separator, "," },
            { TokenType.Subtract, "-" },
        };

        protected Token Tk(TokenType ty, string value) => new Token { Type = ty, Value = value };
        protected Token Tk(TokenType ty) => new Token { Type = ty, Value = defaultTokenValues[ty] };

        protected byte Co(Internal i) => (byte)i;
        protected byte Co(Op o) => (byte)o;

        protected IList<Token> AssertTokenization(string source, params Token[] specs)
        {
            DosjunEditor.Context ctx = GetContext();
            string modified = $"Script test\n{source}\nEndScript";
            System.Diagnostics.Debug.WriteLine(modified);

            Tokenizer tk = new Tokenizer(ctx);
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
            Assert.AreEqual(tokens, compiledTokens, "Token count does not match");

            return tk.Tokens;
        }

        protected void AssertException<T>(string source, string message = null) where T : Exception
        {
            DosjunEditor.Context ctx = GetContext();
            string modified = $"Script test\n{source}\nEndScript";
            Tokenizer tk = new Tokenizer(ctx);

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
            DosjunEditor.Context ctx = GetContext();
            string modified = $"Script test\n{source}\nEndScript";
            Tokenizer tk = new Tokenizer(ctx);
            tk.Tokenize(modified.Split('\n'));
            Parser pr = new Parser(ctx);

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

        protected void AssertParse(IList<Token> tokens, params byte[] code)
        {
            DosjunEditor.Context ctx = GetContext();
            Parser p = new Parser(ctx);
            p.Parse(tokens);

            System.Diagnostics.Debug.WriteLine(Visualizer.Show(p.Scripts));

            var compiled = p.Scripts[0].Code;
            Assert.AreEqual(code.Length, compiled.Count, "Opcode count does not match");

            for (int i = 0; i < compiled.Count; i++)
                Assert.AreEqual(code[i], compiled[i], $"Opcode {i} does not match ({(Op)code[i]} != {(Op)compiled[i]})");
        }

        protected DosjunEditor.Context GetContext()
        {
            Env.Initialise();
            return new DosjunEditor.Context();
        }
    }
}
