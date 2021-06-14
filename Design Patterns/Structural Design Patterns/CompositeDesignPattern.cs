using System;
using System.Collections.Generic;

namespace CompositeDP
{
	//Component
    	public abstract class EmployeeComp
    	{
    		public string Name;
		public string Department;
		
		public EmployeeComp(string name, string dept)
		{
			this.Name = name;
			this.Department = dept;
		}
		
		public abstract void GetDetails(int indentation);
    	}
	
	//Leaf
    	public class Employee : EmployeeComp
    	{
        	public Employee(string name, string dept)
			:base(name, dept)
        	{
			
        	}
		
        	public override void GetDetails(int indentation)
        	{
            		Console.WriteLine(string.Format("{0} Name:{1}, Dept:{2} (Leaf) ",
                		new String('-', indentation), this.Name, this.Department));
        	}
    	}
	
    	//Composite
    	public class Manager : EmployeeComp
    	{
        	public List<EmployeeComp> SubOrdinates = new List<EmployeeComp>();
		
        	public Manager(string name, string dept)
			:base(name, dept)
        	{
			
        	}
       
        	public override void GetDetails(int indentation)
        	{
            		Console.WriteLine();
            		Console.WriteLine(string.Format("{0}+ Name:{1}, " + "Dept:{2} - Manager(Composite)",
                		new String('*', indentation), this.Name, this.Department));
            		foreach (EmployeeComp component in SubOrdinates)
            		{
                		component.GetDetails(indentation + 3);
            		}
        	}
    	}

	public class Program
	{
		public static void Main()
		{
			EmployeeComp John = new Employee("John", "IT");
            		EmployeeComp Mike = new Employee("Mike", "IT");
            		EmployeeComp Jason = new Employee("Jason", "HR");
            		EmployeeComp Eric = new Employee("Eric", "HR");
            		EmployeeComp Henry = new Employee("Henry", "HR");

            		EmployeeComp James = new Manager("James", "IT") { SubOrdinates = { John, Mike } };
            		EmployeeComp Philip = new Manager("Philip", "HR") { SubOrdinates = { Jason, Eric, Henry } };
			
            		EmployeeComp Bob = new Manager("Bob", "Head") { SubOrdinates = { James, Philip } };
			
			James.GetDetails(1);
			Console.WriteLine("********************");
			Philip.GetDetails(1);
			Console.WriteLine("********************");
            		Bob.GetDetails(1);
			Console.WriteLine("********************");
            		Console.ReadLine();
		}	
	}
}
