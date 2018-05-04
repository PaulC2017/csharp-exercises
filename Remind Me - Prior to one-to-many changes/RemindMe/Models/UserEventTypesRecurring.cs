using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemindMe.Models
{
    public class UserEventTypesRecurring
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int RecurringEventId { get; set; }
        public EventTypesNonRecurring EventTypesRecurring { get; set; }

    }
}
