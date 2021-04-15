//Example1
//Code before Open Closed Principle. 

using System;
using System.Collections.Generic;

//Only Rectangles
namespace OCP
{	
	public class Rectangle{  
   		private double _height;  
   		private double _width;
		
		public Rectangle(double height, double width)
		{
			this._height = height;
			this._width = width;
		}
		
		// Gets or sets the height
		public double Height
		{
		  get { return _height; }
		  set { _height = value; }
		}

		// Gets or sets width
		public double Width
		{
		  get { return _width; }
		  set { _width = value; }
		}
	} 

	public class AreaCalculator {
		
   		public double TotalArea(List<Rectangle> arrRectangles)  
   		{  
			double area = 0; 
			foreach(var objRectangle in arrRectangles)  
			{  
				area += objRectangle.Height * objRectangle.Width;  
			}  
			return area;  
   		}  
	} 
	
	public class Program
	{
		public static void Main(string[] args)
		{
			List<Rectangle> list = new List<Rectangle>();
			
			var rect1 = new Rectangle(2.50, 4.30);
			var rect2 = new Rectangle(3.10, 1.85);
			
			list.Add(rect1);
			list.Add(rect2);
			
			var areaCalculator = new AreaCalculator();
			var result = areaCalculator.TotalArea(list);
			Console.WriteLine(result);
		}
	}
}

//Rectangles and Circles
namespace OCP
{	
	public class Rectangle{  
   		private double _height;  
   		private double _width;
		
		public Rectangle(double height, double width)
		{
			this._height = height;
			this._width = width;
		}
		
		// Gets or sets the height
		public double Height
		{
		  get { return _height; }
		  set { _height = value; }
		}

		// Gets or sets width
		public double Width
		{
		  get { return _width; }
		  set { _width = value; }
		}
	}
	
	public class Circle{  
   		private double _radius;
		
		public Circle(double radius)
		{
			this._radius = radius;
		}
		
		// Gets or sets radius
		public double Radius
		{
		  get { return _radius; }
		  set { _radius = value; }
		}
	}

	public class AreaCalculator  
	{  
   		public double TotalArea(List<object> arrObjects)  
   		{  
			Rectangle objRectangle;  
			Circle objCircle;
			double area = 0;
			
			foreach(var obj in arrObjects)  
			{  
				if(obj is Rectangle)  
				{
					objRectangle = (Rectangle)obj; 
					area += objRectangle.Height * objRectangle.Width;  
				}  
				else  
				{  
					objCircle = (Circle)obj;  
					area += objCircle.Radius * objCircle.Radius * Math.PI;  
				}  
      		}  
      		return area;  
   		}  
	} 
	
	public class Program
	{
		public static void Main(string[] args)
		{
			List<object> list = new List<object>();
			
			var rect1 = new Rectangle(2.50, 4.30);
			var rect2 = new Rectangle(3.10, 1.85);
			var circle = new Circle(5.68);
			
			list.Add(rect1);
			list.Add(rect2);
			list.Add(circle);
			
			var areaCalculator = new AreaCalculator();
			var result = areaCalculator.TotalArea(list);
			Console.WriteLine(result);
		}
	}
}

//========================================================================//

//O: Code After Open/Closed Principle

using System;
using System.Collections.Generic;

public interface IShape  
{  
   double Area();  
}

public class Rectangle: IShape  
{  
   public double Height {get;set;}  
   public double Width {get;set;}  
   
   public double Area()  
   {  
      return Height * Width;  
   }  
}
public class Circle: IShape  
{  
   public double Radius {get;set;}  
   
   public double Area()  
   {  
      return Radius * Radius * Math.PI;  
   }  
} 

public class AreaCalculator  
{  
   public double TotalArea(List<IShape> listShapes)  
   {  
      double area=0;  
      foreach(var objShape in listShapes)  
      {  
         area += objShape.Area();  
      }  
      return area;  
   }  
} 
					
public class Program
{
	public static void Main()
	{
		List<IShape> shapes = new List<IShape>();
		
		var rectangle = new Rectangle() { Height = 50.00, Width = 30.50 };
		shapes.Add(rectangle);
		
		var circle = new Circle() { Radius = 18.95 };
		shapes.Add(circle);
		
		var calculator = new AreaCalculator();
		var total = calculator.TotalArea(shapes);
		Console.WriteLine(total);
	}
}

//========================================================================//

//Example2
//Code before Open Closed Principle
using System;

namespace OCP
{
	public class Employee
    {
		private int _id;
        private string _name;
		private string _employeeType;
		
        public Employee(int id, string name, string employeeType)
        {
            this._id = id;
            this._name = name;
            this._employeeType = employeeType;
        }
		
		// Gets or sets id
		public int Id
		{
		  get { return _id; }
		  set { _id = value; }
		}
		
		// Gets or sets name
		public string Name
		{
		  get { return _name; }
		  set { _name = value; }
		}
		
		// Gets or sets employeeType
		public string EmployeeType
		{
		  get { return _employeeType; }
		  set { _employeeType = value; }
		}
		
        public decimal CalculateBonus(decimal salary)
        {
            if (this._employeeType == "Permanent")
                return salary * .1M;
            else
                return salary * .05M;
        }
    }

	public class Program
	{
		public static void Main()
		{
			Employee empJohn = new Employee(1, "John", "Permanent");
			Employee empJason = new Employee(2, "Jason", "Temp");

			Console.WriteLine("Employee {0} Bonus: {1}", empJohn.Name, empJohn.CalculateBonus(100000));
			Console.WriteLine("Employee {0} Bonus: {1}", empJason.Name, empJason.CalculateBonus(100000));
			Console.ReadLine();
		}
	}
}

//=========================================================================//
//Code after Open Closed Principle

using System;

namespace OCP
{
	public abstract class Employee
    {
        private int _id;
        private string _name;
       	
        public Employee(int id, string name)
        {
        	this._id = id;
            this._name = name;
        }
		
		// Gets or sets id
		public int Id
		{
		  get { return _id; }
		  set { _id = value; }
		}
		
		// Gets or sets name
		public string Name
		{
		  get { return _name; }
		  set { _name = value; }
		}
		
        public override string ToString()
        {
            return string.Format("ID : {0} Name : {1}", this._id, this._name);
        }
		
		public abstract decimal CalculateBonus(decimal salary);
    }

    public class PermanentEmployee : Employee
    {
        public PermanentEmployee(int id, string name) 
			: base(id, name)
        { 
		}
		
        public override decimal CalculateBonus(decimal salary)
        {
            return salary * .1M;
        }
    }

    public class TemporaryEmployee : Employee
    {
        public TemporaryEmployee(int id, string name) 
			: base(id, name)
        { 
		}
        public override decimal CalculateBonus(decimal salary)
        {
            return salary * .05M;
        }
    }

	public class Program
	{
		public static void Main()
		{
			Employee empJohn = new PermanentEmployee(1, "John");
            Employee empJason = new TemporaryEmployee(2, "Jason");
           
            Console.WriteLine("Employee {0} Bonus: {1}", empJohn.ToString(), empJohn.CalculateBonus(100000));
            Console.WriteLine("Employee {0} Bonus: {1}", empJason.ToString(), empJason.CalculateBonus(150000));
            Console.ReadLine();
		}
	}
}
