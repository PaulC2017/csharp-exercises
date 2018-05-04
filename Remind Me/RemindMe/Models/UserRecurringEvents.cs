using System;
using RemindMe.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemindMe
{
    public class UserRecurringEvents
    {
        public int UserID { get; set; }
        public User User { get; set; }

        public int RecurringEventsID { get; set; }
        public RecurringEvents RecurringEvents { get; set; }
    }
}
