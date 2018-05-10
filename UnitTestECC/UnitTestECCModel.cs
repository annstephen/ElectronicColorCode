using System;
using ElectronicColorCode.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestECC
{
    [TestClass]
    public class UnitTestECCModel
    {
        ECC model;

        [TestMethod]
        public void TestMethodCalculateOhmCheck()
        {
            double result = model.CalculateOhmValue("Yellow", "Violet", "Red");
            Assert.AreEqual(4700, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmFractionGoldCheck()
        {
            double result = model.CalculateOhmValue("Yellow", "Violet", "Gold");
            Assert.AreEqual(4.7, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmFractionSilverCheck()
        {
            double result = model.CalculateOhmValue("Yellow", "Violet", "Silver");
            Assert.AreEqual(0.47, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmFractionPinkCheck()
        {
            double result = model.CalculateOhmValue("Yellow", "Violet", "Pink");
            Assert.AreEqual(0.047, result);
        }

        [TestMethod]
        public void TestMethodOverflowCheck()
        {
            double result = model.CalculateOhmValue("White", "White", "White");
            Assert.AreEqual(99000000000, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmAllNullCheck()
        {
            double result = model.CalculateOhmValue(null, null, null);
            double upperbound = model.CalculateUpperBoundValue(null);
            double lowerBound = model.CalculateUpperBoundValue(null);
            Assert.AreEqual(-1, result);
            Assert.AreEqual(-1, upperbound);
            Assert.AreEqual(-1, lowerBound);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandANullCheck()
        {
            double result = model.CalculateOhmValue(null, "Violet", "Red");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandBNullCheck()
        {
            double result = model.CalculateOhmValue("Yellow", null, "Red");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandCNullCheck()
        {
            double result = model.CalculateOhmValue("Yellow", "Violet", null);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandABadValueCheck()
        {
            double result = model.CalculateOhmValue("Purple", "Violet", "Red");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandBBadvalueCheck()
        {
            double result = model.CalculateOhmValue("Yellow", "Purple", "Red");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandCBadValueCheck()
        {
            double result = model.CalculateOhmValue("Yellow", "Violet", "Purple");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmWithoutParametersNullCheck()
        {
            model.Calculate();
            Assert.AreEqual( -1, model.OhmValue);
            Assert.AreEqual(-1, model.UpperBoundValue);
            Assert.AreEqual(-1, model.LowerBoundValue);
        }

        [TestMethod]
        public void TestMethodCalculateWithoutParametersValuesCheck()
        {
            model.BandAColor = "Yellow";
            model.BandBColor = "Violet";
            model.BandCColor = "Red";
            model.Calculate();
            Assert.AreEqual(4700, model.OhmValue);
            Assert.AreEqual(5640, model.UpperBoundValue);
            Assert.AreEqual(3760, model.LowerBoundValue);
        }

        [TestMethod]
        public void TestMethodCalculateFractionWithoutParametersValuesCheck()
        {
            model.BandAColor = "Yellow";
            model.BandBColor = "Violet";
            model.BandCColor = "Pink";
            model.Calculate();
            Assert.AreEqual(.047, model.OhmValue);
            Assert.AreEqual(.0564, model.UpperBoundValue);
            Assert.AreEqual(.0376, model.LowerBoundValue);
        }

        [TestMethod]
        public void TestMethodCalculateWithToleranceBandCheck()
        {
            model.BandAColor = "Yellow";
            model.BandBColor = "Violet";
            model.BandCColor = "Red";
            model.BandDColor = "Gold";
            model.Calculate();
            Assert.AreEqual(4700, model.OhmValue);
            Assert.AreEqual(4935, model.UpperBoundValue);
            Assert.AreEqual(4465, model.LowerBoundValue);
        }

        [TestMethod]
        public void TestMethodUpperBoundCheck()
        {
            model.OhmValue = 4700;
            double result = model.CalculateUpperBoundValue("Gold");
            Assert.AreEqual(4935, result);
        }

        [TestMethod]
        public void TestMethodLowerBoundCheck()
        {
            model.OhmValue = 4700;
            double result = model.CalculateLowerBoundValue("Gold");
            Assert.AreEqual(4465, result);
        }

        [TestInitialize]
        public void TestSetup()
        {
            model = new ECC();
        }
    }
}
