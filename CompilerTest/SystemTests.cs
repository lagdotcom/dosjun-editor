using Microsoft.VisualStudio.TestTools.UnitTesting;
using DosjunEditor.Jun;
using DosjunEditor.Jun.Ex;

namespace CompilerTest
{
    [TestClass]
    public class SystemTests : CompilerTests
    {
        [TestMethod]
        public void TestVariableOverflow()
        {
            string code = "";

            for (int i = 0; i <= Parser.MaxTemps; i++)
                code += $"v{i} = 0\n";

            AssertParseException<OverflowException>(code, "Too many Temp variables");
        }
    }
}
