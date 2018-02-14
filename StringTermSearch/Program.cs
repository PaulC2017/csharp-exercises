using System;

namespace StringTermSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string specimen = "Alice was beginning to get very tired of sitting by her sister on the bank, and of" +
                              " having nothing to do: once or twice she had peeped into the book her sister was reading, but it had no pictures or " +
                              "conversations in it, 'and what is the use of a book,' thought Alice 'without pictures or conversation?'".ToLower();

            Console.WriteLine("Hello.  I will check to see if the term you are looking for is in the sentence:");
            Console.WriteLine(specimen);
            Console.WriteLine("Please enter the term you are searching for");
            string term = Console.ReadLine();

            if ( ( specimen.IndexOf( term.ToLower() ) ) != -1 ) {

                Console.WriteLine(term + " was found in the sentence  " + specimen);

            }

            else
            {
                Console.WriteLine(term + " was NOT found in the sentence  " + specimen);

            }
            
            Console.ReadLine();
            

            
        }
    }
}
