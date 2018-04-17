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

        public IActionResult UserHomePage()
        {

            return View();

        }



    }
    
}