namespace DosjunEditor
{
    public enum ResourceType : byte
    {
        Unknown,

        Campaign,
        Zone,
        NPC,
        PC,
        Script,
        Source,
        Graphic,
        Music,
        Sound,
        Item,
        Monster,
        Font__Unused,
        Strings,
        Palette,
        DropTable,

        Party = 0xC0,
        Globals,
        Overlay,
    }
}
