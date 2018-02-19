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

        
    }
}
