using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemindMe.Models
{
    public class NonRecurringReminders
    {
        public string NonRecurringReminderName { get; set; }
        public string NonRecurringReminderDescription { get; set; }
        public string NonRecuringReminderCreateDate { get; set; }
        public string NonRecurringReminderStartAlertDate { get; set; }
        public string NonRecurringReminderLastAlertDate { get; set; }
        public string NonRecurringReminderFirstAlertTime { get; set; }
        public string NonRecurringReminderSecondAlertTime { get; set; }
        public string NonRecuringReminderAlertFrequency { get; set; }  //how often the alert is sent for an event

        public int NonRecurringReminderId { get; set; }
        private static int nextNonRecurringReminderId = 1;

        //default constructor
        public NonRecurringReminders()
        {
            NonRecurringReminderId = nextNonRecurringReminderId;
            nextNonRecurringReminderId++;
            NonRecuringReminderCreateDate = DateTime.Today.ToString("MM/dd/yyyy");

        }
        //non default constructor
        public NonRecurringReminders(string recurringReminderName, string recurringReminderDescription, string recurringReminderStartAlertDate,
                                string recurringReminderLastAlertDate, string recurringReminderFirstAlertTime,
                                string recurringReminderSecondAlertTime, string recuringReminderAlertFrequency) : this()
        {
            NonRecurringReminderName = recurringReminderName;
            NonRecurringReminderDescription = recurringReminderDescription;
            NonRecurringReminderStartAlertDate = RemoveChar(recurringReminderStartAlertDate, "/");
            NonRecurringReminderLastAlertDate = RemoveChar(recurringReminderLastAlertDate, "/");
            NonRecurringReminderFirstAlertTime = ConvertTo24HourFormat(recurringReminderFirstAlertTime);
            NonRecurringReminderSecondAlertTime = ConvertTo24HourFormat(recurringReminderSecondAlertTime);
            NonRecuringReminderAlertFrequency = recuringReminderAlertFrequency;
        }
        public string RemoveChar(string theString, string charsToRemove)
        {
            theString = theString.Replace(charsToRemove, "");
            return theString;
        }

        public string ConvertTo24HourFormat(string time)
        {
            time = RemoveChar(time, ":");
            if (time.IndexOf("AM") == -1)
            {
                time = RemoveChar(time, "PM");
                int timeInt = int.Parse(time);
                timeInt = timeInt + 12;
                time = timeInt.ToString();
            }
            else
            {
                time = RemoveChar(time, "AM");
            }
            return time;
        }
    }
}
