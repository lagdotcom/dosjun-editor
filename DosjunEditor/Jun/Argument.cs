namespace DosjunEditor.Jun
{
    public struct Argument
    {
        public static Argument Null = new Argument("None", ArgumentType.None);
        public static Argument Success = new Argument("Success", ArgumentType.Boolean);

        public string Name { get; set; }
        public ArgumentType Type { get; set; }

        public Argument(string name, ArgumentType type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString() => $"{Name} ({Type})";
    }
}
