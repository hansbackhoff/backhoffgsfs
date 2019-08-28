using System;
using System.Collections.Generic;
using System.Text;

namespace CodingLibrary.Resistors
{
    public class CalculateOhmValues : ICalculateOhmValues
    {
        /// <summary>
        /// Calculates the actual ohms for a resitor
        /// </summary>
        /// <param name="bandAColor">Band A Color</param>
        /// <param name="bandBColor">Band B Color</param>
        /// <param name="bandCColor">Band C Color</param>
        /// <param name="bandDColor">Band D Color</param>
        /// <returns></returns>
        public Ohm CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            ResistorColorList colors = new ResistorColorList();

            //Get all the colors
            ResistorColor a = colors.GetByColor(bandAColor);
            ResistorColor b = colors.GetByColor(bandBColor);
            ResistorColor c = colors.GetByColor(bandCColor);
            ResistorColor d = colors.GetByColor(bandDColor);

            //Calculate ohms
            
            return colors.CalculateOhms(a, b, c, d);
        }
    }
}
