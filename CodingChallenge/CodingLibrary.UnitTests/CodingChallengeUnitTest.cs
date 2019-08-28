using System;
using System.Linq;
using CodingLibrary.ChallengeThree;
using CodingLibrary.Resistors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingLibrary.UnitTests
{
    [TestClass]
    public class CodingChallengeUnitTest
    {
        [TestMethod]
        public void TestValidColors()
        {
            CalculateOhmValues calculate = new CalculateOhmValues();
            Assert.AreEqual(calculate.CalculateOhmValue("brown", "orange", "green", "green"), new Ohm() { Ohms = 1300000, Tolerance = 0.005m });
            Assert.AreEqual(calculate.CalculateOhmValue("brown", "brown", "green", "green"), new Ohm() { Ohms = 1100000, Tolerance = 0.005m });
            Assert.AreEqual(calculate.CalculateOhmValue("brown", "brown", "gray", "brown"), new Ohm() { Ohms = 1100000000, Tolerance = 0.01m });
            Assert.AreEqual(calculate.CalculateOhmValue("brown", "blue", "silver", "brown"), new Ohm() { Ohms = 0.16m, Tolerance = 0.01m });
        }

        [TestMethod]
        public void TestInvalidColors()
        {
            CalculateOhmValues calculate = new CalculateOhmValues();
            Assert.ThrowsException<Exception>(() => calculate.CalculateOhmValue("brown", "orange", "purple", "green"));
        }
        public void TestUppercaseValidColors()
        {
            CalculateOhmValues calculate = new CalculateOhmValues();
            Assert.AreEqual(calculate.CalculateOhmValue("BROWN", "ORANGE", "green", "red"), new Ohm() { Ohms = 1300000, Tolerance = 0.02m });
        }
        [TestMethod]
        public void TestValidColorsButNotInCorrectPlace()
        {
            CalculateOhmValues calculate = new CalculateOhmValues();
            Assert.ThrowsException<Exception>(() => calculate.CalculateOhmValue("brown", "none", "purple", "green"));
            Assert.ThrowsException<Exception>(() => calculate.CalculateOhmValue("pink", "none", "purple", "green"));
        }
        [TestMethod]
        public void TestNewImplementation()
        {
            Item item = new Item(true);
            SubItemSummary[] mine = item.GetSubItemSummary("2");
            SubItemSummary[] challenge = item.GetSubItemSummaryCodingChallenge("2");

            Assert.IsTrue(mine.SequenceEqual(challenge));
        }
        ///TESTS NOT APLICABLE NOW THAT WE ARE NOT USING INT. (LEFT FOR CODING CHALLENGE, **DEAD CODE**)
        /*
        [TestMethod]
        public void TestValidColorsButNotInteger()
        {
            CalculateOhmValues calculate = new CalculateOhmValues();
            Assert.ThrowsException<Exception>(() => calculate.CalculateOhmValue("brown", "brown", "pink", "green"));
        }
        [TestMethod]
        public void TestValueToLarge()
        {
            CalculateOhmValues calculate = new CalculateOhmValues();
            Assert.ThrowsException<Exception>(() => calculate.CalculateOhmValue("green", "violet", "gray", "blue"));
        }
        */


    }
}
