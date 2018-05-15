using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RemindMe.ViewModels;
using RemindMe.Models;
using RemindMe.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.ObjectModel;
using System.Collections;
using System.Dynamic;




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
                User newUser = new User(registerUserViewModel.Username, registerUserViewModel.Password, registerUserViewModel.GCalEmail, registerUserViewModel.GCalEmailPassword, registerUserViewModel.CellPhoneNumber);
                context.User.Add(newUser);
                context.SaveChanges();
                ViewBag.User = registerUserViewModel;
                
                HttpContext.Session.SetString("Username", newUser.Username);
                HttpContext.Session.SetInt32("ID", newUser.ID);
                HttpContext.Session.SetString("CellPhoneNumber", newUser.CellPhoneNumber);
                return View("UserHomePage", newUser);
                
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

                HttpContext.Session.SetString("Username", checkUserLogInInfo.Username);  //capture Username for use elsewhere in this app
                HttpContext.Session.SetInt32("ID", checkUserLogInInfo.ID);  //capture ID for use elsewhere in this app
                return View("UserHomePage", checkUserLogInInfo);
            }


            return View(userLoginViewModel);

        }

        public IActionResult ScheduleEventsAndReminders()
        {
            ScheduleEventsAndRemindersViewModel scheduleEventsAndReminder = new ScheduleEventsAndRemindersViewModel(context.User.ToList());
            
            if (HttpContext.Session.GetString("Username") == "")
            {
                return View("Index");
            }
            ViewBag.Username = HttpContext.Session.GetString("Username");
            return View(scheduleEventsAndReminder);
        }

        [HttpPost]
        public IActionResult ScheduleEventsAndReminders(ScheduleEventsAndRemindersViewModel newEventAndReminder)

        {

            if (ModelState.IsValid)
            {
                // create recurring reminder record

               
                //User newUser = context.User.Single(u => u.ID == newEventAndReminder.UserId);
                User newUser = context.User.Single(u => u.Username == HttpContext.Session.GetString("Username"));
                RecurringReminders newRecurringReminder = new RecurringReminders(newEventAndReminder.RecurringEventName,
                                                              newEventAndReminder.RecurringEventDescription,
                                                              newEventAndReminder.RecurringReminderStartAlertDate,
                                                              newEventAndReminder.RecurringReminderLastAlertDate,
                                                              newEventAndReminder.RecurringReminderRepeatFrequency,
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

        public IActionResult Test()
        {
           if ( HttpContext.Session.GetString("Username")  == "")
              {
                return View("Index");
              }

            /*
            // Generate List of Recurring Reminders
            IList < RecurringReminders > recurringReminders =
                               context.RecurringReminders.Include(rr => rr.User).ToList();
            // reduce the list to those recurring reminders associated with the current user
          

            var userRecurringReminders = 
                recurringReminders.Where(rr => rr.UserId == HttpContext.Session.GetInt32("ID"));
           */




            // retrieve only those records for the current user - a better way to do this 
            //than the above commented out code 

            //IList<RecurringReminders> userRecurringReminders = context.RecurringReminders.Include(u => u.User).ToList().Where(User == HttpContext.Session.GetString("Username") ) ;
            //IList<RecurringReminders> userRecurringReminders = context.RecurringReminders.Include(u => u.User).ToList();
            //IList<RecurringReminders> userRecurringReminders = context.RecurringReminders.Include(u => u.User).ToList();
            var userRecurringReminders = from recurringReminder in context.RecurringReminders
                                         where (recurringReminder.UserId == HttpContext.Session.GetInt32("ID"))
                                         select new
                                         {
                                             recurringReminder.RecurringReminderName,
                                             recurringReminder.RecurringReminderDescription,
                                             recurringReminder.RecurringReminderStartAlertDate,
                                             recurringReminder.RecurringReminderLastAlertDate,
                                             recurringReminder.RecurringReminderRepeatFrequency
                                         };

           
           

           
            return View(userRecurringReminders);
        }
        
       public ActionResult SingleUserRecurringEventsAndReminders()
       {

            if (HttpContext.Session.GetString("Username") == "")
            {
                return View("Index");
            }

            ViewBag.Username = HttpContext.Session.GetString("Username");
            dynamic userRecurringReminders = (from ch in context.RecurringReminders
                                              join
                                              ca in context.User
                                              on ch.UserId equals ca.ID
                                              where ca.ID == HttpContext.Session.GetInt32("ID")
                                              select new
                                              {
                                               ch.RecurringReminderName,
                                               ch.RecurringReminderDescription,
                                               ch.RecuringReminderCreateDate,
                                               ch.RecurringReminderStartAlertDate,
                                               ch.RecurringReminderLastAlertDate,
                                               ch.RecurringReminderFirstAlertTime,
                                               ch.RecurringReminderSecondAlertTime,
                                               ch.RecuringReminderAlertFrequency,
                                               ch.RecurringReminderRepeatFrequency
                                              }).AsEnumerable().Select(c => c.ToExpando());
            return View(userRecurringReminders);

        }
        
        public IActionResult UserLogout()
        {
            HttpContext.Session.SetString("Username", "");
            return View("Index");
        }


        public IActionResult UserHomePage()
        {
            if (HttpContext.Session.GetString("Username") == "")
            {
                return View("Index");
            }

            User currentUser = context.User.Single(u => u.Username == HttpContext.Session.GetString("Username"));
            return View(currentUser);
        }



    }
    
}