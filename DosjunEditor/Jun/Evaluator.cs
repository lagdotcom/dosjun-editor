using System;
using System.Collections.Generic;

namespace DosjunEditor.Jun
{
    class Evaluator
    {
        public Evaluator(Parser p)
        {
            Parser = p;
            Scopes = new Stack<IEvaluatorScope>();
        }

        public Parser Parser { get; set; }
        Stack<IEvaluatorScope> Scopes { get; set; }

        public void Evaluate(IEnumerable<Token> tokens)
        {
            Scopes.Clear();
            Scopes.Push(new DefaultScope(this));

            foreach (Token tok in tokens)
                Scopes.Peek().Parse(tok);

            if (Scopes.Count != 1)
                throw new Ex.ParseException("Scope not closed");

            Scopes.Peek().Close();
        }

        private void Parse(IEnumerable<Token> tokens)
        { 
            Stack<Token> operators = new Stack<Token>();
            int topPrecedence;

            // convert Infix to Postfix
            foreach (Token tok in tokens)
            {
                switch (tok.Type)
                {
                    case TokenType.LeftParens:
                        operators.Push(tok);
                        break;

                    case TokenType.RightParens:
                        while (true)
                        {
                            if (operators.Count == 0)
                                throw new Ex.ParseException("Right parenthesis without left");

                            Token important = operators.Pop();
                            if (important.Type == TokenType.LeftParens) break;
                            else Parser.EmitOperator(important);
                        }
                        break;

                    case TokenType.Add:
                    case TokenType.And:
                    case TokenType.Divide:
                    case TokenType.Equals:
                    case TokenType.GT:
                    case TokenType.GTE:
                    case TokenType.Invert:
                    case TokenType.LT:
                    case TokenType.LTE:
                    case TokenType.Multiply:
                    case TokenType.NotEqual:
                    case TokenType.Or:
                    case TokenType.Subtract:
                        topPrecedence = operators.Count > 0 ? Env.Precedence[operators.Peek().Type] : 100;
                        if (topPrecedence < Env.Precedence[tok.Type])
                        {
                            Token important = operators.Pop();
                            Parser.EmitOperator(important);
                        }

                        operators.Push(tok);
                        break;

                    default:
                        Parser.EmitArgument(tok);
                        break;
                }
            }

            while (operators.Count > 0)
                Parser.EmitOperator(operators.Pop());
        }

        interface IEvaluatorScope
        {
            void Parse(Token tok);
            void Close();
        }

        class DefaultScope : IEvaluatorScope
        {
            public DefaultScope(Evaluator ev)
            {
                Evaluator = ev;
                Operators = new Stack<Token>();
            }

            public Evaluator Evaluator { get; }
            public Parser Parser => Evaluator.Parser;
            public Stack<Token> Operators { get; }

            public virtual void Parse(Token tok)
            {
                int topPrecedence;

                switch (tok.Type)
                {
                    case TokenType.Keyword:
                        Evaluator.Scopes.Push(new CallScope(Evaluator, tok));
                        break;

                    case TokenType.LeftParens:
                        Evaluator.Scopes.Push(new ParenthesisScope(Evaluator));
                        break;

                    case TokenType.RightParens:
                        throw new Ex.ParseException("Right parenthesis without left");

                    case TokenType.Add:
                    case TokenType.And:
                    case TokenType.Divide:
                    case TokenType.Equals:
                    case TokenType.GT:
                    case TokenType.GTE:
                    case TokenType.Invert:
                    case TokenType.LT:
                    case TokenType.LTE:
                    case TokenType.Multiply:
                    case TokenType.NotEqual:
                    case TokenType.Or:
                    case TokenType.Subtract:
                        topPrecedence = Operators.Count > 0 ? Env.Precedence[Operators.Peek().Type] : 100;
                        if (topPrecedence < Env.Precedence[tok.Type])
                        {
                            Token important = Operators.Pop();
                            Parser.EmitOperator(important);
                        }

                        Operators.Push(tok);
                        break;

                    default:
                        EmitArgument(tok);
                        break;
                }
            }

            protected virtual void EmitArgument(Token tok)
            {
                Parser.EmitArgument(tok);
            }

            public virtual void Close()
            {
                while (Operators.Count > 0)
                    Parser.EmitOperator(Operators.Pop());

                Evaluator.Scopes.Pop();
            }
        }

        class ParenthesisScope : DefaultScope
        {
            public ParenthesisScope(Evaluator ev) : base(ev) { }

            public override void Parse(Token tok)
            {
                switch (tok.Type)
                {
                    case TokenType.RightParens:
                        Close();
                        break;

                    default:
                        base.Parse(tok);
                        break;
                }
            }
        }

        class CallScope : DefaultScope
        {
            public CallScope(Evaluator ev, Token tok) : base(ev)
            {
                ArgumentList = new List<Token>();
                Command = Env.Commands[tok.Value];
            }
            
            public ICmd Command { get; }
            public List<Token> ArgumentList { get; }

            public override void Parse(Token tok)
            {
                switch (tok.Type)
                {
                    case TokenType.ArgumentListBegin:
                        break;

                    case TokenType.ArgumentListEnd:
                        Close();
                        break;

                    default:
                        base.Parse(tok);
                        break;
                }
            }

            protected override void EmitArgument(Token tok)
            {
                ArgumentList.Add(tok);
            }

            public override void Close()
            {
                while (Operators.Count > 0)
                    Parser.EmitOperator(Operators.Pop());

                if (ArgumentList.Count != Command.Args.Length)
                    throw new Ex.ArgumentCountException($"Wrong number of arguments to {Command.Name}");

                Dictionary<string, Token> arguments = new Dictionary<string, Token>();
                for (int i = 0; i < ArgumentList.Count; i++)
                    arguments[Command.Args[i].Name] = ArgumentList[i];

                Parser.CheckArguments(Command, arguments);
                Command.Apply(Parser, arguments);
                Evaluator.Scopes.Pop();
            }
        }
    }
}
