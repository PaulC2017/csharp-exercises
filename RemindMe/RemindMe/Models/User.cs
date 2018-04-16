using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemindMe.Models
{
    public class User
    {
      
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string GCalEmail { get; set; }
        public string GCalEmailPassword { set; get; }
        
        public string UserCreateDate { get; set; }


        public int UserId { get; set; }
        private static int nextUserId = 1;

        public IList<UserEventTypesNonRecurring> UserEventTypesNonRecurring { get; set; }

        public IList<UserEventTypesRecurring> UserEventTypesRecurring { get; set; }

        public int RecurringReminderId { get; set; }
        public RecurringReminders RecurringReminderName { get; set; }
        
        public int NonRecurringReminderId { get; set; }
        public NonRecurringReminders NonRecurringReminderName { get; set; }



        //default constructor
        public User()
        {
            UserId = nextUserId;
            nextUserId++;
            UserCreateDate = DateTime.Today.ToString("MM/dd/yyyy");
            
        }
        
        //non default constructor
        public User(string username, string email, string password) : this()
        {
            Username = username;
            Email = email;
            Password = password;

        }





    }
}
