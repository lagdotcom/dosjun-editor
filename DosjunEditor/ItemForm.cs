using System;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class ItemForm : Form
    {
        public ItemForm()
        {
            InitializeComponent();

            foreach (string name in Tools.GetNames<ItemType>())
                TypeBox.Items.Add(name);

            foreach (string name in Tools.GetNames<ItemSpecial>())
                SpecialBox.Items.Add(name);
        }

        public Campaign Campaign { get; private set; }
        public Item Item { get; private set; }

        public void Setup(Campaign campaign, Item it)
        {
            Campaign = campaign;
            Item = it;

            IDBox.Value = it.Id;

            NameBox.Text = it.Name;

            TypeBox.SelectedIndex = (int)it.Type;

            ValueBox.Value = it.Value;

            SpecialBox.SelectedIndex = (int)it.Special;
            SArg1Box.Value = it.SpecialArg1;
            SArg2Box.Value = it.SpecialArg2;

            StatsBoxes.Stats = it.Stats;

            LightFlag.Checked = it.Flags.HasFlag(ItemFlags.Light);
            HeavyFlag.Checked = it.Flags.HasFlag(ItemFlags.Heavy);
            StackedFlag.Checked = it.Flags.HasFlag(ItemFlags.Stacked);
            MediumFlag.Checked = it.Flags.HasFlag(ItemFlags.MediumRange);
            LongFlag.Checked = it.Flags.HasFlag(ItemFlags.LongRange);
            DexterityFlag.Checked = it.Flags.HasFlag(ItemFlags.DexterityWeapon);
        }

        public void Apply()
        {
            Item.Id = (ushort)IDBox.Value;
            Item.Name = NameBox.Text;
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
    }
}
