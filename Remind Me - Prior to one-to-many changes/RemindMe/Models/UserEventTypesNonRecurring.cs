using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemindMe.Models
{
    public class UserEventTypesNonRecurring
    {
        public int UserId{ get; set; }
        public User User { get; set; }

        public int NonRecurringEventId { get; set; }
        public EventTypesNonRecurring EventTypesNonRecurring { get; set; }

    }
}
