using System;
using ElectronicColorCode.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestECC
{
    [TestClass]
    public class UnitTestECCModel
    {
        [TestMethod]
        public void TestMethodCalculateOhmCheck()
        {
            ECC model = new ECC();
            double result = model.CalculateOhmValue("Yellow", "Violet", "Red", "Gold");
            Assert.AreEqual(4700, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmFractionGoldCheck()
        {
            ECC model = new ECC();
            double result = model.CalculateOhmValue("Yellow", "Violet", "Gold", "Gold");
            Assert.AreEqual(4.7, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmFractionSilverCheck()
        {
            ECC model = new ECC();
            double result = model.CalculateOhmValue("Yellow", "Violet", "Silver", "Gold");
            Assert.AreEqual(0.47, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmFractionPinkCheck()
        {
            ECC model = new ECC();
            double result = model.CalculateOhmValue("Yellow", "Violet", "Pink", "Gold");
            Assert.AreEqual(0.047, result);
        }

        [TestMethod]
        public void TestMethodOverflowCheck()
        {
            ECC model = new ECC();
            double result = model.CalculateOhmValue("White", "White", "White", "Gold");
            Assert.AreEqual(99000000000, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmAllNullCheck()
        {
            ECC model = new ECC();
            double result = model.CalculateOhmValue(null, null, null, null);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandANullCheck()
        {
            ECC model = new ECC();
            double result = model.CalculateOhmValue(null, "Violet", "Red", "Gold");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandBNullCheck()
        {
            ECC model = new ECC();
            double result = model.CalculateOhmValue("Yellow", null, "Red", "Gold");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandCNullCheck()
        {
            ECC model = new ECC();
            double result = model.CalculateOhmValue("Yellow", "Violet", null, "Gold");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandABadValueCheck()
        {
            ECC model = new ECC();
            double result = model.CalculateOhmValue("Purple", "Violet", "Red", "Gold");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandBBadvalueCheck()
        {
            ECC model = new ECC();
            double result = model.CalculateOhmValue("Yellow", "Purple", "Red", "Gold");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandCBadValueCheck()
        {
            ECC model = new ECC();
            double result = model.CalculateOhmValue("Yellow", "Violet", "Purple", "Gold");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmWithoutParametersNullCheck()
        {
            ECC model = new ECC();
            model.CalculateOhmValue();
            Assert.AreEqual( -1, model.OhmValue);
        }

        [TestMethod]
        public void TestMethodCalculateOhmWithoutParametersValuesCheck()
        {
            ECC model = new ECC();
            model.BandAColor = "Yellow";
            model.BandBColor = "Violet";
            model.BandCColor = "Red";
            model.CalculateOhmValue();
            Assert.AreEqual(4700, model.OhmValue);
        }

        [TestMethod]
        public void TestMethodCalculateOhmFractionWithoutParametersValuesCheck()
        {
            ECC model = new ECC();
            model.BandAColor = "Yellow";
            model.BandBColor = "Violet";
            model.BandCColor = "Pink";
            model.CalculateOhmValue();
            Assert.AreEqual(.047, model.OhmValue);
        }

    }
}
