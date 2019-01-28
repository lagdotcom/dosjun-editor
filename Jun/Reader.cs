namespace Jun
{
    public class Reader
    {
        public Reader(string module, string source)
        {
            Module = module;
            Source = source;
            Index = 0;
        }

        public string Module { get; private set; }
        public string Source { get; private set; }
        public int Index { get; private set; }

        public char Look => Index >= Source.Length ? EF : Source[Index];
        public char Read() => Look == EF ? EF : Source[Index++];

        public const char EF = '\0';
    }
}
