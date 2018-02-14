using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CreatingMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string statement = "Hello World!";

            // this is how you call the method

            HelloWorld(statement);

            //
            Console.ReadLine();
            HelloWorld("Hello to you too!");
            Console.ReadLine();

            // here is a call to a method that will return a value to the caller
            string result = HelloWorld2("Hi There");
            Console.WriteLine(result);
            Console.ReadLine();

            // here we call the overloaded HelloWordl2 , only with the parameters it requires

            string result2 = HelloWorld2("many messages", 4);
            Console.WriteLine(result2);
            Console.ReadLine();
            // note we could have done this in this manner:
            Console.WriteLine("\nThis is the other way we could have done this \n");
            Console.WriteLine(HelloWorld2("many messages", 4));
            Console.ReadLine();
        }

        // This is the method - it simply prints the argument passed to it

        private static void HelloWorld(string message)
        {
            Console.WriteLine(message);

        }
        // this method accepts a string parameter and returns a string back to the caller

        private static string HelloWorld2(string message)
        {
            Console.WriteLine(message);
            return "I printed it";
        }

        // overloaded version of HelloWorld2 method - it must accept either a different number of parameters than the other Helloworld2
        // methid  or differrent data types 

        private static string HelloWorld2(string message, int num)
        {

            for (int i = 0; i < num; ++i) {

                Console.WriteLine(message);
            }

            string answer = "I printed it " + num.ToString() + " times.";
            
            return answer;
        }


    }
}
