using System;
using System.Collections.Generic;
using System.Linq;


namespace PrintWords
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> words = new List<string>
            { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };

            foreach (string item in words)
            {
                if (item.Length == 5)
                {
                    Console.WriteLine("This word has excactly 5 letters: " + item);
                }
            }

            Console.ReadLine();

           
        }
    }
}
