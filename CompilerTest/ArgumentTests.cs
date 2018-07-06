using Microsoft.VisualStudio.TestTools.UnitTesting;
using DosjunEditor.Jun;
using DosjunEditor.Jun.Ex;

namespace CompilerTest
{
    [TestClass]
    public class ArgumentTests : CompilerTests
    {
        [TestMethod]
        public void TestWrongArgumentType()
        {
            AssertParseException<ArgumentTypeException>("Combat \"Hello\"");
        }

        [TestMethod]
        public void TestNotEnoughArguments()
        {
            AssertParseException<ArgumentCountException>("SetDanger");
        }

        [TestMethod]
        public void TestTooManyArguments()
        { 
            AssertParseException<ArgumentCountException>("SetDanger 10, 10");
        }
    }
}
