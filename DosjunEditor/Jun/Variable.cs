namespace DosjunEditor.Jun
{
    public class Variable
    {
        public short Index { get; set; }
        public string Name { get; set; }
        public Scope Scope { get; set; }

        public override string ToString() => $"{Name} ({Scope})";
    }
}