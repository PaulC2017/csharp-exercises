using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {


        static private Dictionary<string, string> Cheeses = new Dictionary<string, string>();
       

        // GET: /<controller>/
        public IActionResult Index()
            
        {
           

            ViewBag.cheeses = Cheeses;
            
            return View();
        }
        
        public IActionResult Add()
        {

            return View();


        }
        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(string name, string descript)
        {
            // Add the new cheese to my existing cheeses

            Cheeses.Add(name,descript);
           
            return Redirect("/Cheese");





        }

       
        [HttpGet]
        [Route("/Cheese/Delete")]
        public IActionResult Render()
        {
            // Delete the  cheese from existing cheeses

            // put list of existing cheeses into an array for prepping delete form

            string[] cheeseList = new string[Cheeses.Count];

               
            
                int i = 0;
                foreach (KeyValuePair<string, string> item in Cheeses)
                {
                    cheeseList[i] = item.Key;
                    ++i;
                }

                ViewBag.list = cheeseList;

                return View("Delete");
            
        }
        [HttpPost]
        [Route("/Cheese/Delete")]
        public IActionResult Delete(string[] cheese)
        {
            Dictionary<string, string> Tempy = new Dictionary<string, string>();  // a place holder for the modifcations to
                                                                                  // our Cheeeses dictionary
            
            int i = 0;
            string check = "";
            foreach(KeyValuePair<string,string> item in Cheeses)
            {
                check = cheese[i];

                if (check != "on")
                {
                    Tempy.Add(item.Key, item.Value);
                    return Content("We got != on");
                }

                ++i;
                if (i >= cheese.Length)
                {
                    break;
                }
            }
            return Content("We did not get an !=");
               

            /* for (int i=0; i<cheese.Length; ++i)
             {

              if (cheese[i] == "on")
                 {
                     Console.WriteLine("we do have an on value - the issue is with the remove");



                 }



             }  */
           // Cheeses = Tempy;
            //Tempy.Clear();
            //return Redirect("/Cheese");
           
        }





    }
}
