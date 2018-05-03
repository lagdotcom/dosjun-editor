using System;

namespace DosjunEditor
{
    public class ZoneContext
    {
        public Action<object, EventArgs> EncountersChanged { get; internal set; }
        public Zone Zone { get; internal set; }
        public Monsters Monsters { get; internal set; }
        public bool UnsavedChanges { get; internal set; }
        public object[] ScriptNames { get; internal set; }

        internal void UpdateEncounters()
        {
            throw new NotImplementedException();
        }
    }
}