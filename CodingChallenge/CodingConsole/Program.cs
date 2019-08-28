using CodingLibrary.ChallengeThree;
using CodingLibrary.Resistors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Item item = new Item(true);
            item.GetSubItemSummary("2");

            bool keepGoing = false;
            do
            {
                Console.WriteLine("Please enter the colors of the resistor");
                Console.WriteLine("Enter Band A Color:");
                String bandA = Console.ReadLine();
                Console.WriteLine("Enter Band B Color:");
                String bandB = Console.ReadLine();
                Console.WriteLine("Enter Band C Color:");
                String bandC = Console.ReadLine();
                Console.WriteLine("Enter Band D Color:");
                String bandD = Console.ReadLine();

                try
                {
                    CalculateOhmValues calculate = new CalculateOhmValues();
                    Ohm calculatedValue = calculate.CalculateOhmValue(bandA, bandB, bandC, bandD);
                    Console.WriteLine(calculatedValue.Ohms.ToString());
                    Console.WriteLine(calculatedValue.FormattedOhms);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                Console.WriteLine("Do you want to run another calculation? (Y/N)");
                String answer = Console.ReadLine().Trim();
                keepGoing = (answer.ToLower().CompareTo("y") == 0);
            }
            while (keepGoing);
        }
    }
}
