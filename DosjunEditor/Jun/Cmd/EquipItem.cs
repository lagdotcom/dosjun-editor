namespace DosjunEditor.Jun.Cmd
{
    class EquipItem : ICmd
    {
        public bool IsGlobal => false;
        public bool IsScript => true;
        public string Name => nameof(EquipItem);
        public Op Op => Op.EquipItem;

        public void Apply(Parser p)
        {
            p.Consume();
            Token pc = p.Expression();
            Token item = p.Expression();

            p.EmitArgument(pc);
            p.EmitArgument(item);
            p.Emit(Op);
        }
    }
}
