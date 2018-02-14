using Microsoft.AspNetCore.Mvc;

using System;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller


    {

        public static int NumOfGreetings = 0;

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post' action='/Hello/CreateMessage'>" +
                          "<input type='text' name='name'/>" +
                          "     "     +
                           "<select name='lang'>" +
                                 "<option value='English' selected>English</option>" +
                                 "<option value='French'>French</option>" +
                                 "<option value='Italian'>Italian</option>" +
                                 "<option value='Persian'>Persian</option>" +
                                 "<option value='Spanish'>Spanish</option>" +
                          "</select>"       +
                          "     "           +
                         "<input type='submit' value='Greet me!'/>" +
                         "</form>";

            return Content(html, "text/html");

            // return Redirect("/Hello/Goodbye");
        }

        //Hello
        [Route("/Hello")]
        [HttpPost]
        public IActionResult Display(string name = "World")
        {
            return Content(string.Format("<h1>Hello {0}</h1>", name), "text/html");
        }


        /* Handle requests to /Hello/Paul (URL segment)  where Paul is a URL segment
       

        [Route("/Hello/{name}")]
        public IActionResult Index2(string name)
        {
            return Content(string.Format("<h1>Hello {0}</h1>", name), "text/html");
        }

        */ 

        public  IActionResult CreateMessage(string name, string lang)
        {
        // manage the total greetings delivered
           string greeting = "";
           ++NumOfGreetings;
           string total = NumOfGreetings.ToString();
            

        // manage the number of greetings delivered to a specific user
           string yourTotal = Request.Cookies[name];

            if (yourTotal == "")
            {
                Response.Cookies.Append(name, "1");
                yourTotal = "1";
            }
            else {
                int yourNumGreetings = Convert.ToInt32(yourTotal);
                ++yourNumGreetings;
                Response.Cookies.Delete(name);
                yourTotal = yourNumGreetings.ToString();
                Response.Cookies.Append(name, yourTotal);
                
            }

        
            switch (lang)
            {
                case "French":
                    greeting = "Bonjour";
                    break;
                case "Italian":
                    greeting = "Ciao";
                    break;
                case "Persian":
                    greeting = "Salam";
                    break;
                case "Spanish":
                    greeting = "Hola";
                    break;
                default:
                    greeting = "Hello";
                    break;
            }


            return Content( string.Format("<h1> {0} {1} </h1>  We have given a total of  {2}" +
                             " greeting(s). <br>  We have given {3} greeting(s) to you. ", greeting, name, total, yourTotal ), "text/html" );
        }

        public IActionResult Goodbye()
        {
              return Content("Goodbye");
        }
    }
}
