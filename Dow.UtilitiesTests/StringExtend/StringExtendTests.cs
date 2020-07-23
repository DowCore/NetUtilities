using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dow.Utilities.StringExtend.Tests
{
    [TestClass()]
    public class StringExtendTests
    {
        [TestMethod()]
        public void IsNumericOrLettersTest()
        {
            Assert.IsTrue("0123asdd".IsNumericOrLetters());
            Assert.IsTrue(!("0.123!!!".IsNumericOrLetters()));
        }

        [TestMethod()]
        public void IsNumericTest()
        {
            Assert.IsTrue("0123".IsNumeric());
            Assert.IsTrue(("0.123".IsNumeric()));
        }

        [TestMethod()]
        public void IsIntegerTest()
        {
            Assert.IsTrue("0123".IsInteger(), "验证整数失败");
            Assert.IsTrue(!("0.123".IsInteger()), "验证整数失败");
        }
    }
}