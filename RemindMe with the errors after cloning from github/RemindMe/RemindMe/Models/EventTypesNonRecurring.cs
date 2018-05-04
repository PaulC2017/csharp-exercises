using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemindMe.Models
{
    public class EventTypesNonRecurring
    {
        public string NonRecurringEventName { get; set; }
        public string NonRecurringEventDescription { get; set; }
        public string NonRecuringEventCreateDate { get; set; }

       // public int NonRecurringEventId { get; set; }
       // private static int nextNonRecurringEventId = 1;

       //added these lines to try to fix the error nee4d to add a primary key to this model
         
       public int ID { get; set; }

        public IList<User> User { get; set; }
        
        //default constructor
        public EventTypesNonRecurring()
        {
            //NonRecurringEventId = nextNonRecurringEventId;
            //nextNonRecurringEventId++;
            NonRecuringEventCreateDate = DateTime.Today.ToString("MM/dd/yyyy");

        }
        //non default constructor
        public EventTypesNonRecurring(string nonRecurringEventName, string nonRecurringEventDescription) : this()
        {
            NonRecurringEventName = nonRecurringEventName;
            NonRecurringEventDescription = nonRecurringEventDescription;


        }

    }
}
