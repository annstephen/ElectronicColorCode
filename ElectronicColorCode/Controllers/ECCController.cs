using ElectronicColorCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicColorCode.Controllers
{
    public class ECCController : Controller
    {
        private static ECC ecc = new ECC();

        // GET: ECC
        public ActionResult Index()
        {
            var colorAList = GetAllColors();
            var colorBList = GetAllColors();
            var multiplierList = GetAllColors();

            // Create a list of SelectListItems so these can be rendered on the page
            ecc.BandAColors = GetSelectListItems(colorAList);
            ecc.BandBColors = GetSelectListItems(colorBList);
            ecc.BandCColors = GetSelectListItems(multiplierList);

            return View(ecc);
        }

        [HttpPost]
        public ActionResult Index(ECC model)
        {
            var colorAList = GetAllColors();
            var colorBList = GetAllColors();
            var multiplierList = GetAllColors();

            model.BandAColors = GetSelectListItems(colorAList);
            model.BandBColors = GetSelectListItems(colorBList);
            model.BandCColors = GetSelectListItems(multiplierList);


            if (ModelState.IsValid)
            {
                Session["ECCModel"] = model;
                Calculate();
            }

            return View("Index", model);

        }

        public void Calculate()
        {
            var model = Session["ECCModel"] as ECC;
            model.CalculateOhmValue();
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> colorList)
        {
            var selectList = new List<SelectListItem>();

            foreach (var element in colorList)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }

        private IEnumerable<string> GetAllColors()
        {
            return Enum.GetNames(typeof(IecSignificantFigures)).ToList();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View("Contact");
        }
    }
}