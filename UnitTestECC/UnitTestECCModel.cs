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
            int result = model.CalculateOhmValue("Yellow", "Violet", "Red", "Gold");
            Assert.AreEqual(4700, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmAllNullCheck()
        {
            ECC model = new ECC();
            int result = model.CalculateOhmValue(null, null, null, null);
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandANullCheck()
        {
            ECC model = new ECC();
            int result = model.CalculateOhmValue(null, "Violet", "Red", "Gold");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandBNullCheck()
        {
            ECC model = new ECC();
            int result = model.CalculateOhmValue("Yellow", null, "Red", "Gold");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandCNullCheck()
        {
            ECC model = new ECC();
            int result = model.CalculateOhmValue("Yellow", "Violet", null, "Gold");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandABadValueCheck()
        {
            ECC model = new ECC();
            int result = model.CalculateOhmValue("Purple", "Violet", "Red", "Gold");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandBBadvalueCheck()
        {
            ECC model = new ECC();
            int result = model.CalculateOhmValue("Yellow", "Purple", "Red", "Gold");
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void TestMethodCalculateOhmBandCBadValueCheck()
        {
            ECC model = new ECC();
            int result = model.CalculateOhmValue("Yellow", "Violet", "Purple", "Gold");
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
    }
}
