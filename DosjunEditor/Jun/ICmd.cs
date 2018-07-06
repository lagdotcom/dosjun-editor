using System.Collections.Generic;

namespace DosjunEditor.Jun
{
    public interface ICmd
    {
        bool IsGlobal { get; }
        bool IsScript { get; }
        string Name { get; }
        Op Op { get; }
        Argument[] Args { get; }
        Argument Returns { get; }

        void Apply(Parser p, Dictionary<string, Token> arguments);
    }
}
