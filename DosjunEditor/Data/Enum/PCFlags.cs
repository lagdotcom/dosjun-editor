using System;

namespace DosjunEditor
{
    [Flags]
    public enum PCFlags : byte
    {
        None = 0,
        BackRow = 1,
        InParty = 2,
    }
}
