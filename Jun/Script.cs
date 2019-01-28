using System.Collections.Generic;

namespace Jun
{
    public class Script
    {
        public Script(string name)
        {
            Name = name;
            Code = new List<byte>();
        }

        public string Name { get; private set; }
        public List<byte> Code { get; private set; }
        public short Length => (short)Code.Count;

        public void Write(Op o)
        {
            Write((byte)o);
        }

        public void Write(byte b)
        {
            Code.Add(b);
        }

        public void Write(short value)
        {
            Code.Add((byte)(value & 0xFF));
            Code.Add((byte)(value >> 8));
        }

        public void Replace(short value, short location)
        {
            Code[location] = (byte)(value & 0xFF);
            Code[location + 1] = (byte)(value >> 8);
        }
    }
}
