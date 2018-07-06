﻿using System.Collections.Generic;
using DosjunEditor.Jun.Ex;

namespace DosjunEditor.Jun.Cmd
{
    class EndIf : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(EndIf);
        public Argument[] Args => new Argument[0];
        public Argument Returns => Argument.Null;
        public Op Op => Op.NOP;

        public void Apply(Parser p, Dictionary<string, Token> a)
        {
            if (p.Contexts.Count == 0)
                throw new ScopeException("EndIf without If");

            p.ResolveJump();
            p.ResolveOffsets();
            p.Contexts.Pop();
        }
    }
}
