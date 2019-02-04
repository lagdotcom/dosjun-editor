using DosjunEditor.Jun.Ex;
using System;
using System.Collections.Generic;
using System.IO;

namespace DosjunEditor.Jun
{
    using TokenizerCallback = Func<char, LexerState, LexerState>;

    public class Tokenizer
    {
        private Dictionary<LexerState, TokenizerCallback> stateMachine;
        private bool endOfLine;
        private string currentToken;
        private LexerState afterWord;
        private int parensDepth;

        public Tokenizer(DosjunEditor.Context ctx)
        {
            Context = ctx;
            Tokens = new List<Token>();
            stateMachine = new Dictionary<LexerState, TokenizerCallback>
            {
                [LexerState.None] = StateNone,
                [LexerState.KeywordOrIdent] = StateKeyword,
                [LexerState.Operator] = StateOperator,
                [LexerState.Number] = StateNumber,
                [LexerState.Separator] = StateSeparator,
                [LexerState.String] = StateString,
                [LexerState.StringEscape] = StateStringEscape,
                [LexerState.Internal] = StateInternal,
                [LexerState.Reference] = StateReference,
                [LexerState.ArgumentList] = StateArgumentList,
            };
        }

        public void Tokenize(string filename)
        {
            Filename = filename;

            List<string> lines = new List<string>();
            using (Stream file = File.OpenRead(filename))
            {
                StreamReader sr = new StreamReader(file);
                while (!sr.EndOfStream) lines.Add(sr.ReadLine());
            }

            Tokenize(lines);
        }

        public void Tokenize(IEnumerable<string> lines)
        {
            afterWord = LexerState.None;
            parensDepth = 0;

            Line = 0;
            foreach (string line in lines)
            {
                Line++;
                if (line.Length == 0) continue;

                CurrentLine = line;
                Column = 0;
                State = LexerState.None;
                endOfLine = false;
                currentToken = string.Empty;

                while (!endOfLine)
                {
                    char ch = Next();
                    LexerState guess = Guess(ch);
                    State = stateMachine[State](ch, guess);

                    if (!stateMachine.ContainsKey(State))
                        throw new TokenizationException($"Unknown tokenizer state: {State}");
                }

                // process end of line in case something is missing
                stateMachine[State]('\n', LexerState.EndOfLine);

                // special handling for 'Include'
                if (Tokens.Count >= 2 && Tokens[Tokens.Count - 2].Value == "Include")
                {
                    Token filename = Tokens[Tokens.Count - 1];
                    Tokens.RemoveRange(Tokens.Count - 2, 2);

                    Tokenizer jt = new Tokenizer(Context);
                    if (filename.Type != TokenType.String)
                        throw new ArgumentTypeException("Can only Include a (filename) string");

                    ScriptSource include = Context.Djn.FindByName<ScriptSource>(filename.Value);
                    if (include == null)
                        throw new MissingResourceException($"Unknown Source resource: {filename.Value}");

                    jt.Tokenize(include.Source.Split('\n'));
                    Tokens.AddRange(jt.Tokens);
                }
                else
                    Tokens.Add(new Token { Type = TokenType.EOL });
            }
        }

        public TokenType OperatorType()
        {
            if (Env.Operators.ContainsKey(currentToken)) return Env.Operators[currentToken];
            return TokenType.Unknown;
        }

        public LexerState Guess(char ch)
        {
            switch (ch)
            {
                case '#':  return LexerState.CommentStart;
                case '\\': return LexerState.StringEscape;
                case '"':  return LexerState.String;
                case '@':  return LexerState.Internal;
                case ',':  return LexerState.Separator;
                case '$':  return LexerState.Reference;

                case '(':  return LexerState.LeftParens;
                case ')':  return LexerState.RightParens;

                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return LexerState.Number;

                case '=':
                case '!':
                case '>':
                case '<':
                case '+':
                case '-':
                case '*':
                case '/':
                case '&':
                case '|':
                    return LexerState.Operator;

                case ' ':
                case '\t':
                    return LexerState.Whitespace;

                case '\n':
                case '\r':
                case '\0':
                    return LexerState.EndOfLine;

                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                case 'g':
                case 'h':
                case 'i':
                case 'j':
                case 'k':
                case 'l':
                case 'm':
                case 'n':
                case 'o':
                case 'p':
                case 'q':
                case 'r':
                case 's':
                case 't':
                case 'u':
                case 'v':
                case 'w':
                case 'x':
                case 'y':
                case 'z':
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'G':
                case 'H':
                case 'I':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'O':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                case '_':
                    return LexerState.KeywordOrIdent;
            }

            return LexerState.None;
        }

