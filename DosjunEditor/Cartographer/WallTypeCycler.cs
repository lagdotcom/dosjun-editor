using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DosjunEditor.Cartographer
{
    public class WallTypeCycler : ITool
    {
        public WallTypeCycler(Context ctx)
        {
            Context = ctx;
        }

        public Context Context { get; private set; }
        public string Name => "Change Wall";

        public void Apply(Tile tile) { }

        public void Apply(Tile tile, Wall wall)
        {
            if (wall.TextureId == 0)
            {
                wall.TextureId = Context.Djn.Textures.FirstOrDefault()?.Resource.ID ?? 0;
                wall.Type = WallType.Normal;
            }
            else
            {
                wall.Type += 1;
                if (wall.Type == WallType.Invalid)
                {
                    wall.TextureId = 0;
                    wall.Type = WallType.Normal;
                }
            }
        }
    }
}
