﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RemindMe.Data;
using RemindMe.Models;
using Microsoft.EntityFrameworkCore;

namespace RemindMe.ViewModels
{
    public class ScheduleEventsAndRemindersViewModel
    {

        [Required(ErrorMessage = "An Event Name is Required")]
        [Display(Name = "Event Name")]
        public string RecurringEventName { get; set; }

        // we will use this value for the RecurringReminderName in teh controller

        [Required(ErrorMessage = "A description of the event is requred")]
        [Display(Name = "Event Description")]
        public string RecurringEventDescription { get; set; }

        // we will use this value for the RecurringReminderDescription in the controller

        [Required(ErrorMessage = "Enter the date you want to start receiving the text message alerts")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Alert Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public string RecurringReminderStartAlertDate { get; set; }

        [Required(ErrorMessage = "Enter the stop date for receiving the text message alerts")]
        [DataType(DataType.Date)]
        [Display(Name = "Last Alert Date ")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public string RecurringReminderLastAlertDate { get; set; }

        // we will send a text message once a day on from start date through the last alart date

        [Required(ErrorMessage = "Enter the stop date for receiving the text message alerts")]
        [Display(Name = "Repeat Alert Frequency (ie - monthly, annually)")]
        public string RecurringReminderRepeatFrequency { get; set; }

        //*public string RecuringReminderCreateDate { get; set; }
        //public int ID { get; set; }*/
        [Required]
        [Display(Name = "User")]
        public int UserId { get; set; }

        public List<SelectListItem> Users { get; set; }

        public ScheduleEventsAndRemindersViewModel()  // default constructor needed to make model binding work in the EntityFramework 
        {

        }
        public ScheduleEventsAndRemindersViewModel(IEnumerable<User> users)
        {

            Users = new List<SelectListItem>();

            foreach (User user in users.ToList())

            {

                Users.Add(new SelectListItem
                {
                    Value = (user.ID.ToString()),
                    Text = user.Username.ToString()

                });

            }

        }
    }
}
