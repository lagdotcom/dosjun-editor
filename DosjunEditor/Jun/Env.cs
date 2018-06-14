using System;
using System.Collections.Generic;
using System.Linq;

namespace DosjunEditor.Jun
{
    public static class Env
    {
        private static bool initialised;

        public static Dictionary<string, Internal> Internals { get; private set; }
        public static Dictionary<string, ICmd> Commands { get; private set; }
        
        public static Dictionary<string, TokenType> Operators = new Dictionary<string, TokenType>
        {
            ["=="] = TokenType.Equals,
            ["!="] = TokenType.NotEqual,
            ["<="] = TokenType.LTE,
            [">="] = TokenType.GTE,
            ["<"] = TokenType.LT,
            [">"] = TokenType.GT,
            ["="] = TokenType.Assignment,
            ["+"] = TokenType.Add,
            ["-"] = TokenType.Subtract,
            ["*"] = TokenType.Multiply,
            ["/"] = TokenType.Divide,
            ["&"] = TokenType.And,
            ["|"] = TokenType.Or,
        };

        public static Dictionary<TokenType, Op> Comparators = new Dictionary<TokenType, Op>
        {
            [TokenType.Add] = Op.Add,
            [TokenType.And] = Op.And,
            [TokenType.Divide] = Op.Div,
            [TokenType.Equals] = Op.EQ,
            [TokenType.GT] = Op.GT,
            [TokenType.GTE] = Op.GTE,
            [TokenType.LT] = Op.LT,
            [TokenType.LTE] = Op.LTE,
            [TokenType.Multiply] = Op.Mul,
            [TokenType.NotEqual] = Op.NEQ,
            [TokenType.Or] = Op.Or,
            [TokenType.Subtract] = Op.Sub,
        };

        public static Dictionary<TokenType, int> Precedence = new Dictionary<TokenType, int>
        {
            [TokenType.Divide] = 3,
            [TokenType.Multiply] = 3,
            [TokenType.Add] = 4,
            [TokenType.Subtract] = 4,
            [TokenType.GT] = 6,
            [TokenType.GTE] = 6,
            [TokenType.LT] = 6,
            [TokenType.LTE] = 6,
            [TokenType.Equals] = 7,
            [TokenType.NotEqual] = 7,
            [TokenType.And] = 8,
            [TokenType.Or] = 10,
            [TokenType.LeftParens] = 100,
        };

        public static Dictionary<string, short> Constants = new Dictionary<string, short>
        {
            ["NORTH"] = (short)Direction.North,
            ["EAST"] = (short)Direction.East,
            ["SOUTH"] = (short)Direction.South,
            ["WEST"] = (short)Direction.West,
            ["UP"] = (short)Direction.Up,
            ["DOWN"] = (short)Direction.Down,

            ["FIGHTER"] = (short)Job.Fighter,
            ["CLERIC"] = (short)Job.Cleric,
            ["MAGE"] = (short)Job.Mage,
            ["ROGUE"] = (short)Job.Rogue,
            ["RANGER"] = (short)Job.Ranger,
            ["BARD"] = (short)Job.Bard,
        };

        public static void Initialise()
        {
            if (initialised)
                return;

            // Load ICmds
            var type = typeof(ICmd);
            Commands = new Dictionary<string, ICmd>();
            foreach (var ctype in AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract))
            {
                ICmd cmd = (ICmd)Activator.CreateInstance(ctype);
                Commands[cmd.Name] = cmd;
            }

            // Load Internals
            Internals = new Dictionary<string, Internal>();
            foreach (string name in Tools.GetEnumNames<Internal>())
                Internals[name] = (Internal)Enum.Parse(typeof(Internal), name);

            initialised = true;
        }
    }
}
