using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            // test data
            /*MenuItem lasagna = new MenuItem("Lasagna", "Our secret recipe - delicious", "Main Course");
            MenuItem filetMignon = new MenuItem("Filet Mignon", "Our aged beef - delicious", "Main Course");
            MenuItem ceaserSalad = new MenuItem("Ceaser Salad", "Very fresh - delicious", "Appetizer");
            MenuItem calamari = new MenuItem("Calamari", "Our secret sauce - delicious", "Appetizer");
            MenuItem cheeseCake = new MenuItem("Cheese Cake", "Straight from NY - delicious", "Dessert");
            MenuItem pieAlaMode = new MenuItem("Apple Pie a la Mode ", "Nice and hot - delicious", "Dessert"); */

            //create new menu and stroe it in variabvle titled tastys with a name of Tasty's - Friday's Specials
            Menu tastys = new Menu("Tasty's - Friday's Specials");
            
            //add 3 menu items to teh menu
            tastys.AddMenuItem("Lasagna", "Our secret recipe - delicious", "Main Course");
            tastys.AddMenuItem("Filet Mignon", "Our aged beef - delicious", "Main Course");
            tastys.AddMenuItem("Cheese Cake", "Straight from NY - delicious", "Dessert");

            //show the menu
            tastys.ShowMenu();
            Console.ReadLine();

            //remove a menu item and show the resulting menu
            tastys.RemoveMenuItem("Lasagna", 1);  // note we knbow the id is one - in prodcustion ShowMenuIyem will display the ID for you
            tastys.ShowMenu();
            Console.ReadLine();

            //add another menu item called cheese cake and see if it gets rejected
            //search for menu tem Cheese Cake - it should be there twice
            // and finally search for an item tyhat is not there - returns message saying menu item not found
            tastys.AddMenuItem("Cheese Cake", "Straight from NY - delicious", "Dessert");
            tastys.AddMenuItem("Cheese Cake", "Straight - NY - delicious", "Dessert");
            tastys.AddMenuItem("Cheese Cake", "Straight from NY - delicous", "Dessert");
            tastys.GetMenuItem("Cheese Cake");
            tastys.GetMenuItem("Cheese ake");

            Console.ReadLine();
            MenuItem compare1 = tastys.GetMenuItem("Filet Mignon");
            MenuItem compare2 = tastys.GetMenuItem("Cheese Cake");
            Console.WriteLine("We are here at the  compare section - hit return to execut4e teh compare commands test");
            Console.ReadLine();
            if (compare1.Equals(compare2))
            {
                Console.WriteLine(compare1.Name + " is the same as "+ compare2.Name);
            }
            else
            {
                Console.WriteLine(compare1.Name + " is not the same as " + compare2.Name);

            }
            Console.ReadLine();
        }
    }

    public class Menu
    {
        public List<MenuItem> menuItems;
        public string Name { get; set; }
        
        string DateMenuUpdated; 

        //constructor
        public Menu (string name)
        {
            Name = name;
            menuItems = new List<MenuItem>();
            DateMenuUpdated = DateTime.Today.ToShortDateString();  // render just the date 02/23/2018 and not the default time 12:00 am from DateTime
        }

        public void AddMenuItem(string name, string description, string category)
        {

           

            MenuItem newItem = new MenuItem(name, description, category);
            if (menuItems.IndexOf(newItem) == -1)
            {
                menuItems.Add(newItem);
                DateMenuUpdated = DateTime.Today.ToShortDateString();
            }
            else
            {
                Console.WriteLine("This menu item, " + name + ", already exists in the Menu");
            }
            
        }

        public void RemoveMenuItem(string name, int menuItemId)
        {
            MenuItem itemToRemove = null; ;
            foreach (MenuItem item in menuItems)
            {
                if (item.Name == name  & item.GetHashCode() == menuItemId)
                {
                    itemToRemove = item;
                    break;
                }
            }
            menuItems.Remove(itemToRemove);
        }

        public MenuItem GetMenuItem(string item1)  
        {
            
            /*
            //find one  MenuItem where the name = item1 the method return type needs to be MenuItem

             MenuItem result = (from a in menuItems where a.Name.ToString() == item1 select a).SingleOrDefault();

            return result;
            */
            // or:

            MenuItem matches = menuItems.Find(item => item.Name == item1);

            return matches;
            /*

            
            // find all MenuItems with the name  item1 and put the results in a list -  method return type needs to be List<MenuItem> or Ienumerable<MenuList> 
                                                                                       //if you want to return the results vs just printing them

            List<MenuItem>  matches = menuItems.FindAll(item => item.Name == item1);



            //find all menu items that match the input item1 - method retyrn tyoe needs to be Ienumerable<MenuItem> if you want to return the results vs just printing them

            var match = menuItems.Where(item => item.Name == item1);  
            Console.WriteLine("the type of match is " + match.GetType().ToString());
           
            Console.WriteLine("here is what is in matches");

            foreach (MenuItem item in matches) 
            {
                Console.WriteLine(item.Name + " " +  item.NextMenuId);
            }
            Console.WriteLine("here is what is in match");
            Console.WriteLine();

            foreach ( var item in match)
            {
                Console.WriteLine(item.Name + " " + item.NextMenuId);
            }

            var matchCount = match.Count();

            if (matchCount == 0 || matches.Count == 0)
            {
                Console.WriteLine(item1 + " Menu Item Not Found");
                Console.WriteLine();
            }
            return matches; 
           */


        }
        
        public void ShowMenu()
        {
            Console.WriteLine("Our Menu Was Updated as of " + DateMenuUpdated);

            foreach (MenuItem item in menuItems)
            {
                Console.WriteLine("Date Added = " + item.DateAdded.ToString());
                Console.WriteLine(item.Name + "  "  + item.Description + "  " + item.Category);
                Console.WriteLine("item.NextMenuId" + "  " + item.NextMenuId);
                    
                if (item.DateAdded - int.Parse(DateTime.Today.ToString("yyyyMMdd")) < 7)
                {
                    Console.WriteLine("New Item!!");
                }
            }
        }

       /* // This does not use the FindAll() or .Where methods - it it4erates thru the entire list looking for matches
        * 
        * public void ShowMenuItem(string name)
        {
            bool itemFound = false;
            foreach (MenuItem item in menuItems)
            {
                if (item.Name == name)
                {
                    Console.WriteLine(item.Name + "  " + item.Description + "  " + item.Category + " ID = " + item.NextMenuId);
                    itemFound = true;
                }
            }

            if (!itemFound)
            {
                Console.WriteLine(name + " Menu Item Not Found");
            }
        }
        */
        public bool CompareMenuIems(string item1, string items)
        {
            return true;
        }

    }

    public class MenuItem
    {
        // declasre class variables
        private static int nextMenuId = 0;

        // declare object fields with no get set restrictions
        public int NextMenuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        // declare fields with acsessor properties

        private int dateAdded = int.Parse(DateTime.Today.ToString("yyyyMMdd"));      
        public int DateAdded
        {

           get { return dateAdded; }
           set { DateAdded = dateAdded; }
               
        }
        
        // constructor
        public MenuItem(string name, string description, string category)
        {

            Name = name;
            Description = description;
            Category = category;
            NextMenuId = ++nextMenuId;
            //DateAdded = dateAdded;  - toook thisout and the program worked without it!!!   set { DateAdded = dateAdded; } must be how DateAdded gets constructed

        }

        public override bool Equals( object o)
        {
            if (o == this)
            {
                return true;
            }
            if (o == null)
            {
                return false;
            }

            if (o.GetType() != GetType())
            {
                return false;
            }

            MenuItem menuItemObj = o as MenuItem;

            if (Name == menuItemObj.Name)
            {
                if (Description == menuItemObj.Description)
                {
                    if (Category == menuItemObj.Category)
                    {
                        return true;
                    }
                }
            }

            return false;



        }

        public override int GetHashCode()

        {
            return NextMenuId;

        }





    }

}







