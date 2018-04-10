using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemindMe.Models
{
    public class RecurringReminders
    {
        public string RecurringReminderName { get; set; }
        public string RecurringReminderDescription { get; set; }
        public string RecuringReminderCreateDate { get; set; }
        public string RecurringReminderStartAlertDate { get;set;}
        public string RecurringReminderLastAlertDate { get; set; }
        public string RecurringReminderFirstAlertTime { get; set; }
        public string RecurringReminderSecondAlertTime { get; set; }
        public string RecuringReminderAlertFrequency { get; set; }  // how often the alert is sent for an event
        public string RecurringReminderRepeatFrequency { get; set; }  // does the event repeat annually, monthly, etc?

        public int RecurringReminderId { get; set; }
        private static int nextRecurringReminderId = 1;

        //default constructor
        public RecurringReminders()
        {
            RecurringReminderId = nextRecurringReminderId;
            nextRecurringReminderId++;
            RecuringReminderCreateDate = DateTime.Today.ToString("MM/dd/yyyy");

        }
        //non default constructor
        public RecurringReminders(string recurringReminderName, string recurringReminderDescription,string recurringReminderStartAlertDate, 
                                string recurringReminderLastAlertDate, string recurringReminderFirstAlertTime, 
                                string recurringReminderSecondAlertTime, string recuringReminderAlertFrequency) : this()
        {
            RecurringReminderName = recurringReminderName;
            RecurringReminderDescription = recurringReminderDescription;
            RecurringReminderStartAlertDate = RemoveChar(recurringReminderStartAlertDate,"/");   
            RecurringReminderLastAlertDate = RemoveChar(recurringReminderLastAlertDate, "/");    
            RecurringReminderFirstAlertTime = ConvertTo24HourFormat(recurringReminderFirstAlertTime); 
            RecurringReminderSecondAlertTime = ConvertTo24HourFormat(recurringReminderSecondAlertTime);  
            RecuringReminderAlertFrequency = recuringReminderAlertFrequency;
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
