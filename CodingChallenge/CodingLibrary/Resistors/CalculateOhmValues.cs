using System;
using System.Collections.Generic;
using System.Text;

namespace CodingLibrary.Resistors
{
    public class CalculateOhmValues : ICalculateOhmValues
    {
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
