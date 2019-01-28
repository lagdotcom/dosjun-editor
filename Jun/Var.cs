namespace Jun
{
    public class Var
    {
        public string Name { get; set; }
        public short Index { get; set; }
        public VarScope Scope { get; set; }

        public override string ToString() => $"{Scope}#{Index} {Name}";
    }
}
