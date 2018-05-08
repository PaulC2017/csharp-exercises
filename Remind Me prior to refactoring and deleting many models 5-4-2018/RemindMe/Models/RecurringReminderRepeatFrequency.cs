using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemindMe.Models
{
    public class RecurringReminderRepeatFrequency
    {
            public string Name { get; set; }
            public int ID { get; set; }

        public IList<RecurringReminders> RecurringReminders { get; set; }
        public IList<RecurringEvents> UserEventsRecurring { get; set; }
        

    }
}

