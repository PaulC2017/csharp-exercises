using System;
using System.Collections.Generic;
using System.Linq;

namespace Student
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Student paul = new Student("Paul");
            Student sally = new Student("Sally");
            paul.AddGrade(4, 4.0);
            paul.AddGrade(3, 3.0);
            sally.AddGrade(3, 3.0);
            sally.AddGrade(3, 3.5);


            int paulNumberOfCourses = paul.NumberOfCourses;
            int paulNumberOfCredits = paul.NumberOfCredits;
            string paulGradeLevel = paul.GradeLevel;
            double paulGpa = paul.Gpa;

            int sallyNumberOfCourses = sally.NumberOfCourses;
            int sallyNumberOfCredits = sally.NumberOfCredits;
            string sallyGradeLevel = sally.GradeLevel;
            double sallyGpa = sally.Gpa;

            paul.NumberOfCredits = 91;
            sally.NumberOfCredits = 61;
            paulGradeLevel = paul.GetGradeLevel();
            sallyGradeLevel = sally.GetGradeLevel();

            Console.WriteLine("Paul Number of Credits = " + paul.NumberOfCredits.ToString());

            Console.WriteLine("Paul's info: ");
            Console.WriteLine("Gpa = " + paul.Gpa.ToString());
            Console.WriteLine("Grade Level = " + paulGradeLevel);
            Console.WriteLine("Sally's info: ");
            Console.WriteLine("Gpa = " + sally.Gpa.ToString());
            
            Console.WriteLine("Grade Level = " + sallyGradeLevel);
            Console.ReadLine();
        }



        public class Student
        {

            private static int nextStudentId = 1;
            public string Name { get; set; }
            public int StudentId { get; set; }
            public int NumberOfCredits { get; set; }
            public double Gpa { get; set; }
            public int NumberOfCourses { get; set; }
            public double SumOfGrades;
            public string GradeLevel { get; set; }

            public Student(string name, int studentId,
                           int numberOfCredits, double gpa)
            {
                Name = name;
                StudentId = studentId;
                NumberOfCredits = numberOfCredits;
                Gpa = gpa;
                NumberOfCourses = 0;
                SumOfGrades = 0;
                GradeLevel = "Freshman";

            }

            public Student(string name, int studentId)
                : this(name, studentId, 0, 0) { }

            public Student(string name)
                : this(name, nextStudentId)
            {
                nextStudentId++;
            }

            public void AddGrade(int courseCredits, double grade)
            {
                // Update the appropriate properties: NumberOfCredits, Gpa

                NumberOfCredits = NumberOfCredits + courseCredits;
                NumberOfCourses++;
                SumOfGrades = SumOfGrades + grade;
                Gpa = SumOfGrades / NumberOfCourses;

            }

            public string GetGradeLevel()
            {

                // Determine the grade level of the student based on NumberOfCredits

                /*if (NumberOfCredits > 30 & NumberOfCredits < 60)
                {
                    GradeLevel = "Freshman";
                    return GradeLevel;

                }*/

                
                if (NumberOfCredits > 30 & NumberOfCredits < 60)
                {
                    GradeLevel = "Sophmore";
                    return GradeLevel;

                }

                else if (NumberOfCredits > 60 & NumberOfCredits < 90)
                {
                    GradeLevel = "Junior";
                    return GradeLevel;
                }

                else if (NumberOfCredits > 90)


                {
                    GradeLevel = "Senior";
                    return GradeLevel;
                }

                else
                {
                    return GradeLevel;
                }


            }
        }

    }
}