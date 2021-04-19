//code before LSP
using System;

namespace LSP
{
	public class Employee
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Employee Manager { get; set; }
		public decimal Salary { get; set; }
		
		public Employee()
		{
			Manager = null;
		}
		
		public virtual void AssignManager(Employee manager)
		{
			//doing other tasks here to be a method, not property set statement
			
			Manager = manager;
		}
		
		public virtual void CalculatePerHourRate(int rank)
		{
			decimal baseAmount = 12.50M;
			Salary = baseAmount + (rank * 2);
		}
	}
	
	public class Manager : Employee
	{
		//covariance (if we have a return type it can't change)
		//public override decimal CalculatePerHourRate(int rank)
		
		//contravariance is about input type
		//public override void CalculatePerHourRate(double rank)
		
		public override void CalculatePerHourRate(int rank)
		{
			//preconditions and postconditions (you can't do it)
			//if(rank < 0 || rank > 5)
			//{
				//throw new Exception();
			//}
			
			decimal baseAmount = 19.75M;
			Salary = baseAmount + (rank * 4);
			
			//postconditions if method returns a value (you can't do it)
			//if(salary < 0 || salary > 400.00M)
			//{
				//throw new Exception();
			//}
		}
		
		public void GeneratePerformanceReview()
		{
			//simulate reviewing a direct report
			Console.WriteLine("I'm reviewing a direct report's performance.");
		}
	}
	
	public class CEO : Employee
	{
		public override void CalculatePerHourRate(int rank)
		{
			decimal baseAmount = 150M;
			Salary = baseAmount * rank;
		}
		
		public override void AssignManager(Employee manager)
		{
			throw new InvalidOperationException("The CEO has no manager");
		}
		
		public void GeneratePerformanceReview()
		{
			//simulate reviewing a direct report
			Console.WriteLine("I'm reviewing a direct report's performance.");
		}
		
		public void FireSomeone()
		{
			//simulate fireing someone
			Console.WriteLine("Tou're Fired!");
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			Manager accountingVP = new Manager();
			accountingVP.FirstName = "Emma";
			accountingVP.LastName = "Stone";
			accountingVP.CalculatePerHourRate(4);
			
			//1.
			Employee emp = new Employee();
			
			//==================LSV TEST==========================
			//2.
			//Employee emp = new Manager();
			
			//3.
			//Employee emp = new CEO();
			
			emp.FirstName = "Tim";
			emp.LastName = "Corey";
			emp.AssignManager(accountingVP);
			emp.CalculatePerHourRate(2);
			Console.WriteLine("{0}'s salary is {1}/hour.", emp.FirstName, emp.Salary);		//1.Tim's salary is 16.50/hour.
																							                                      //2.Tim's salary is 27.75/hour.
																							                                      //3.System.InvalidOperationException: The CEO has no manager
			Console.ReadLine();
		}
	}
}

//code after LSP
using System;

namespace LSP
{
	public interface IEmployee
	{
		string FirstName { get; set; }
		string LastName { get; set; }
		decimal Salary { get; set; }
		
		void CalculatePerHourRate(int rank);
	}
	
	public interface IManager : IEmployee
	{
		void GeneratePerformanceReview();
	}
	
	public interface IManaged : IEmployee
	{
		IEmployee Manager { get; set; }
		
		void AssignManager(IEmployee manager);
	}
	
	public abstract class BaseEmployee : IEmployee
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public decimal Salary { get; set; }
		
		public virtual void CalculatePerHourRate(int rank)
		{
			decimal baseAmount = 12.50M;
			Salary = baseAmount + (rank * 2);
		}
	}
	
	public class Employee : BaseEmployee, IManaged
	{
		public IEmployee Manager { get; set; }
		
		public Employee()
		{
			Manager = null;
		}
		
		public void AssignManager(IEmployee manager)
		{
			//doing other tasks here to be a method, not property set statement
			
			Manager = manager;
		}
	}
		
	public class Manager : Employee,IManager
	{
		public override void CalculatePerHourRate(int rank)
		{
			decimal baseAmount = 19.75M;
			Salary = baseAmount + (rank * 4);
		}
		
		public void GeneratePerformanceReview()
		{
			//simulate reviewing a direct report
			Console.WriteLine("I'm reviewing a direct report's performance.");
		}
	}
	
	public class CEO : BaseEmployee,IManager
	{
		public override void CalculatePerHourRate(int rank)
		{
			decimal baseAmount = 150M;
			Salary = baseAmount * rank;
		}
		
		public void GeneratePerformanceReview()
		{
			//simulate reviewing a direct report
			Console.WriteLine("I'm reviewing a direct report's performance.");
		}
		
		public void FireSomeone()
		{
			//simulate fireing someone
			Console.WriteLine("Tou're Fired!");
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			//==================LSV TEST==========================
			
			//WORKS
			//IManaged accountingVP = new Manager();
			
			//WORKS
			//Employee accountingVP = new Manager();
			
			//WORKS
			//IManager accountingVP = new Manager();
			
			//WORKS
			IManager accountingVP = new CEO();
			
			accountingVP.FirstName = "Emma";
			accountingVP.LastName = "Stone";
			accountingVP.CalculatePerHourRate(4);
			
			
		
			//you can't do that 
			//BaseEmployee emp = new BaseEmployee();
			
			//WORKS
			//emp.AssignManager(accountingVP);
			//BaseEmployee emp = new Employee();
			
			//WORKS
			//emp.AssignManager(accountingVP);
			//BaseEmployee emp = new Manager();
			
			//WORKS
			//emp.AssignManager(accountingVP);
			//BaseEmployee emp = new CEO();
			
			//WORKS
			//IManaged emp = new Employee();
			
			//WORKS
			IManaged emp = new Manager();
			
			emp.FirstName = "Tim";
			emp.LastName = "Corey";
			emp.AssignManager(accountingVP);
			emp.CalculatePerHourRate(2);
			Console.WriteLine("{0}'s salary is {1}/hour.", emp.FirstName, emp.Salary);
			
			Console.ReadLine();
		}
	}
}
