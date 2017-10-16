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
            stats.MP = (short)MPBox.Value;
            stats.HitBonus = (short)HitBonusBox.Value;
            stats.DodgeBonus = (short)DodgeBonusBox.Value;
            stats.Unused1 = (short)U1Box.Value;
            stats.Unused2 = (short)U2Box.Value;
            stats.Unused3 = (short)U3Box.Value;
            stats.Unused4 = (short)U4Box.Value;
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
            HitBonusBox.Value = stats.HitBonus;
            DodgeBonusBox.Value = stats.DodgeBonus;
            U1Box.Value = stats.Unused1;
            U2Box.Value = stats.Unused2;
            U3Box.Value = stats.Unused3;
            U4Box.Value = stats.Unused4;
        }
    }
}
