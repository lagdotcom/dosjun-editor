using System;

namespace DosjunEditor
{
    public class Context
    {
        private bool unsavedChanges;

        public Djn Djn { get; set; }

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

        public string GetString(ushort id)
        {
            if (id == 0) return string.Empty;

            return Djn.Strings[id];
        }

        public ushort GetStringId(string text, ushort descId = 0)
        {
            if (string.IsNullOrEmpty(text)) return 0;

            if (descId > 0)
                return Djn.Strings.Set(descId, text);

            return Djn.Strings.Add(text);
        }
    }
}
