using System;

namespace Area
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello.  I will calculate the area of a circle for you");

            string radius = "";
            do
            {
                Console.WriteLine("Please enter the radius of the circle: (The radius must be a positive number) ");

                radius = Console.ReadLine();

            } while (double.Parse(radius) <= 0);

            

            double answer = Double.Parse(radius) * Double.Parse(radius) * Math.PI;

            Console.WriteLine("The area of the circle with radius " + radius +   " is " + answer.ToString());
            Console.ReadLine();
        }
    }
}
