using System;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class ItemForm : Form, IResourceEditor
    {
        public ItemForm()
        {
            InitializeComponent();

            foreach (string name in Tools.GetEnumNames<ItemType>())
                TypeBox.Items.Add(name);

            foreach (string name in Tools.GetEnumNames<ItemSpecial>())
                SpecialBox.Items.Add(name);
        }

        public event EventHandler Saved;

        public Context Context { get; private set; }
        public Item Item { get; private set; }
        public IHasResource Editing => Item;

        public void Setup(Context ctx, IHasResource r)
        {
            Context = ctx;
            Item = r as Item;

            NameBox.Text = ctx.GetString(Item.NameId);

            TypeBox.SelectedIndex = (int)Item.Type;

            ValueBox.Value = Item.Value;

            SpecialBox.SelectedIndex = (int)Item.Special;
            SArg1Box.Value = Item.SpecialArg1;
            SArg2Box.Value = Item.SpecialArg2;

            StatsBoxes.Stats = Item.Stats;

            LightFlag.Checked = Item.Flags.HasFlag(ItemFlags.Light);
            HeavyFlag.Checked = Item.Flags.HasFlag(ItemFlags.Heavy);
            StackedFlag.Checked = Item.Flags.HasFlag(ItemFlags.Stacked);
            MediumFlag.Checked = Item.Flags.HasFlag(ItemFlags.MediumRange);
            LongFlag.Checked = Item.Flags.HasFlag(ItemFlags.LongRange);
            DexterityFlag.Checked = Item.Flags.HasFlag(ItemFlags.DexterityWeapon);
        }

        public void Apply()
        {
            Item.NameId = Context.GetStringId(NameBox.Text, Item.NameId);
            Item.Type = (ItemType)TypeBox.SelectedIndex;
            Item.Value = (uint)ValueBox.Value;
            Item.Special = (ItemSpecial)SpecialBox.SelectedIndex;
            Item.SpecialArg1 = (short)SArg1Box.Value;
            Item.SpecialArg2 = (short)SArg2Box.Value;
            StatsBoxes.Apply();

            ItemFlags fl = ItemFlags.None;
            if (LightFlag.Checked) fl |= ItemFlags.Light;
            if (HeavyFlag.Checked) fl |= ItemFlags.Heavy;
            if (StackedFlag.Checked) fl |= ItemFlags.Stacked;
            if (MediumFlag.Checked) fl |= ItemFlags.MediumRange;
            if (LongFlag.Checked) fl |= ItemFlags.LongRange;
            if (DexterityFlag.Checked) fl |= ItemFlags.DexterityWeapon;
            Item.Flags = fl;

            Saved?.Invoke(this, null);
        }

        private void SetupArguments(string label1, bool vis1, string label2, bool vis2)
        {
            SArg1Label.Text = label1;
            SArg1Label.Visible = vis1;
            SArg1Box.Visible = vis1;

            SArg2Label.Text = label2;
            SArg2Label.Visible = vis2;
            SArg2Box.Visible = vis2;
        }

        private void SpecialBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((ItemSpecial)SpecialBox.SelectedIndex)
            {
                case ItemSpecial.None:
                    SetupArguments("-", false, "-", false);
                    return;

                case ItemSpecial.Heal:
                    SetupArguments("Minimum", true, "Maximum", true);
                    return;
            }
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            Apply();
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
