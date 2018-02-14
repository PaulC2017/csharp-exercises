using System;
using System.Collections.Generic;
using System.Linq;

namespace PrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1,1,2,3,5,8 };
            foreach (int num in numbers)
            {
                Console.Write("The next number in the array is: ");
                Console.WriteLine(num);
            }
            Console.ReadLine();
        }
    }
}
