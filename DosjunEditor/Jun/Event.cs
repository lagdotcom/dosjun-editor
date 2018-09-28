namespace DosjunEditor.Jun
{
    public enum Event : short
    {
        PartyMoved = 10,
        PartyTurned,
        ZoneEntered,
        ZoneExited,
        ItemDropped,
        ItemTaken,

        CombatantDamaged = 100,
        CombatEntered,
        CombatExited,
        CombatTurnEnded,
        MonsterDied,

        PCDied = 200,
        PCLevelGained,
    }
}
