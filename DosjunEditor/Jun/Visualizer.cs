using System;
using System.Collections.Generic;

namespace DosjunEditor.Jun
{
    public static class Visualizer
    {
        static Dictionary<Op, int> opArgs = new Dictionary<Op, int>
        {
            { Op.Jump, 2 },
            { Op.JumpFalse, 2 },
            { Op.PopFlag, 2 },
            { Op.PopGlobal, 2 },
            { Op.PopLocal, 2 },
            { Op.PopTemp, 1 },
            { Op.PushFlag, 2 },
            { Op.PushGlobal, 2 },
            { Op.PushInternal, 1 },
            { Op.PushLiteral, 2 },
            { Op.PushLocal, 2 },
            { Op.PushTemp, 1 },
        };

        public static string Show(IEnumerable<Token> tokens)
        {
            string prog = string.Empty;

            foreach (Token tok in tokens)
            {
                if (tok.Type == TokenType.EOL)
                {
                    prog += '\n';
                    continue;
                }

                prog += $"{tok} ";
            }

            return prog;
        }

        public static string Show(byte[] code, string name)
        {
            string prog = string.Empty;
            int offset = 0;
            prog += $"*** {name}\n";

            while (offset < code.Length)
            {
                Op op = (Op)code[offset];
                string opName = Enum.GetName(typeof(Op), op);

                prog += $"{offset:X4} {opName}";
                offset++;

                int bytes = opArgs.ContainsKey(op) ? opArgs[op] : 0;
                if (bytes == 1)
                {
                    prog += $" {code[offset]:X2}";
                    offset++;
                }
                else if (bytes == 2)
                {
                    byte a = code[offset];
                    byte b = code[offset + 1];
                    prog += $" {b:X2}{a:X2}";
                    offset += 2;
                }

                prog += '\n';
            }

            return prog;
        }

        public static string Show(IEnumerable<Script> scripts)
        {
            string prog = string.Empty;

            foreach (Script script in scripts)
                prog += Show(script.Code.ToArray(), script.Name);

            return prog;
        }
    }
}
