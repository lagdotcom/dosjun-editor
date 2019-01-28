namespace Jun
{
    public class ExpectedException : JunException
    {
        public ExpectedException(string message) : base($"Expected: {message}") { }
    }
}
