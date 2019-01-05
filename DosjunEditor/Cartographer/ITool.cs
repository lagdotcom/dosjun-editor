using System.Windows.Forms;

namespace DosjunEditor.Cartographer
{
    public interface ITool
    {
        Control Options { get; }
        string Name { get; }

        void Activate();
        void Deactivate();

        void Apply(Tile tile);
        void Apply(Tile tile, Wall wall);
    }
}
