using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class StatsEditor : UserControl
    {
        private Dictionary<Stat, Row> rows;

        public StatsEditor()
        {
            InitializeComponent();

            rows = new Dictionary<Stat, Row>();
            int i = 0;
            foreach (Stat st in Enum.GetValues(typeof(Stat)))
            {
                rows.Add(st, new Row(TableLayout, i, st));
                i++;
            }
        }

        public Stats Stats { get; set; }

        public void Apply()
        {
            foreach (Stat st in Enum.GetValues(typeof(Stat)))
            {
                Stats[st] = (short)rows[st].Box.Value;
            }
        }

        public void UpdateFields()
        {
            if (Stats == null) return;

            foreach (Stat st in Enum.GetValues(typeof(Stat)))
                rows[st].Box.Value = Stats[st];
        }
        
        private class Row
        {
            public Label NameLabel;
            public NumericUpDown Box;

            public Row(TableLayoutPanel panel, int i, Stat st)
            {
                NameLabel = new Label
                {
                    Dock = DockStyle.Fill,
                    Text = st.ToString(),
                    TextAlign = ContentAlignment.MiddleLeft,
                };

                Box = new NumericUpDown
                {
                    Dock = DockStyle.Fill,
                    Minimum = short.MinValue,
                    Maximum = short.MaxValue,
                };

                panel.Controls.Add(NameLabel, 0, i);
                panel.Controls.Add(Box, 1, i);
            }

            public short Value => (short)Box.Value;
        }
    }
}
