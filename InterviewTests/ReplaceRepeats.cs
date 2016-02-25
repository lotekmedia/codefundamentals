using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interviews;

namespace InterviewTests
{
    [TestClass]
    public class ReplaceRepeatsTests
    {
        [TestMethod]
        public void RRTest3Characters()
        {
            ReplaceRepeats rr = new ReplaceRepeats("abc");
            Assert.AreEqual("abc", rr.Execute());

        }

        [TestMethod]
        public void RRTest2RepeatingCharacters()
        {
            ReplaceRepeats rr = new ReplaceRepeats("aa");
            Assert.AreEqual("aa", rr.Execute());

        }

        [TestMethod]
        public void RRTest3RepeatingCharacters()
        {
            ReplaceRepeats rr = new ReplaceRepeats("aaa");
            Assert.AreEqual("a3", rr.Execute());

        }

    }
}
