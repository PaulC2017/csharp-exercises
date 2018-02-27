using System;

namespace ClassDesignExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle newCircle = new Circle("Round 1", "Circle", 4.4);
           
             
            Console.WriteLine("New Circle Shape type = " + newCircle.ShapeType);
            Console.WriteLine("New Circle Name = " + newCircle.Name);
            Console.WriteLine("New Circle Date Created = " + newCircle.DateCreated);
            Console.WriteLine("New Circle Id = " + newCircle.ShapeId);
            Console.WriteLine("New Circle Radiuus = " + newCircle.Radiuus);
            

            Console.ReadLine();
            newCircle.ShapeType = "Oblong";
            Console.ReadLine();

            Console.WriteLine("New Circle Shape type = " + newCircle.ShapeType);
            Console.WriteLine("New Circle Name = " + newCircle.Name);
            Console.WriteLine("New Circle Date Created = " + newCircle.DateCreated);
            Console.WriteLine("New Circle Id = " + newCircle.ShapeId);
            Console.WriteLine("New Circle Radiuus = " + newCircle.Radiuus);
            Console.ReadLine();

            //double area = newCircle.Area();
            Console.WriteLine("The area of circle " + newCircle.Name + " with radiuus " + newCircle.Radiuus + " is " + newCircle.Area());

            Console.ReadLine();
        }
    }


    
    class Shape
    {
        private static int shapeId = 0;
        public  int ShapeId { get; set; }

        private DateTime dateCreated = DateTime.Today;
        public DateTime DateCreated { get; set; }

        private string shapeType;
        //public string ShapeType //{ get; set; }
       public string ShapeType
        {
            get { return shapeType; }
            set
            {
                bool correctEntry = false;

                do
                {

                    if (value.ToLower() != "circle" & value.ToLower() != "rectangle" & value.ToLower() != "square")
                    {

                        Console.WriteLine("Invalid Shape Type - Must be Circle, Rectangle or Square");
                        Console.WriteLine("Enter correct shape type");
                        value = Console.ReadLine();
                    }

                    else { shapeType = value.ToLower(); correctEntry = true; }


                } while (correctEntry == false);



            }
        }
        
        public Shape(string shapeType)
        {
            ShapeType = shapeType;
            ShapeId = ++shapeId;
            DateCreated = DateTime.Today;

        }

    }

      class Circle : Shape
        {


            private double radiuus;
            public double Radiuus { get; set; }
           

            private string name;
            public string Name { get; set; }
            

        public Circle(string name, string shapeType, double radiuss) : base( shapeType)
            {
               Name = name;
               Radiuus = radiuss;
            }

            public  double Area()
            {
            return  Math.PI * Radiuus * Radiuus;
           
            } 

        }



        /* class Rectangle : Shape
         {
                 private string name;
                 public string Name { get; set; }
             }

         class Square : Rectangle
         {
                 private string name;
                 public string Name { get; set; }
             }
          */
}

