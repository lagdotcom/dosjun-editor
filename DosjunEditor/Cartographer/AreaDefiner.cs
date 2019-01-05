using DosjunEditor.Controls;
using System.Windows.Forms;

namespace DosjunEditor.Cartographer
{
    class AreaDefiner : ITool
    {
        private AreaDefinerOptions options;

        public AreaDefiner(Zone z, Context ctx)
        {
            Context = ctx;
            options = new AreaDefinerOptions();
            options.Setup(z, ctx);
        }

        public Context Context { get; private set; }
        public Control Options => options;

        public string Name => "Area Definer";

        public void Activate() { }

        public void Apply(Tile tile)
        {
            Wip.ZoneArea area = options.CurrentArea;

            if (area != null)
            {
                if (!area.Contains(tile.X, tile.Y))
                {
                    area.Add(tile.X, tile.Y);
                    Context.UnsavedChanges = true;
                }
                else
                {
                    area.Remove(tile.X, tile.Y);
                    Context.UnsavedChanges = true;
                }
            }
        }

        public void Apply(Tile tile, Wall wall)
        {
            Apply(tile);
        }
    }
}
