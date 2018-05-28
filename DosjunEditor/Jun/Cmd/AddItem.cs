namespace DosjunEditor.Jun.Cmd
{
    class AddItem : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(AddItem);
        public Op Op => Op.AddItem;

        public void Apply(Parser p)
        {
            p.Consume();
            Token item = p.Expression();
            Token qty = p.Expression();

            p.EmitArgument(item);
            p.EmitArgument(qty);
            p.Emit(Op);
        }
    }
}
