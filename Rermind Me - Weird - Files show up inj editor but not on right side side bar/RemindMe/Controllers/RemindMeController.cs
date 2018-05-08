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
            //   In the Register User IAction Result in the RemindeMe Controller
            //  the try/catch is necessary in case 
            //   the User table has no entries.
            //
            //
            /*
             * This code is necessary if there are no records in the User database - Once there
             * are records in teh User database this code is not necessary!!!
             * 
             * try
            {
                User checkUserName = context.User.Single(u => u.Username == registerUserViewModel.Username);
            }
            catch (System.InvalidOperationException)
            {
                if (ModelState.IsValid)
                {
                    User newUser = new User(registerUserViewModel.Username, registerUserViewModel.Password, registerUserViewModel.GCalEmail, registerUserViewModel.GCalEmailPassword);
                    context.User.Add(newUser);
                    context.SaveChanges();
                    ViewBag.User = registerUserViewModel;
                    return View("UserHomePage", newUser);
                }
            }
            */

            //check to see if the user name entered already exists
             

            //checkUserName = context.User.Single(u => u.Username == registerUserViewModel.Username);

            User checkUserName = context.User.FirstOrDefault(u => u.Username == registerUserViewModel.Username);

            if (checkUserName != null)
            { 
                ViewBag.userNameExists = "This user name already exists.  Please select another user name";
                ViewBag.colon = ":";
                return View(registerUserViewModel);
            }
            if (ModelState.IsValid)
            {
                User newUser = new User(registerUserViewModel.Username, registerUserViewModel.Password, registerUserViewModel.GCalEmail, registerUserViewModel.GCalEmailPassword);
                context.User.Add(newUser);
                context.SaveChanges();
                ViewBag.User = registerUserViewModel;
                return View("UserHomePage", newUser);
            }
            return View(registerUserViewModel);
            /*User checkUserName = context.User.Single(u => u.Username == registerUserViewModel.Username);
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
            */




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
            ScheduleEventsAndRemindersViewModel scheduleEventsAndReminder = new ScheduleEventsAndRemindersViewModel(context.User.ToList());


            return View(scheduleEventsAndReminder);
        }

        [HttpPost]
        public IActionResult ScheduleEventsAndReminders(ScheduleEventsAndRemindersViewModel newEventAndReminder)

        {

            if (ModelState.IsValid)
            {
                // create recurring reminder record

                User newUser = context.User.Single(u => u.ID == newEventAndReminder.UserId);
                RecurringReminders newRecurringReminder = new RecurringReminders(newEventAndReminder.RecurringEventName,
                                                              newEventAndReminder.RecurringEventDescription,
                                                              newEventAndReminder.RecurringReminderStartAlertDate,
                                                              newEventAndReminder.RecurringReminderLastAlertDate,
                                                              newEventAndReminder.RecurringReminderRepeatFrequency);
                newRecurringReminder.User= newUser;

                context.RecurringReminders.Add(newRecurringReminder);

                // create recurring event record
                RecurringEvents newEventTypeRecurring = new RecurringEvents(newEventAndReminder.RecurringEventName, 
                                                                            newEventAndReminder.RecurringEventDescription);
                newEventTypeRecurring.User = newUser;

                context.RecurringEvents.Add(newEventTypeRecurring);

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