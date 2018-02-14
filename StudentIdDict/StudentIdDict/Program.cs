using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentIdDict
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, string> students = new Dictionary<int, string>();
            string newStudent;

            Console.WriteLine("Enter your students (or ENTER to finish):");
            do
            {
                Console.Write("name: ");
                newStudent = Console.ReadLine();
                if (newStudent != "")
                {
                    // Get the student's ID
                    Console.WriteLine("ID: ");
                    int newId = int.Parse(Console.ReadLine());

                    students.Add(newId, newStudent);
                }
            }
            while (newStudent != "");

            // Print class roster
            Console.WriteLine("\nClass roster:");
            foreach (KeyValuePair<int, string> student in students)
            {
                Console.WriteLine(student.Key + " (" + student.Value + ")");
            }

            /*double sum = students.Values.Sum();
            double avg = sum / students.Count;
            Console.WriteLine("Average grade: " + avg);  */

            Console.ReadLine();
        }
    }
}
