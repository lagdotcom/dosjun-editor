﻿using System.Collections.Generic;

namespace DosjunEditor.Jun.Cmd
{
    class PcAction : ICmd
    {
        private readonly Argument[] args = new Argument[]
        {
            new Argument("PC", ArgumentType.PC),
            new Argument("String", ArgumentType.String),
        };

        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(PcAction);
        public Argument[] Args => args;
        public Argument Returns => Argument.Null;
        public Op Op => Op.PcAction;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            p.EmitArgument(a["PC"]);
            p.EmitArgument(a["String"]);
            p.Emit(Op);
        }
    }
}
