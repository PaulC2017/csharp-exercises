using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RemindMe.ViewModels;
using RemindMe.Models;
using RemindMe.Data;
using Microsoft.EntityFrameworkCore;

namespace RemindMe.Controllers
{
    public class RemindMeController : Controller
    {
        private readonly RemindMeDbContext context;

        public RemindMeController(RemindMeDbContext dbContext)
        {
            context = dbContext;
        }
        

        public IActionResult Index()
        {
            // begin checking schedule to send out reminders

           // CheckSchedule.Main();
            return View();
        }
       
        
        public IActionResult RegisterUser()
        {
            RegisterUserViewModel newUser = new RegisterUserViewModel();
            return View(newUser);
        }

        [HttpPost]
        public IActionResult RegisterUser(RegisterUserViewModel registerUserViewModel)
        {
            //  check to see if the user name entered alredy exists
            User checkUserName = context.User.Single(u => u.Username == registerUserViewModel.Username);

            if (checkUserName.Username != null)
                {
                ViewBag.userNameExists = "This user name already exists.  Please select another user name";
                return View(registerUserViewModel);
            }
                if (ModelState.IsValid)
                {
                    User newUser = new User(registerUserViewModel.Username, registerUserViewModel.Password, registerUserViewModel.GCalEmail, registerUserViewModel.GCalEmailPassword);
                    context.User.Add(newUser);
                    context.SaveChanges();
                    ViewBag.User = registerUserViewModel;
                    return View("UserHomePage",newUser);
                }
            
            
            return View(registerUserViewModel);

        }

        public IActionResult UserLogin()
        {
            UserLoginViewModel returningUser = new UserLoginViewModel();
            return View(returningUser);
        }
        [HttpPost]
        public IActionResult Userlogin(UserLoginViewModel userLoginViewModel)
        {
            //  check to see if the user name exists

            try
            {
                User checkUserLogInUserName = context.User.Single(u => u.Username == userLoginViewModel.Username);
            }
            catch (System.InvalidOperationException)
            {
                ViewBag.userNameNotFound = "User Name was not found";
                return View(userLoginViewModel);
            }
            User checkUserLogInInfo = context.User.Single(u => u.Username == userLoginViewModel.Username);
            if (ModelState.IsValid)
            {
                if (checkUserLogInInfo.Password != userLoginViewModel.Password)
                {
                    ViewBag.userPasswordNotCorrect = "The password entered is invalid";
                    return View(userLoginViewModel);
                }
                
                return View("UserHomePage", checkUserLogInInfo);
            }


            return View(userLoginViewModel);

        }

        public IActionResult ScheduleEventsAndReminders()

        {
            ScheduleEventsAndRemindersViewModel scheduleEventsAndReminder = new ScheduleEventsAndRemindersViewModel();

            return View(scheduleEventsAndReminder);
        }

        [HttpPost]
        public IActionResult ScheduleEventsAndReminders(ScheduleEventsAndRemindersViewModel newEventAndReminder)

        {

            if (ModelState.IsValid)
            {
                // create recurring reminder record
                RecurringReminders newRecurringReminder = new RecurringReminders();

                newRecurringReminder.RecurringReminderName = newEventAndReminder.RecurringEventName;
                newRecurringReminder.RecurringReminderDescription = newEventAndReminder.RecurringEventDescription;
                newRecurringReminder.RecurringReminderStartAlertDate = newEventAndReminder.RecurringReminderStartAlertDate;
                newRecurringReminder.RecurringReminderLastAlertDate = newEventAndReminder.RecurringReminderLastAlertDate;
                newRecurringReminder.RecurringReminderRepeatFrequency = newEventAndReminder.RecurringReminderRepeatFrequency;

                context.RecurringReminders.Add(newRecurringReminder);

                // create recurring event record
                EventTypesRecurring newEventTypeRecurring = new EventTypesRecurring();

                newEventTypeRecurring.RecurringEventName = newEventAndReminder.RecurringEventName;
                newEventTypeRecurring.RecurringEventDescription = newEventAndReminder.RecurringEventDescription;

                context.EventTypesRecurring.Add(newEventTypeRecurring);

                // save the new event and reminder to the data base

                context.SaveChanges();
                return View("RecurringEventsAndReminders", newRecurringReminder);

            }
                
                //ViewBag.User = registerUserViewModel;
                return View(newEventAndReminder);
        }


           
        
        public IActionResult UserHomePage()
        {

            return View();

        }



    }
    
}