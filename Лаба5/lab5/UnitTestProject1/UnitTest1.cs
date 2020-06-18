using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab5;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string str = "We promptly judged antique ivory buckles for the prize";
            string expected = "not pangram";
          
            Assert.AreEqual(expected, Program.isPangram(str));
        }

        [TestMethod]
        public void TestMethod2()
        {
            string str = "We promptly judged antique ivory buckles for the next	prize";
            string expected = "pangram";

            Assert.AreEqual(expected, Program.isPangram(str));
        }

        [TestMethod]
        public void TestMethod3()
        {
            string str = "toosmallword";
            string expected = "pangram";

            Assert.AreEqual(expected, Program.isPangram(str));
        }

        [TestMethod]
        public void TestMethod5()
        {
            string str = "TheQuickBrownFoxJumpsOverTheLazyDog";
            string expected = "pangram";

            Assert.AreEqual(expected, Program.isPangram(str));
        }

        [TestMethod]
        public void TestMethod6()
        {
            string str = "QwErTyUiOpLkJhGfDsAzXcVbNm";
            string expected = "pangram";

            Assert.AreEqual(expected, Program.isPangram(str));
        }

        [TestMethod]
        public void TestMethod7()
        {
            string str = "BestOlympiad";
            string expected = "not pangram";

            Assert.AreEqual(expected, Program.isPangram(str));
        }
    }
}
