using System;

namespace School
{
    public class Student
    {
        private string name;
        private int StudentId { get; set; }
        private int NumberOfCredits { get; set; }
        private double Gpa { get; set; }

        public string Name
        {
            get
            {
                return name;
            }

            internal set
            {
                name = value;
            }
        }


    

        public Student (string name, int studentId, int numbnerOfCredits, double gpa)
        {
            Name = name;
            StudentId = studentId;
            NumberOfCredits = NumberOfCredits;
            Gpa = gpa;
        }

        /* A better way to write this follows:  

         public Student(string name, int studentId)
         {
             Name = name;
             StudentId = studentId;
             NumberOfCredits = 0;
             Gpa = 0.0;
         }
         */

        // this is a better constructor that accomplishes the samne as directly above this line
        // as this uses anotyher constructor within the class - namely:
        //  public Student (string name, int studentId, int numbnerOfCredits, double gpa)

        public Student(string name, int studentId)
        
            : this(name,studentId,0,0.0) { }
        

        public static void Main(string[] args)
        {
            Console.WriteLine("enter the new student's name: ");
            string studentName = Console.ReadLine();
            Console.WriteLine("enter the new student's ID: ");
            string id = Console.ReadLine();
            int studentId = int.Parse(id);
            
            Student first = new Student(studentName,studentId);
            first.Name = studentName;
            first.StudentId = studentId;
            Console.WriteLine(first.Name + " " + first.StudentId);
            Console.ReadLine();
        }




    }

    
}
