using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class StatsEditor : UserControl
    {
        private Stats stats;

        public StatsEditor()
        {
            InitializeComponent();
        }

        public Stats Stats
        {
            get => stats;
            set
            {
                stats = value;
                if (stats != null)
                    UpdateFields();
            }
        }

        public void Apply()
        {
            stats.MaxHP = (short)MaxHPBox.Value;
            stats.MaxMP = (short)MaxMPBox.Value;
            stats.MinDamage = (short)MinDamageBox.Value;
            stats.MaxDamage = (short)MaxDamageBox.Value;
            stats.Armour = (short)ArmourBox.Value;
            stats.Strength = (short)StrengthBox.Value;
            stats.Dexterity = (short)DexterityBox.Value;
            stats.Intelligence = (short)IntelligenceBox.Value;
            stats.HP = (short)HPBox.Value;
            stats.HP = (short)HPBox.Value;
        }

        private void UpdateFields()
        {
            MaxHPBox.Value = stats.MaxHP;
            MaxMPBox.Value = stats.MaxMP;
            MinDamageBox.Value = stats.MinDamage;
            MaxDamageBox.Value = stats.MaxDamage;
            ArmourBox.Value = stats.Armour;
            StrengthBox.Value = stats.Strength;
            DexterityBox.Value = stats.Dexterity;
            IntelligenceBox.Value = stats.Intelligence;
            HPBox.Value = stats.HP;
            MPBox.Value = stats.MP;
        }
    }
}
