using System;
using System.Collections.Generic;
using System.Text;

namespace School
{
    class Course
    {
        private string courseName { get; set; }
        private int courseCredits { get; set; }
        private Dictionary<string, string> roster = new Dictionary<string, string>();

        /* this will contain the students names who have taken the course and their
         * grade.  (A, B, C, D,F,I)
        */

        public Dictionary<string, string> Roster

        {
            get {
                return roster;
            }

            internal set
            {
                roster = value;
            }

        }

       public override string ToString()
        {
            return Name + "(Credits: " + NumberOfCredits + ", GPA: " + Math.Round(Gpa, 2, MidpointRounding.AwayFromZero) + ")";


        }
        /*
        public override bool Equals(Object o)
        {
            if (o == this)
            {
                return true;
            }

            if (o == null)
            {
                return false;
            }

            if (o.GetType() != GetType())
            {
                return false;
            }

            Student studentObj = o as Student;
            return StudentId == studentObj.StudentId;

        }

        public override int GetHashCode()
        {
            return StudentId;
        }


    */





    }
}
