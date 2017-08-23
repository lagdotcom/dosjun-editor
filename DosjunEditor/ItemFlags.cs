using System;

namespace DosjunEditor
{
    [Flags]
    public enum ItemFlags : ushort
    {
        None = 0,

        Light = 1,
        Heavy = 2,
        Stacked = 4,
        MediumRange = 8,
        LongRange = 16,
        DexterityWeapon = 32
    }
}