        protected char Next()
        {
            char ch = CurrentLine[Column];
            Column++;

            if (Column >= CurrentLine.Length) endOfLine = true;
            return ch;
        }

        protected void Append(char ch)
        {
            currentToken += ch;
        }

        protected void Rewind()
        {
            Column--;
            endOfLine = false;
        }

        protected void AddKeywordToken()
        {
            AddToken(IsKeyword() ? TokenType.Keyword : TokenType.Identifier);
        }

        protected void AddOperatorToken()
        {
            TokenType tt = OperatorType();
            if (tt == TokenType.Unknown)
                throw new TokenizationException($"Unknown operator: {currentToken}");

            AddToken(tt);
        }

        protected void AddParenthesis(char ch)
        {
            if (ch == '(') AddToken(TokenType.LeftParens, "(");
            else AddToken(TokenType.RightParens, ")");
        }

        protected void AddToken(TokenType tt, string replace = "")
        {
            if (!string.IsNullOrWhiteSpace(replace))
                currentToken = replace;

            if (!string.IsNullOrWhiteSpace(currentToken))
            {
                Tokens.Add(new Token { Type = tt, Value = currentToken });
                currentToken = string.Empty;
            }
        }

        protected bool IsKeyword()
        {
            return Env.Commands.ContainsKey(currentToken);
        }

        protected LexerState EndLine()
        {
            endOfLine = true;
            return LexerState.None;
        }

        public DosjunEditor.Context Context { get; private set; }
        public string Filename { get; private set; }
        public LexerState State { get; private set; }
        public List<Token> Tokens { get; private set; }
        public int Line { get; private set; }
        public int Column { get; private set; }
        public string CurrentLine { get; private set; }

        private LexerState StateNone(char ch, LexerState guess)
        {
            switch (guess)
            {
                case LexerState.CommentStart:
                case LexerState.EndOfLine:
                    return EndLine();

                case LexerState.Internal:
                case LexerState.String:
                case LexerState.Separator:
                    return guess;

                case LexerState.LeftParens:
                case LexerState.RightParens:
                    AddParenthesis(ch);
                    return State;

                case LexerState.KeywordOrIdent:
                case LexerState.Number:
                case LexerState.Operator:
                    Append(ch);
                    return guess;

                case LexerState.Reference:
                    return guess;

                case LexerState.Whitespace:
                    return State;

                default: throw new TokenizationException($"Invalid transition: {State} => {guess}");
            }
        }

        private LexerState StateKeyword(char ch, LexerState guess)
        {
            switch (guess)
            {
                case LexerState.CommentStart:
                case LexerState.EndOfLine:
                    AddKeywordToken();
                    return EndLine();

                case LexerState.KeywordOrIdent:
                case LexerState.Number:
                    Append(ch);
                    return State;

                case LexerState.Whitespace:
                    AddKeywordToken();
                    return afterWord;

                case LexerState.Separator:
                case LexerState.Operator:
                case LexerState.RightParens:
                    AddKeywordToken();
                    Rewind();
                    return afterWord;

                case LexerState.LeftParens:
                    AddKeywordToken();
                    Append(ch);
                    AddOperatorToken();
                    return LexerState.ArgumentList;

                default: throw new TokenizationException($"Invalid transition: {State} => {guess}");
            }
        }

        private LexerState StateOperator(char ch, LexerState guess)
        {
            switch (guess)
            {
                // some operators are multi-character
                case LexerState.Operator:
                    Append(ch);
                    return State;

                case LexerState.Internal:
                case LexerState.KeywordOrIdent:
                case LexerState.Number:
                case LexerState.String:
                case LexerState.LeftParens:
                    Rewind();
                    AddOperatorToken();
                    return afterWord;

                case LexerState.Whitespace:
                    AddOperatorToken();
                    return afterWord;

                default: throw new TokenizationException($"Invalid transition: {State} => {guess}");
            }
        }

