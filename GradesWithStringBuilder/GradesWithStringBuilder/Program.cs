using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradesWithStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> students = new List<string>();
            List<double> grades = new List<double>();
            string newStudent;

            Console.WriteLine("Enter your students (or ENTER to finish):");
            do
            {
                newStudent = Console.ReadLine();
                if (newStudent != "")
                {
                    students.Add(newStudent);
                }
            }
            while (newStudent != "");

            // Get student grades
            foreach (string student in students)
            {
                Console.WriteLine("Grade for " + student + ": ");
                double newGrade = double.Parse(Console.ReadLine());
                grades.Add(newGrade);
            }

            /*Print class roster - not using StringBuilder Class

            Console.WriteLine("\nClass roster:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i] + " (" + grades[i] + ")");
            }
            */

            //Print class roster -  using StringBuilder Class
            Console.WriteLine("\nClass roster:");

            StringBuilder studentInfo = new StringBuilder();

            for (int i = 0; i < students.Count; i++)
            {
                studentInfo.Append(students[i]);
                studentInfo.Append(" ");
                studentInfo.Append(grades[i]);
                studentInfo.Append("\n");



            }

            Console.WriteLine(studentInfo);


            double sum = grades.Sum();
            double avg = sum / grades.Count;
            Console.WriteLine("Average grade: " + avg);

            Console.ReadLine();
        }
    }
}
