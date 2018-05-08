using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RemindMe.ViewModels;
using RemindMe.Models;
using RemindMe.Data;
using Microsoft.EntityFrameworkCore;

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

        public int ID { get; set; }
        

        public IList<RecurringEvents> RecurringEvents = new List<RecurringEvents>();
        public IList<NonRecurringEvents> NonRecurringEvents = new List<NonRecurringEvents>();
        public IList<RecurringReminders> RecurringReminders = new List<RecurringReminders>();
        public IList<NonRecurringReminders>NonRecurringReminders = new List<NonRecurringReminders>();

        /*
        public int RecurringReminderId { get; set; }
        public RecurringReminders RecurringReminderName { get; set; }
        
        public int NonRecurringReminderId { get; set; }
        public NonRecurringReminders NonRecurringReminderName { get; set; }

        public int RecurringEventsId { get; set; }
        public RecurringEvents RecurringEventsName { get; set; }

        public int NonRecurringEventsId { get; set; }
        public NonRecurringEvents NonRecurringEventsName { get; set; }
        */

        //default constructor
        public User()
        {
            //UserId = nextUserId;
            //nextUserId++;
            UserCreateDate = DateTime.Today.ToString("MM/dd/yyyy");
            
        }

        //non default constructor
        public User(string username, string password, string gCalEmail, string gCalEmailPassword) : this()
        {
            Username = username;
            Password = password;
            GCalEmail = gCalEmail;
            GCalEmailPassword = gCalEmailPassword;

        }
      

        

    }
}
