using System;

namespace ChainOfResponsibilityDP
{
	//=================HANDLER=====================
	abstract class Approver
  	{
    		protected Approver successor;
 
		public void SetSuccessor(Approver successor)
		{
			this.successor = successor;
		}

		public abstract void ProcessRequest(Purchase purchase);
  	}
	
	//=========CONCRETE HANDLER=========================
	class Director : Approver
	{
		public override void ProcessRequest(Purchase purchase)
		{
			if (purchase.Amount < 10000.0)
		  	{
				Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
		  	}
		  	else if (successor != null)
		  	{
				successor.ProcessRequest(purchase);
		  	}
		}
	}
	
	//=========CONCRETE HANDLER=========================
	class VicePresident : Approver
  	{
    	public override void ProcessRequest(Purchase purchase)
    	{
      		if (purchase.Amount < 25000.0)
      		{
        		Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
		}
      		else if (successor != null)
      		{
        		successor.ProcessRequest(purchase);
      		}
    	}
	}

	//=========CONCRETE HANDLER=========================
	class President : Approver
	{
    		public override void ProcessRequest(Purchase purchase)
    		{
      			if (purchase.Amount < 100000.0)
      			{
        			Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
      			}
      			else
      			{
        			Console.WriteLine("Request# {0} requires an executive meeting!",purchase.Number);
   			}
    		}
	}
	
	//=========================CLASS HOLDING REQUEST DETAILS=====================================
	class Purchase
	{
    		private int _number;
    		private double _amount;
    		private string _purpose;
 
		public Purchase(int number, double amount, string purpose)
		{
			this._number = number;
		  	this._amount = amount;
		  	this._purpose = purpose;
		}

		public int Number
		{
			get { return _number; }
		  	set { _number = value; }
		}

		public double Amount
		{
			get { return _amount; }
		  	set { _amount = value; }
		}

		public string Purpose
		{
			get { return _purpose; }
		  	set { _purpose = value; }
		}
	}
	
	public class Program
	{
		public static void Main(string[] args)
		{
			// Setup Chain of Responsibility
			Approver larry = new Director();
			Approver sam = new VicePresident();
			Approver tammy = new President();

			larry.SetSuccessor(sam);
			sam.SetSuccessor(tammy);

			// Generate and process purchase requests
			Purchase p = new Purchase(2034, 350.00, "Assets");
			larry.ProcessRequest(p);

			p = new Purchase(2035, 32590.10, "Project X");
			larry.ProcessRequest(p);

			p = new Purchase(2036, 122100.00, "Project Y");
			larry.ProcessRequest(p);

			Console.ReadLine();	
		}
	}
}
