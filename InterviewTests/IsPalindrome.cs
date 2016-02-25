using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome;

namespace PalindromeTests{

    [TestClass]
    public class PalindromeTests
    {
        [TestMethod]
        public void Test1Character()
        {
            PalindromeTester palindromeTester = new PalindromeTester();
            palindromeTester.stringToTest = "A";
            Assert.IsTrue(palindromeTester.Test());
        }

        [TestMethod]
        public void Test2Characters()
        {
            PalindromeTester palindromeTester = new PalindromeTester();
            palindromeTester.stringToTest = "AA";
            Assert.IsTrue(palindromeTester.Test());
        }

        [TestMethod]
        public void Test3Characters()
        {
            PalindromeTester palindromeTester = new PalindromeTester();
            palindromeTester.stringToTest = "ABA";
            Assert.IsTrue(palindromeTester.Test());
        }

        [TestMethod]
        public void Test4InvalidCharacters()
        {
            PalindromeTester palindromeTester = new PalindromeTester();
            palindromeTester.stringToTest = "ABAC";
            Assert.IsFalse(palindromeTester.Test());
        }

        [TestMethod]
        public void Test4Characters()
        {
            PalindromeTester palindromeTester = new PalindromeTester();
            palindromeTester.stringToTest = "ABBA";
            Assert.IsTrue(palindromeTester.Test());
        }

        [TestMethod]
        public void Test5Characters()
        {
            PalindromeTester palindromeTester = new PalindromeTester();
            palindromeTester.stringToTest = "ABCBA";
            Assert.IsTrue(palindromeTester.Test());
        }



    }

}
