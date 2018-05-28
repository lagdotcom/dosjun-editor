using System.Collections.Generic;

namespace DosjunEditor.Jun
{
    public class Script
    {
        public Script()
        {
            Code = new List<byte>();
        }

        public string Name { get; set; }
        public ScriptType Type { get; set; }
        public List<byte> Code { get; set; }
        public bool Public => Type == ScriptType.Script;

        public override string ToString() => Name;
    }
}
