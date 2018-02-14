using System;
using System.Collections.Generic;


namespace CharCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a string to be evaluated or hit ENTER to use the default string:");
            string testString = Console.ReadLine();
            if (testString == "") 
            {

             testString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
                    " Nunc accumsan sem ut ligula scelerisque sollicitudin. Ut at sagittis" +
                    " augue. Praesent quis rhoncus justo. Aliquam erat volutpat. " +
                    "Donec sit amet suscipit metus, non lobortis massa. Vestibulum " +
                    "augue ex, dapibus ac suscipit vel, volutpat eget massa. Donec nec" +
                    " velit non ligula efficitur luctus";

            }
            Dictionary<char, int> lettersCount = new Dictionary<char, int>();

            foreach (char test in testString)
            {



                if (Char.IsLetter(test) ) {
                    if (lettersCount.ContainsKey(test))
                    {
                        lettersCount[test] +=  1;
                    }

                    else {
                        lettersCount[test] = 1;

                    }

                }

            }
            foreach ( KeyValuePair<char, int> letter in lettersCount)
            {

                Console.WriteLine(letter.Key + ": " + letter.Value);

            }


            Console.ReadLine();  
        }
    }
}
