using System;
using System.Collections.Generic;
using System.Linq;

namespace SumEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>
            {  1,2,3,4,5,6,7,8,9,10,11  };
            List<int> evenNumbers = FindEvenNumbers(numbers);
            Console.WriteLine("The list: ");
            foreach (int item in numbers)
            {
                Console.Write(item);
                Console.Write(" ");
            }
             
            
            Console.WriteLine("\nThe sum of the even numbers from the list ");
            Console.WriteLine(evenNumbers[(evenNumbers.Count)-1] );
            Console.ReadLine();
        }

        private static List<int> FindEvenNumbers(List<int> nums)
        {
            List<int> evenNums = new List<int>();
            int sumTotal = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    evenNums.Add(nums[i]);
                    sumTotal = sumTotal + nums[i];
                }

            }

            // store the sum into the last element in the array

            evenNums.Add(sumTotal);
            return evenNums;
        }

      

    }
}
