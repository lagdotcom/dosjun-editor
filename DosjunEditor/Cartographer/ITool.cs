namespace DosjunEditor.Cartographer
{
    public interface ITool
    {
        string Name { get; }

        void Apply(Tile tile);
        void Apply(Tile tile, Wall wall);
    }
}
