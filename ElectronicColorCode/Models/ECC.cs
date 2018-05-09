using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web.Mvc;

namespace ElectronicColorCode.Models
{
    public class ECC : IOhmValueCalculator
    {
        [Required(ErrorMessage ="Please select a value for Band 1")]
        [Display(Name = "Band1")]
        public string BandAColor { get; set; } 
        public IEnumerable<SelectListItem> BandAColors { get; set; }

        [Required(ErrorMessage = "Please select a value for Band 2")]
        [Display(Name = "Band2")]
        public string BandBColor { get; set; }
        public IEnumerable<SelectListItem> BandBColors { get; set; }

        [Required(ErrorMessage = "Please select a value for Band 3")]
        [Display (Name = "Multiplier")]
        public string BandCColor { get; set; }
        public IEnumerable<SelectListItem> BandCColors { get; set; }

        [Display(Name = "Ohm Value")]
        public int OhmValue { get; set; }

        public ECC()
        {
            this.OhmValue = 0;
        }
        //TODO Add functionality for error range
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            if (bandAColor != null &&
                bandBColor != null &&
                bandCColor != null)
            {
                if (Enum.IsDefined(typeof(IecSignificantFigures), bandAColor) &&
                    Enum.IsDefined(typeof(IecSignificantFigures), bandBColor) &&
                    Enum.IsDefined(typeof(IecSignificantFigures), bandCColor))
                {
                    return ((int)Enum.Parse(typeof(IecSignificantFigures), bandAColor) * 10 + (int)Enum.Parse(typeof(IecSignificantFigures), bandBColor)) * (int)Math.Pow(10, (int)Enum.Parse(typeof(IecSignificantFigures), bandCColor));
                }
            }
            return -1;
        }

        public void CalculateOhmValue()
        {
            //TODO implement band D
            this.OhmValue = CalculateOhmValue(BandAColor,BandBColor,BandCColor,"white");
        }
    }
}