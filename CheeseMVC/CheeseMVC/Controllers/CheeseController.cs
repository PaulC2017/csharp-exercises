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
            
            for (int i=0; i<=cheese.Length-1; ++i)
             {
                Cheeses.Remove(cheese[i]);
              
                 }
            
            return Redirect("/Cheese");

        }
        
    }
}
