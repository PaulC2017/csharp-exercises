using System;

namespace ClassDesignExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle newCircle = new Circle("Circle 1", "Circle", 4.4);


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


            Rectangle newRectangle = new Rectangle("Rectangle 1", "Rectangle", 3.8, 4.4);

            Console.WriteLine("New Rectangle Shape type = " + newRectangle.ShapeType);
            Console.WriteLine("New Rectangle Name = " + newRectangle.Name);
            Console.WriteLine("New Rectangle Date Created = " + newRectangle.DateCreated);
            Console.WriteLine("New Rectangle Id = " + newRectangle.ShapeId);
            Console.WriteLine("New Rectangle Length = " + newRectangle.Length);
            Console.WriteLine("New Rectangle Width = " + newRectangle.Width);
            Console.WriteLine("The area of Rectangle " + newRectangle.Name + " with Length " + newRectangle.Length +
                              " and Width " + newRectangle.Width + " is " + newRectangle.Area());

            Console.ReadLine();

            newRectangle.ShapeType = "Oblong";
            Console.WriteLine("New Rectangle Shape type = " + newRectangle.ShapeType);
            Console.ReadLine();

            Square newSquare = new Square("Square 1", "Square", 3.8, 4.4);

            Console.WriteLine("New Square Shape type = " + newSquare.ShapeType);
            Console.WriteLine("New Square Name = " + newSquare.Name);
            Console.WriteLine("New Square Date Created = " + newSquare.DateCreated);
            Console.WriteLine("New Square Id = " + newSquare.ShapeId);
            Console.WriteLine("New Square Length = " + newSquare.Length);
            Console.WriteLine("New Square Width = " + newSquare.Width);
            Console.WriteLine("The area of Square " + newSquare.Name + " with Length " + newSquare.Length +
                              " and Width " + newSquare.Width + " is " + newSquare.Area());

            Console.ReadLine();

            newSquare.ShapeType = "Oblong";
            Console.WriteLine("New Square Shape type = " + newSquare.ShapeType);
            Console.ReadLine();



        }
    }

    
     public abstract class Shape  
    {
        private static int shapeId = 0;
        public int ShapeId
        {
            get { return shapeId; }
            set { shapeId = value; }
        }
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

        public  Shape(string shapeType)
        {
            ShapeType = shapeType;
            ShapeId = ++shapeId;
            DateCreated = DateTime.Today;

        }

    }

    class Circle : Shape
    {


        private double radiuus;
        public double Radiuus { get { return radiuus; } set { radiuus = value; } }


        private string name;
        public string Name { get { return name; } set { name = value; } }


        public  Circle(string name, string shapeType, double radiuss) : base(shapeType)
        {
            Name = name;
            Radiuus = radiuss;
        }

        public double Area()
        {
            return Math.PI * Radiuus * Radiuus;

        }

    }



    class Rectangle : Shape
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private double length;
        public double Length
        {
            get { return length; }


            set
            {

                bool correctLength = false;

                do
                {

                    if (value < 0)
                    {

                        Console.WriteLine("Invalid Lewngth  - Must be a Positive Number");
                        Console.WriteLine("Enter Length");
                        value = double.Parse(Console.ReadLine());
                    }

                    else { length = value; correctLength = true; }


                } while (correctLength == false);
            }
        }
        private double width;
        public double Width
        {

            get { return width; }


            set
            {

                bool correctWidth = false;

                do
                {

                    if (value < 0)
                    {

                        Console.WriteLine("Invalid Lewngth  - Must be a Positive Number");
                        Console.WriteLine("Enter Length");
                        value = double.Parse(Console.ReadLine());
                    }

                    else { width = value; correctWidth = true; }


                } while (correctWidth == false);

            }
        }

        public  Rectangle(string name, string shapeType, double length, double width) : base(shapeType)
        {
            Name = name;
            Length = length;
            Width = width;

        }

       
        public double Area()
        {
            return Length * Width;

        }


    }

    class Square : Rectangle
    {
        
        public Square(string name, string shapeType, double length, double width) : base( name,  shapeType,  length,  width)
        {
           
        }


    }
}
          


