using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ElectronicColorCode.Models
{
    public class ECC : IOhmValueCalculator
    {
        [Required(ErrorMessage = "Please select a value for Band 1")]
        [Display(Name = "Band1")]
        public string BandAColor { get; set; }
        public IEnumerable<SelectListItem> BandAColors { get; set; }

        [Required(ErrorMessage = "Please select a value for Band 2")]
        [Display(Name = "Band2")]
        public string BandBColor { get; set; }
        public IEnumerable<SelectListItem> BandBColors { get; set; }

        [Required(ErrorMessage = "Please select a value for Band 3")]
        [Display(Name = "Multiplier")]
        public string BandCColor { get; set; }
        public IEnumerable<SelectListItem> BandCColors { get; set; }

        [Required(ErrorMessage = "Please select a value for Band ")]
        [Display(Name = "Tolerance")]
        public string BandDColor { get; set; }
        public IEnumerable<SelectListItem> BandDColors { get; set; }

        [Display(Name = "Ohm Value")]
        public double OhmValue { get; set; }

        [Display(Name = "Upper Bound")]
        public double UpperBoundValue { get; set; }

        [Display(Name = "Lower Bound")]
        public double LowerBoundValue { get; set; }

        public ECC()
        {
            this.OhmValue = 0;
            BandDColor = "None";
        }

        public static readonly Dictionary<String, double> Tolerance = new Dictionary<string, double>
        {
            {"None",20 },
            {"Silver", 10},
            {"Gold", 5 },
            {"Brown", 1 },
            {"Red", 2 },
            {"Green",0.5 },
            {"Blue",0.25 },
            {"Violet",0.1 },
            {"Gray",0.05 }
        };

        //TODO Add functionality for error range
        public double CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor)
        {
            if (bandAColor != null &&
                bandBColor != null &&
                bandCColor != null)
            {
                if (Enum.IsDefined(typeof(IecSignificantFigures), bandAColor) &&
                        Enum.IsDefined(typeof(IecSignificantFigures), bandBColor))
                {
                    int significantFigure = (int)Enum.Parse(typeof(IecSignificantFigures), bandAColor) * 10 + (int)Enum.Parse(typeof(IecSignificantFigures), bandBColor);

                    if (Enum.IsDefined(typeof(IecSignificantFigures), bandCColor))
                    {
                        return significantFigure * Math.Pow(10, (int)Enum.Parse(typeof(IecSignificantFigures), bandCColor));
                    }
                    else if (Enum.IsDefined(typeof(IecFractionalMultiplier), bandCColor))
                    {
                        double temp = significantFigure * Math.Pow(10, (int)Enum.Parse(typeof(IecFractionalMultiplier), bandCColor) * -1);
                        return Math.Round(temp, (int)Enum.Parse(typeof(IecFractionalMultiplier), bandCColor));
                    }
                }
            }
            return -1;
        }

        public void Calculate()
        {
            this.OhmValue = CalculateOhmValue(BandAColor, BandBColor, BandCColor);
            this.UpperBoundValue = CalculateUpperBoundValue(BandDColor);
            this.LowerBoundValue = CalculateLowerBoundValue(BandDColor);
        }

        public double CalculateUpperBoundValue(string bandDColor)
        {
            if (CalculateTolerance(out double toleranceValue, bandDColor))
            {
                return OhmValue + toleranceValue;
            }
            return -1;
        }

        public double CalculateLowerBoundValue(string bandDColor)
        {

            if (CalculateTolerance(out double toleranceValue, bandDColor))
            {
                return OhmValue - toleranceValue;
            }
            return -1;
        }

        private bool CalculateTolerance(out double toleranceValue, string bandDColor)
        {
            toleranceValue = -1;
            if (bandDColor != null &&
                  OhmValue != -1 &&
                  Tolerance.TryGetValue(bandDColor, out double tolerance))
            {
                toleranceValue = OhmValue * tolerance / 100;
                return true;
            }
            return false;
        }
    }
}