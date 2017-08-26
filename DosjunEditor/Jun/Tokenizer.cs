using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DosjunEditor.Jun
{
    public class Tokenizer
    {
        private Dictionary<LexerState, ILexerState> stateMachine;
        private bool endOfLine;
        private string currentToken;

        public Tokenizer()
        {
            Tokens = new List<Token>();
            stateMachine = new Dictionary<LexerState, ILexerState>
            {
                [LexerState.None] = new Lex.None { Parent = this },
                [LexerState.String] = new Lex.String { Parent = this },
                [LexerState.StringEscape] = new Lex.StringEscape { Parent = this },
                [LexerState.Internal] = new Lex.Internal { Parent = this },
                [LexerState.Number] = new Lex.Number { Parent = this },
                [LexerState.KeywordOrIdent] = new Lex.Keyword { Parent = this },
                [LexerState.Operator] = new Lex.Operator { Parent = this }
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
            Line = -1;
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
                    State = stateMachine[State].Process(ch, guess);
                }

                // process end of line in case something is missing
                stateMachine[State].Process('\n', LexerState.EndOfLine);

                // special handling for 'Include'
                if (Tokens.Count >= 2 && Tokens[Tokens.Count - 2].Value == "Include")
                {
                    Token filename = Tokens[Tokens.Count - 1];
                    Tokens.RemoveRange(Tokens.Count - 2, 2);

                    Tokenizer jt = new Tokenizer();
                    jt.Tokenize(Path.GetDirectoryName(Filename) + Path.DirectorySeparatorChar + filename.Value);
                    Tokens.AddRange(jt.Tokens);
                }
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
                case '#':   return LexerState.CommentStart;
                case '\\':  return LexerState.StringEscape;
                case '"':   return LexerState.String;
                case '@':   return LexerState.Internal;

                case '0': case '1': case '2': case '3': case '4':
	            case '5': case '6': case '7': case '8': case '9':
                    return LexerState.Number;

                case '=':
                case '!':
                case '>':
                case '<':
                    return LexerState.Operator;

                case ' ':
                case '\t':
                case ',':
                    return LexerState.Whitespace;

                case '\n':
                case '\r':
                case '\0':
                    return LexerState.EndOfLine;

                case 'a': case 'b': case 'c': case 'd': case 'e':
	            case 'f': case 'g': case 'h': case 'i': case 'j':
	            case 'k': case 'l': case 'm': case 'n': case 'o':
	            case 'p': case 'q': case 'r': case 's': case 't':
	            case 'u': case 'v': case 'w': case 'x': case 'y': case 'z':
	            case 'A': case 'B': case 'C': case 'D': case 'E':
	            case 'F': case 'G': case 'H': case 'I': case 'J':
	            case 'K': case 'L': case 'M': case 'N': case 'O':
	            case 'P': case 'Q': case 'R': case 'S': case 'T':
	            case 'U': case 'V': case 'W': case 'X': case 'Y': case 'Z':
	            case '_':
                    return LexerState.KeywordOrIdent;
            }

            return LexerState.None;
        }

        public char Next()
        {
            char ch = CurrentLine[Column];
            Column++;

            if (Column >= CurrentLine.Length) endOfLine = true;
            return ch;
        }

        public Exception Error(string message)
        {
            return new CodeException($"{message}\nline {Line}, column {Column}");
        }

        public void Append(char ch)
        {
            currentToken += ch;
        }

        public void Rewind()
        {
            Column--;
        }

        public void AddToken(TokenType tt)
        {
            if (!string.IsNullOrWhiteSpace(currentToken))
            {
                Tokens.Add(new Token { Type = tt, Value = currentToken });
                currentToken = string.Empty;
            }
        }

        public bool IsKeyword()
        {
            return Env.Keywords.Contains(currentToken);
        }

        public void EndLine()
        {
            endOfLine = true;
        }

        public string Filename { get; private set; }
        public LexerState State { get; private set; }
        public List<Token> Tokens { get; private set; }
        public int Line { get; private set; }
        public int Column { get; private set; }
        public string CurrentLine { get; private set; }
    }
}
