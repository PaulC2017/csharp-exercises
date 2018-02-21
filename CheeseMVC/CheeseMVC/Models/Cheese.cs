using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        
        // the fields

        public string Name { get; set; }
        public string Description { get; set; }


        // the constructor 
       
            public Cheese (string name, string description)
        {
            Name = name;
            Description = description;
        }

        // method to add a cheese to the dictionary MyCheeses

       

       
    }


}

   


