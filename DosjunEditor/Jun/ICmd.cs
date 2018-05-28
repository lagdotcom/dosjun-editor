namespace DosjunEditor.Jun
{
    public interface ICmd
    {
        bool IsGlobal { get; }
        bool IsScript { get; }
        string Name { get; }
        Op Op { get; }

        void Apply(Parser p);
    }
}
