using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class InventoryEdit : UserControl
    {
        private Context context;
        private InventoryItem item;

        public InventoryEdit()
        {
            InitializeComponent();

            foreach (string name in Tools.GetEnumNames<ItemSlot>())
                SlotBox.Items.Add(name);
        }

        public Context Context
        {
            get => context;
            set
            {
                context = value;
                LoadContext();
            }
        }

        public InventoryItem Item
        {
            get => item;
            set
            {
                item = value;
                LoadItem();
            }
        }

        public void Apply()
        {
            item.ItemId = (ItemBox.SelectedItem as Resource).ID;
            item.Quantity = (byte)QtyBox.Value;
            item.Slot = (ItemSlot)SlotBox.SelectedIndex;
            item.Flags = item.Slot == ItemSlot.None ? InventoryFlags.None : InventoryFlags.Equipped;
        }

        private void LoadContext()
        {
            Globals.Populate(ItemBox, context.Djn.Items);
        }

        private void LoadItem()
        {
            ItemBox.SelectedItem = Globals.Resolve(context, item.ItemId);
            QtyBox.Value = item.Quantity;
            SlotBox.SelectedIndex = (int)item.Slot;
        }

        private void InventoryEdit_Resize(object sender, EventArgs e)
        {
            int totalWidth = Width - 12;
            int itemWidth = (int)(totalWidth * 0.55);
            int qtyWidth = (int)(totalWidth * 0.2);
            int slotWidth = totalWidth - itemWidth - qtyWidth;

            ItemBox.Width = itemWidth;

            QtyBox.Width = qtyWidth;
            QtyBox.Left = itemWidth + 6;

            SlotBox.Width = slotWidth;
            SlotBox.Left = itemWidth + qtyWidth + 12;
        }

        private void ItemBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemBox.SelectedIndex == 0)
            {
                QtyBox.Minimum = 0;
                QtyBox.Maximum = 0;
            }
            else
            {
                Item i = Context.Djn[(ItemBox.SelectedItem as Resource).ID] as Item;

                QtyBox.Minimum = 1;
                QtyBox.Maximum = i.Flags.HasFlag(ItemFlags.Stacked) ? 255 : 1;

                // TODO: change slot based on item type?
            }
        }
    }
}
