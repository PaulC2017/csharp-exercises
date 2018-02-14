using System;

namespace MilesPerGallon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello.  I will calculate your car's miles per gallon for you");
            Console.WriteLine("Please enter the number of miles you have driven: ");
            string miles = Console.ReadLine();

            Console.WriteLine("Please enter the number of gallons of gas you have consumed: ");
            string gas = Console.ReadLine();

            double answer = double.Parse(miles) / double.Parse(gas);

            Console.WriteLine("The miles per gallon after driving " + miles + " and using " + gas + " gallons of gas is " + answer.ToString());
            Console.ReadLine();
        }
    }
}
