using System;
using System.Collections.Generic;
using System.Text;

namespace CodingLibrary.Resistors
{
    public class ResistorColorList : List<ResistorColor>
    {
        public ResistorColorList()
        {
            Add(new ResistorColor("None", -1, 0m, 0.2m));
            Add(new ResistorColor("Black", 0, 1m, 0m));
            Add(new ResistorColor("Brown", 1, 10m, 0.01m));
            Add(new ResistorColor("Red", 2, 100m, 0.02m));
            Add(new ResistorColor("Orange", 3, 1000m, 0.0005m));
            Add(new ResistorColor("Yellow", 4, 10000m, 0.0002m));
            Add(new ResistorColor("Green", 5, 100000m, 0.005m));
            Add(new ResistorColor("Blue", 6, 1000000m, 0.0025m));
            Add(new ResistorColor("Violet", 7, 10000000m, 0.001m));
            Add(new ResistorColor("Gray", 8, 100000000m, 0.0001m));
            Add(new ResistorColor("White", 9, 1000000000m, 0.0001m));

            //Invalid Colors for this interface as would not return an integer
            Add(new ResistorColor("Pink", -1, 0.001m, 0.0m));
            Add(new ResistorColor("Silver", -1, 0.01m, 0.1m));
            Add(new ResistorColor("Gold", -1, 0.1m, 0.05m));
        }

        public ResistorColor GetByColor(String color)
        {
            foreach (ResistorColor item in this)
            {
                if (item.Color.ToLower().CompareTo(color.ToLower()) == 0)
                {
                    return item;
                }
            }
            throw new Exception("Invalid color selection.");
        }

        public Ohm CalculateOhms(ResistorColor one, ResistorColor two, ResistorColor three, ResistorColor four)
        {
            //check if the first 2 colors are used for significance figures
            if((one.IsSignificance && two.IsSignificance) == false)
            {
                throw new Exception("Invalid color selection.");
            }

            int figure = (one.SignificantDigits * 10) + two.SignificantDigits;
            decimal calculatedValue = figure * three.Multiplier;
            Ohm ohm = new Ohm() { Ohms = calculatedValue, Tolerance = four.Tolerance };

            return ohm;


        }
    }
}
