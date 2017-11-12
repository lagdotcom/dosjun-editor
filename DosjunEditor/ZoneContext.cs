using System;

namespace DosjunEditor
{
    public class ZoneContext
    {
        private bool unsavedChanges;

        public Campaign Campaign { get; set; }
        public Monsters Monsters { get; set; }
        public Zone Zone { get; set; }
        public string[] ScriptNames { get; set; }

        public bool UnsavedChanges
        {
            get => unsavedChanges;
            set
            {
                if (value != unsavedChanges)
                {
                    unsavedChanges = value;
                    UnsavedChangesChanged?.Invoke(this, null);
                }
            }
        }

        public event EventHandler EncountersChanged;
        public event EventHandler UnsavedChangesChanged;

        public void UpdateEncounters()
        {
            EncountersChanged?.Invoke(this, null);
        }
    }
}
