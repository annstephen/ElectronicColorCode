﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicColorCode.Models
{
    //TODO Decide how to include pink silver gold and none
    public enum IecSignificantFigures
    {
        Black,
        Brown,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Violet,
        Gray,
        White
    }

    public enum IecFractionalMultiplier
    {
        Gold = 1,
        Silver,
        Pink
    }

    public interface IOhmValueCalculator
    {
        /// <summary>

        /// Calculates the Ohm value of a resistor based on the band colors.

        /// </summary>

        /// <param name="bandAColor">The color of the first figure of component value band.</param>

        /// <param name="bandBColor">The color of the second significant figure band.</param>

        /// <param name="bandCColor">The color of the decimal multiplier band.</param>

        /// <param name="bandDColor">The color of the tolerance value band.</param>
        double CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor);
        double CalculateUpperBoundValue(string bandDColor);
        double CalculateLowerBoundValue(string bandDColor);
    }
}
