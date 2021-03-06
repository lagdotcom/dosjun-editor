﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DosjunEditor.Jun
{
    public static class Env
    {
        private static bool initialised;

        public static int MaxGlobals => short.MaxValue;
        public static int MaxFlags => short.MaxValue;
        public static int MaxLocals => short.MaxValue;

        public const short SelectAll = 0;
        public const short SelectAllies = 1;
        public const short SelectEnemies = 2;
        public const short SelectRandom = -1;

        public const short FilterAlive = 0;
        public const short FilterRange = 1;
        public const short FilterHPBelow = 2;

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
            ["!"] = TokenType.Invert,
            ["("] = TokenType.ArgumentListBegin,
            [")"] = TokenType.ArgumentListEnd,
        };

        public static Dictionary<TokenType, Op> Comparators = new Dictionary<TokenType, Op>
        {
            [TokenType.Add] = Op.Add,
            [TokenType.And] = Op.And,
            [TokenType.Divide] = Op.Div,
            [TokenType.Equals] = Op.EQ,
            [TokenType.GT] = Op.GT,
            [TokenType.GTE] = Op.GTE,
            [TokenType.Invert] = Op.Invert,
            [TokenType.LT] = Op.LT,
            [TokenType.LTE] = Op.LTE,
            [TokenType.Multiply] = Op.Mul,
            [TokenType.NotEqual] = Op.NEQ,
            [TokenType.Or] = Op.Or,
            [TokenType.Subtract] = Op.Sub,
        };

        public static Dictionary<TokenType, int> Precedence = new Dictionary<TokenType, int>
        {
            [TokenType.Invert] = 1,
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

        public static Dictionary<string, short> Constants = new Dictionary<string, short>();

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

            // Load Constants
            ImportConstants<Direction>();
            ImportConstants<Job>();
            ImportConstants<Event>();
            ImportConstants<ListenerExpiry>();
            ImportConstants<Action>();

            initialised = true;
        }

        private static void ImportConstants<T>()
        {
            Type enumType = typeof(T);
            string[] names = Enum.GetNames(enumType);
            int index = 0;

            foreach (var v in Enum.GetValues(enumType))
                Constants[names[index++].ToUpper()] = Convert.ToInt16(v);
        }
    }
}
