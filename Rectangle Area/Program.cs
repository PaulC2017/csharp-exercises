using System;

namespace Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
            
            
            Console.WriteLine("Hello.  I will calculate the area of a rectangle for you");
            Console.WriteLine("Please enter the height of the rectangle: ");
            string height = Console.ReadLine();
             
            Console.WriteLine("Please enter the width of the rectangle: ");
            string width = Console.ReadLine();

            int answer = int.Parse(width) * int.Parse(height);

            Console.WriteLine("The area of the rectangle with height " + height + " and width " + width + " is " + answer.ToString());
            Console.ReadLine();
        }
    }
}
