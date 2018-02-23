using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName;
            Console.WriteLine("Hi there.  My name is Paul!  What is your namne?  ");
            userName= Console.ReadLine();
            Console.WriteLine("Hello " + userName);
            Console.ReadLine();
        }
    }
}
