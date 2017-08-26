using System.Collections.Generic;

namespace DosjunEditor.Jun
{
    public class Context
    {
        public Context(string name, int start)
        {
            Name = name;
            Offsets = new List<int>();
            Start = start;
        }

        public string Name { get; set; }
        public List<int> Offsets { get; private set; }
        public int Start { get; set; }

        public override string ToString() => $"{Name} @{Start}";
    }
}
