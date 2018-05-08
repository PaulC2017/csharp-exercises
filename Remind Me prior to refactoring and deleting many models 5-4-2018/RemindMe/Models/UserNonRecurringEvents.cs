using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemindMe.Models
{
    public class UserNonRecurringEvents
    {
        public int ID { get; set; }
        public User User { get; set; }
        /*
        public int NonRecurringEventsID { get; set; }
        public NonRecurringEvents NonRecurringEvents { get; set; }
        */
    }
}
