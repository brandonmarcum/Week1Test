using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome.Library;
using 

namespace UnitTestProject1
{
    [TestClass]
    public class DemoTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sut = new Word();
            sut.UserWord = "wuw";
            Assert.IsTrue(sut.IsPalindrome());
        }

        [TestMethod]
        public void TestMethod2()
        {
            var sut = new Word();
            sut.UserWord = "wuu";
            Assert.IsFalse(sut.IsPalindrome());
        }

        [TestMethod]
        public void TestMethod3()
        {
            var sut = new Word();
            sut.UserWord = "a";
            Assert.IsFalse(sut.IsPalindrome());
        }
    }
}
