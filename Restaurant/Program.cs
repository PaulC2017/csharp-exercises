using System;
using System.Collections.Generic;

namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {

            /*MenuItem lasagna = new MenuItem("Lasagna", "Our secret recipe - delicious", "Main Course");
            MenuItem filetMignon = new MenuItem("Filet Mignon", "Our aged beef - delicious", "Main Course");
            MenuItem ceaserSalad = new MenuItem("Ceaser Salad", "Very fresh - delicious", "Appetizer");
            MenuItem calamari = new MenuItem("Calamari", "Our secret sauce - delicious", "Appetizer");
            MenuItem cheeseCake = new MenuItem("Cheese Cake", "Straight from NY - delicious", "Dessert");
            MenuItem pieAlaMode = new MenuItem("Apple Pie a la Mode ", "Nice and hot - delicious", "Dessert"); */

            
            Menu tastys = new Menu("Tasty's - Friday's Specials");
            
            tastys.AddMenuItem("Lasagna", "Our secret recipe - delicious", "Main Course");
            tastys.AddMenuItem("Filet Mignon", "Our aged beef - delicious", "Main Course");
            tastys.ShowMenu();

            
            Console.ReadLine();
            tastys.RemoveMenuItem("Lasagna", 1);
            tastys.ShowMenu();



            Console.ReadLine();
        }

    }

    public class Menu
    {
        public List<MenuItem> menuItems;
        public string Name { get; set; }
        public Menu (string name)
        {

            Name = name;
            menuItems = new List<MenuItem>();
            
        }
        
    public void AddMenuItem(string name, string description, string category)
        {

            MenuItem newItem = new MenuItem(name, description, category);
            menuItems.Add(newItem);

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
            foreach(var item in menuItems)
            {
                Console.WriteLine(item.Name + "  "  + item.Description + "  " + item.Category);
                Console.WriteLine("item.NextMenuId" + "  " + item.NextMenuId);
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

        // constructor
        public MenuItem(string name, string description, string category)
        {

            Name = name;
            Description = description;
            Category = category;
            NextMenuId = ++nextMenuId;



        }
         

        /* private DateTime dateAdded;
         public DateTime DateAdded
         {
             get
             {
                 return dateAdded;
             }
             set
             {
                 dateAdded = DateTime.Today;
             }
         }
         */

         private bool newFlag;
         public bool NewFlag
         {
             get
             {
                 return newFlag;
             }
             set
             {
                 if ((DateTime.Today - DateAdded).TotalDays < 7)
                 {
                     newFlag = true;
                 }
             }
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
            return NextMenuId == menuItemObj.NextMenuId;



        }

        public override int GetHashCode()

        {
            return NextMenuId;

        }





    }

}







