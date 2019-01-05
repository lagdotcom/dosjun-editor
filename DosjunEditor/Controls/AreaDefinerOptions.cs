using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DosjunEditor.Controls
{
    public partial class AreaDefinerOptions : UserControl
    {
        public AreaDefinerOptions()
        {
            InitializeComponent();
        }

        public Context Context { get; private set; }
        public Wip.ZoneArea CurrentArea { get; private set; }
        public Wip Wip => Context.Djn.Wip;
        public Zone Zone { get; private set; }
        public Wip.ZoneData ZoneData => Wip.Zones[Zone.Resource.ID];

        public event EventHandler Changed;

        public void Setup(Zone z, Context ctx)
        {
            Context = ctx;
            Zone = z;

            if (!Wip.Zones.ContainsKey(Zone.Resource.ID))
                Wip.Zones.Add(Zone.Resource.ID, new Wip.ZoneData());

            foreach (var area in ZoneData.Areas)
                AreaList.Items.Add(area);
        }

        public void Select(Wip.ZoneArea area)
        {
            AreaList.SelectedItem = area;
            CurrentArea = area;

            DeleteButton.Enabled = area != null;
            RenameButton.Enabled = area != null;

            Changed?.Invoke(this, null);
        }

        private void AddArea_Click(object sender, EventArgs e)
        {
            StringDialog dlg = new StringDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Wip.ZoneArea area = new Wip.ZoneArea { Name = dlg.String };
                ZoneData.Areas.Add(area);
                Context.UnsavedChanges = true;

                AreaList.Items.Add(area);
                Select(area);
            }
        }

        private void AreaList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Select(AreaList.SelectedItem as Wip.ZoneArea);
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            StringDialog dlg = new StringDialog { String = CurrentArea.Name };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CurrentArea.Name = dlg.String;
                Context.UnsavedChanges = true;

                AreaList.Items[AreaList.SelectedIndex] = CurrentArea;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            ZoneData.Areas.Remove(CurrentArea);
            Context.UnsavedChanges = true;

            AreaList.Items.Remove(CurrentArea);
            Select(null);
        }
    }
}
