using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemindMe.Models
{
    public class EventTypesRecurring
    {
        public string RecurringEventName { get; set; }
        public string RecurringEventDescription { get; set; }
        public string RecuringEventCreateDate { get; set; }

        /*public int RecurringEventId { get; set; }
        private static int nextRecurringEventId = 1;
        */

        public int UserId { get; set; }
        public User User { get; set; }

        public int ID { get; set; }
        public IList<User> Users { get; set; }

        
        //default constructor
        public EventTypesRecurring()
        {
            //RecurringEventId = nextRecurringEventId;
            //nextRecurringEventId++;
            RecuringEventCreateDate = DateTime.Today.ToString("MM/dd/yyyy");

        }
        //non default constructor
        public EventTypesRecurring(string recurringEventName, string recurringEventDescription) : this()
        {
            RecurringEventName = recurringEventName;
            RecurringEventDescription = recurringEventDescription;
           

        }
        
    }
}
