using DosjunEditor.Cartographer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DosjunEditor.Controls
{
    public partial class ToolPalette : UserControl
    {
        private List<CheckBox> checkboxes = new List<CheckBox>();
        private List<ITool> tools = new List<ITool>();
        private ITool current = null;

        public event EventHandler ToolChanged;

        public ToolPalette()
        {
            InitializeComponent();
        }

        public ITool Current
        {
            get => current;
            set
            {
                current = value;
                SetTool(current);
            }
        }

        public void Add(ITool tool)
        {
            CheckBox chk = new CheckBox
            {
                Appearance = Appearance.Button,
                Dock = DockStyle.Left,
                Tag = tool,
                Text = tool.Name,
                TextAlign = ContentAlignment.MiddleCenter,
            };

            chk.Click += ToolButton_Click;

            if (tools.Count == 0)
            {
                current = tool;
                chk.Checked = true;
            }

            checkboxes.Add(chk);
            tools.Add(tool);
            Controls.Add(chk);
        }

        private void ToolButton_Click(object sender, EventArgs e)
        {
            if ((sender as Control).Tag is ITool tool)
                Current = tool;
        }

        private void SetTool(ITool tool)
        {
            foreach (CheckBox chk in checkboxes)
                chk.Checked = chk.Tag == tool;

            if (current != null)
                current.Activate();

            ToolChanged?.Invoke(this, null);
        }
    }
}
