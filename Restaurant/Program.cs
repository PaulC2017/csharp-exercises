using System;
using System.Collections.Generic;

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

            //add another menu item called cheese cake and see if both show up in the menu 
            //search for menu tem Cheese Cake - it should be there twice
            // and finally search fro an item tyhat isnot there - returns message saying menu item not found
            tastys.AddMenuItem("Cheese Cake", "Straight from NY - delicious", "Dessert");
            tastys.ShowMenuItem("Cheese Cake");
            tastys.ShowMenuItem("Cheese ake");
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
            menuItems.Add(newItem);
            DateMenuUpdated = DateTime.Today.ToShortDateString();
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

        public void ShowMenuItem(string name)
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

        public override bool Equals(object o)
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







