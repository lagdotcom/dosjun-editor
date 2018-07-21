using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class ItemPosForm : Form
    {
        public ItemPosForm()
        {
            InitializeComponent();
        }

        public Context Context { get; private set; }
        public ItemPos Editing { get; private set; }

        public void Setup(Context ctx, ItemPos ip)
        {
            Context = ctx;
            Editing = ip;

            Globals.Populate(ItemBox, Context.Djn.Items);

            ItemBox.SelectedItem = Globals.Resolve(Context, Editing.ItemId);
            XBox.Value = Editing.TileX;
            YBox.Value = Editing.TileY;
        }

        public void Apply()
        {
            Editing.ItemId = (ItemBox.SelectedItem as Resource).ID;
            Editing.TileX = (byte)XBox.Value;
            Editing.TileY = (byte)YBox.Value;
        }
    }
}
