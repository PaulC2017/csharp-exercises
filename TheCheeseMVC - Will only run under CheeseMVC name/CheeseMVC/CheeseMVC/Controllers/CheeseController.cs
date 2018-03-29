using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using CheeseMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        static private List<Cheese> cheeses = new List<Cheese>();
        

        // GET: /<controller>/
        public IActionResult Index()

        {
            ViewBag.cheeses = cheeses;

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

            Cheese addCheese = new Cheese(name, descript);


            //cheeses.Add(addCheese.Name, addCheese.Description);

            cheeses.Add(addCheese);


            return Redirect("/Cheese");

        }


        [HttpGet]
        [Route("/Cheese/Delete")]
        public IActionResult Render()
        {

            // put list of existing cheeses into an array for prepping delete view

            ViewBag.list = cheeses;

            return View("Delete");

        }

        [HttpPost]
        [Route("/Cheese/Delete")]
        public IActionResult Delete(string[] cheese)
        {
            //foreach (Cheese item in cheeses)
            for ( int i = cheeses.Count - 1; i >=0; --i)
            {
                for (int j = 0; j <= cheese.Length - 1; ++j)
                {

                    if (cheeses[i].Name.Equals((cheese[j])))
                    {
                        cheeses.Remove(cheeses[i]);
                        
                    }
                }
            }
            return Redirect("/Cheese");

        
               

            }

        }
    }
