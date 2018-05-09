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

        [TestMethod]
        public void TestIndexListPopulate()
        {
            ECCController controller = new ECCController();
            var result = controller.Index() as ViewResult;
            var ecc = (ECC)result.ViewData.Model;
            Assert.IsNotNull(ecc.BandAColors);
            Assert.IsNotNull(ecc.BandBColors);
            Assert.IsNotNull(ecc.BandCColors);
        }

        [TestMethod]
        public void TestIndexListPopulateValues()
        {
            ECCController controller = new ECCController();
            var result = controller.Index() as ViewResult;
            var ecc = (ECC)result.ViewData.Model;
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
        public void TestIndexPostValues()
        {
            var context = new Mock<ControllerContext>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(m => m.HttpContext.Session).Returns(session.Object);
            ECCController controller = new ECCController();
            controller.ControllerContext = context.Object;
            var result = controller.Index() as ViewResult;
            var ecc = (ECC)result.ViewData.Model;
            ecc.BandAColor = "Yellow";
            ecc.BandBColor = "Violet";
            ecc.BandCColor = "Red";
            session.Setup(s => s["ECCModel"]).Returns(ecc);
            result = controller.Index(ecc) as ViewResult;
            ecc = (ECC)result.ViewData.Model;
            Assert.AreEqual(4700, ecc.OhmValue);
        }

        [TestMethod]
        public void TestContact()
        {
            ECCController controller = new ECCController();
            var result = controller.Contact() as ViewResult;
            Assert.AreEqual("Contact", result.ViewName);
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
