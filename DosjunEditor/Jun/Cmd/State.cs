namespace DosjunEditor.Jun.Cmd
{
    class State : ICmd
    {
        public bool IsGlobal => true;
        public bool IsScript => false;
        public string Name => nameof(State);
        public Op Op => Op.NOP;

        public void Apply(Parser p)
        {
            p.Consume();
            Token identifier = p.Consume(TokenType.Identifier);

            p.CurrentScript = new Jun.Script { Name = identifier.Value, Type = ScriptType.State };
            p.AddConstant(identifier.Value, (short)p.GetScriptId(identifier.Value));
            p.Scripts.Add(p.CurrentScript);

            p.InScript = true;
        }
    }
}