        private LexerState StateNumber(char ch, LexerState guess)
        {
            switch (guess)
            {
                case LexerState.Number:
                    Append(ch);
                    return State;

                case LexerState.CommentStart:
                case LexerState.EndOfLine:
                    AddToken(TokenType.Number);
                    return EndLine();

                case LexerState.Whitespace:
                    AddToken(TokenType.Number);
                    return afterWord;

                case LexerState.Separator:
                case LexerState.Operator:
                case LexerState.RightParens:
                    AddToken(TokenType.Number);
                    Rewind();
                    return afterWord;

                default: throw new TokenizationException($"Invalid transition: {State} => {guess}");
            }
        }

        private LexerState StateSeparator(char ch, LexerState guess)
        {
            switch (guess)
            {
                case LexerState.Internal:
                case LexerState.KeywordOrIdent:
                case LexerState.Number:
                case LexerState.String:
                    AddToken(TokenType.Separator, ",");
                    Rewind();
                    return afterWord;

                case LexerState.Whitespace:
                    AddToken(TokenType.Separator, ",");
                    return afterWord;

                default: throw new TokenizationException($"Invalid transition: {State} => {guess}");
            }
        }

        private LexerState StateString(char ch, LexerState guess)
        {
            switch (ch)
            {
                case '\\': return LexerState.StringEscape;

                case '"':
                    AddToken(TokenType.String);
                    return afterWord;

                default:
                    if (guess == LexerState.EndOfLine)
                        throw new TokenizationException("EOL during string literal");
                    Append(ch);
                    return State;
            }
        }

        private LexerState StateStringEscape(char ch, LexerState guess)
        {
            switch (ch)
            {
                case 'n':
                    Append('\n');
                    return LexerState.String;

                default:
                    if (guess == LexerState.EndOfLine)
                        throw new TokenizationException("EOL during string literal");
                    Append(ch);
                    return LexerState.String;
            }
        }

        private LexerState StateInternal(char ch, LexerState guess)
        {
            switch (guess)
            {
                case LexerState.KeywordOrIdent:
                case LexerState.Number:
                    Append(ch);
                    return State;

                case LexerState.Whitespace:
                    AddToken(TokenType.Internal);
                    return afterWord;

                case LexerState.EndOfLine:
                case LexerState.CommentStart:
                    AddToken(TokenType.Internal);
                    return EndLine();

                case LexerState.Operator:
                case LexerState.Separator:
                case LexerState.RightParens:
                    AddToken(TokenType.Internal);
                    Rewind();
                    return afterWord;

                default: throw new TokenizationException($"Invalid character in internal: {ch}");
            }
        }

        private LexerState StateReference(char ch, LexerState guess)
        {
            switch (guess)
            {
                case LexerState.KeywordOrIdent:
                case LexerState.Number:
                    Append(ch);
                    return State;

                case LexerState.Whitespace:
                    AddToken(TokenType.Reference);
                    return afterWord;

                case LexerState.EndOfLine:
                case LexerState.CommentStart:
                    AddToken(TokenType.Reference);
                    return EndLine();

                case LexerState.Operator:
                case LexerState.Separator:
                case LexerState.RightParens:
                    AddToken(TokenType.Reference);
                    Rewind();
                    return afterWord;

                default: throw new TokenizationException($"Invalid character in reference: {ch}");
            }
        }

        private LexerState StateArgumentList(char ch, LexerState guess)
        {
            afterWord = LexerState.ArgumentList;

            switch (guess)
            {
                case LexerState.KeywordOrIdent:
                case LexerState.Number:
                case LexerState.Operator:
                case LexerState.Separator:
                    Append(ch);
                    return guess;

                case LexerState.Reference:
                case LexerState.Internal:
                    return guess;

                case LexerState.Whitespace:
                    return State;

                case LexerState.LeftParens:
                    parensDepth++;
                    AddToken(TokenType.LeftParens, "(");
                    return State;

                case LexerState.RightParens:
                    if (parensDepth > 0)
                    {
                        parensDepth--;
                        AddToken(TokenType.RightParens, ")");
                        return State;
                    }

                    Append(ch);
                    AddOperatorToken();
                    afterWord = LexerState.None;
                    return afterWord;

                default: throw new TokenizationException($"Invalid character in argument list: {ch}");
            }
        }
    }
}
