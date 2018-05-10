using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicColorCode.Controllers;
using ElectronicColorCode.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestECC
{
    [TestClass]
    public class UnitTestController
    {
        ECCController controller;
        ECC ecc;
        Mock<ControllerContext> context;
        Mock<HttpSessionStateBase> session;

        [TestMethod]
        public void TestIndexListPopulate()
        {
            Assert.IsNotNull(ecc.BandAColors);
            Assert.IsNotNull(ecc.BandBColors);
            Assert.IsNotNull(ecc.BandCColors);
            Assert.IsNotNull(ecc.BandDColors);
        }

        [TestMethod]
        public void TestIndexListPopulateValues()
        {
            IEnumerable<string> fractionList = Enum.GetNames(typeof(IecFractionalMultiplier)).ToList();
            IEnumerable<string> list = Enum.GetNames(typeof(IecSignificantFigures)).ToList();
            IEnumerable<string> multipliersList = fractionList.Concat(list);
            IEnumerable<string> BandAStringList = GetStringList(ecc.BandAColors);
            Assert.IsTrue(list.SequenceEqual(BandAStringList));
            IEnumerable<string> BandBStringList = GetStringList(ecc.BandBColors);
            Assert.IsTrue(list.SequenceEqual(BandBStringList));
            IEnumerable<string> BandCStringList = GetStringList(ecc.BandCColors);
            Assert.IsTrue(multipliersList.SequenceEqual(BandCStringList));
        }

        [TestMethod]
        public void TestIndexToleranceListPopulateValues()
        {
            IEnumerable<string> ToleranceList = ECC.Tolerance.Keys;
            IEnumerable<string> BandDStringList = GetStringList(ecc.BandDColors);
            Assert.IsTrue(ToleranceList.SequenceEqual(BandDStringList));
        }

        [TestMethod]
        public void TestIndexPostValues()
        {
            ecc.BandAColor = "Yellow";
            ecc.BandBColor = "Violet";
            ecc.BandCColor = "Red";
            ecc.BandDColor = "Gold";
            var result = controller.Index(ecc) as ViewResult;
            ecc = (ECC)result.ViewData.Model;
            Assert.AreEqual(4700, ecc.OhmValue);
            Assert.AreEqual(4465, ecc.LowerBoundValue);
            Assert.AreEqual(4935, ecc.UpperBoundValue);
        }

        [TestMethod]
        public void TestContact()
        {
            ECCController controller = new ECCController();
            var result = controller.Contact() as ViewResult;
            Assert.AreEqual("Contact", result.ViewName);
        }

        [TestInitialize]
        public void TestSetup()
        {
            controller = new ECCController();
            var result = controller.Index() as ViewResult;
            ecc = (ECC)result.ViewData.Model;
            context = new Mock<ControllerContext>();
            session = new Mock<HttpSessionStateBase>();
            context.Setup(m => m.HttpContext.Session).Returns(session.Object);
            controller.ControllerContext = context.Object;
            session.Setup(s => s["ECCModel"]).Returns(ecc);
        }

        private IEnumerable<string> GetStringList(IEnumerable<SelectListItem> selectList)
        {
            var stringList = new List<string>();

            foreach (var element in selectList)
            {
                stringList.Add(
                    element.Value.ToString());
            }

            return stringList;
        }
    }
}
