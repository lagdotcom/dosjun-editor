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
                        Parser.EmitArgument(tok);
                        break;
                }
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
                CurrentArgument = new List<Token>();
            }
            
            public ICmd Command { get; }
            public List<Token> ArgumentList { get; }
            public List<Token> CurrentArgument { get; }

            public override void Parse(Token tok)
            {
                switch (tok.Type)
                {
                    case TokenType.ArgumentListBegin:
                        break;

                    case TokenType.ArgumentListEnd:
                        FinishArgument();
                        Close();
                        break;

                    case TokenType.Separator:
                        FinishArgument();
                        break;
                        
                    default:
                        CurrentArgument.Add(tok);
                        break;
                }
            }
            
            protected void FinishArgument()
            {
                if (CurrentArgument.Count == 0)
                    throw new Ex.ParseException($"No expression given for argument");
                else if (CurrentArgument.Count == 1)
                    ArgumentList.Add(CurrentArgument[0]);
                else
                {
                    // note: this is kinda cheeky; Parser will now have to spawn another Evaluator to handle this!
                    ArgumentList.Add(new ExpressionToken(CurrentArgument));
                }

                CurrentArgument.Clear();
            }

            public override void Close()
            {
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
