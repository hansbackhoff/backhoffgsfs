using System;
using System.Collections.Generic;
using System.Text;

namespace CodingLibrary.Resistors
{
    public class ResistorColor
    {
        public ResistorColor(String color, int digit, decimal multiplier, decimal tolerance)
        {
            Color = color;
            SignificantDigits = digit;
            Multiplier = multiplier;
            Tolerance = tolerance;
        }
        /// <summary>
        /// The name of the color
        /// </summary>
        public String Color { get; set; }

        /// <summary>
        /// The value of the significant digits
        /// </summary>
        public int SignificantDigits { get; set; }

        /// <summary>
        /// The multiplier
        /// </summary>
        public decimal Multiplier { get; set; }

        /// <summary>
        /// The percentage of the tolerance
        /// </summary>
        public decimal Tolerance { get; set; }

        /// <summary>
        /// Returns true if color can be used for significance
        /// </summary>
        public bool IsSignificance
        {
            get
            {
                return (SignificantDigits >= 0);
            }
        }


    }
}
