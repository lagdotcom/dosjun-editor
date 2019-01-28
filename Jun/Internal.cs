namespace Jun
{
    public enum Internal : byte
    {
        X = 0,
        Y,
        Facing,
        Danger,
        JustMoved,
        SuccessUNUSED,
        ReturnUNUSED,
        PartyFull,
        Zone,
        EventAttacker,
        EventTarget,
        EventPC,
        EventItem,
        Steps,
        Hours,
        Minutes,

        Self = 0xE0,
        Target,

        Invalid = 0xFF
    }
}
