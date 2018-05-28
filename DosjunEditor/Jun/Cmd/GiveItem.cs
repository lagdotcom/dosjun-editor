namespace DosjunEditor.Jun.Cmd
{
    class GiveItem : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(GiveItem);
        public Op Op => Op.GiveItem;

        public void Apply(Parser p)
        {
            p.Consume();
            Token pc = p.Expression();
            Token item = p.Expression();
            Token qty = p.Expression();

            p.EmitArgument(pc);
            p.EmitArgument(item);
            p.EmitArgument(qty);
            p.Emit(Op);
        }
    }
}
