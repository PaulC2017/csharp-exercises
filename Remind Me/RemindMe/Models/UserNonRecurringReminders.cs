using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemindMe.Models
{
    public class UserNonRecurringReminders
    {

        public int UserID { get; set; }
        public User User { get; set; }

        public int NonRecurringRemindersID { get; set; }
        public NonRecurringReminders NonRecurringReminders { get; set; }
    }
}


