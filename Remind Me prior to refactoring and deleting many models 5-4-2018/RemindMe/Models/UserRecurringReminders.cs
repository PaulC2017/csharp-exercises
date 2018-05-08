using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemindMe.Models
{
    public class UserRecurringReminders
    {
       
            public int UserID { get; set; }
            public User User { get; set; }

            public int RecurringRemindersID { get; set; }
            public RecurringReminders RecurringReminders { get; set; }
    }
}


