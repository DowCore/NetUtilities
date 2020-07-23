using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Dow.Utilities.StringExtend.Tests
{
    [TestClass()]
    public class StringTests
    {
        [TestMethod()]
        public void IsNullOrWhiteSpaceTest()
        {
            var s = "";
            var result= string.IsNullOrWhiteSpace(s);
            Assert.IsTrue(result);

            Assert.IsTrue(string.IsNullOrWhiteSpace(null));

            Assert.IsTrue(string.IsNullOrWhiteSpace(" "));

            Assert.IsTrue(string.IsNullOrWhiteSpace("                    "));
        }
        [TestMethod()]
        public void RemoveStartOrEndTest()
        {
            var s = ",11223,";
            var rss = s.TrimStart(',');
            var rse = s.TrimEnd(',');

            Assert.IsTrue(rss== "11223,");
            Assert.IsTrue(rse == ",11223");
        }

        [TestMethod()]
        public void EqualsTest()
        {
            var s1 = "Abc";
            var s2 = "abc";

            var result= s1.Equals(s2, StringComparison.CurrentCultureIgnoreCase);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ContentEqualsTest()
        {
            var s1 = " 123 ";
            var s2 = "      123";
            Assert.IsTrue(s1.ContentEquals(s2));

            var s3 = " abc ";
            var s4 = "      Abc";
            Assert.IsTrue(s3.ContentEquals(s4, StringComparison.OrdinalIgnoreCase));
        }
    }
}