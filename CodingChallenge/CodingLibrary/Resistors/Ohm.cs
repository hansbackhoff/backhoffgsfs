using System;
using System.Collections.Generic;
using System.Text;

namespace CodingLibrary.Resistors
{
    public class Ohm
    {
        public decimal Ohms { get; set; }

        public decimal Tolerance { get; set; }

        /// <summary>
        /// Displays the formated ohms ie. "1.5M Ω +/- 1%"
        /// </summary>
        public String FormattedOhms
        {
            get
            {
                if (Ohms > 999999999)
                    return (Ohms / 1000000000).ToString()+ "G Ω +/- " + Tolerance.ToString("P2");
                else if (Ohms > 999999)
                    return (Ohms / 1000000).ToString() + "M Ω +/- " + Tolerance.ToString("P2");
                else if (Ohms > 999)
                    return (Ohms / 1000).ToString() + "K Ω +/- " + Tolerance.ToString("P2");
                else
                    return Ohms.ToString() + " Ω +/- " + Tolerance.ToString("P2");


            }
        }
        /// <summary>
        /// Overloads the Equals for use in the Unit Tests.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Ohm ohms)
            {
                if (ohms.Ohms.CompareTo(Ohms) == 0 && ohms.Tolerance.CompareTo(Tolerance) == 0)
                    return true;
            }
            return false;
        }

    }
}
