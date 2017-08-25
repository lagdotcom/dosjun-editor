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
        public List<byte> Code { get; private set; }
    }
}
