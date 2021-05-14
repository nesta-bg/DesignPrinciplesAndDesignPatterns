namespace ObserverDPDemo 
{
	/// The 'Subject' abstract class
	abstract class Stock
	{
    	private string _symbol;
    	private double _price;
    	private List<IInvestor> _investors = new List<IInvestor>();
 
		// Constructor
		public Stock(string symbol, double price)
		{
		  this._symbol = symbol;
		  this._price = price;
		}

		public void Attach(IInvestor investor)
		{
		  _investors.Add(investor);
		}

		public void Detach(IInvestor investor)
		{
		  _investors.Remove(investor);
		}

		public void Notify()
		{
		  foreach (IInvestor investor in _investors)
		  {
			investor.Update(this);
		  }

		  Console.WriteLine("");
		}

		// Gets or sets the price
		public double Price
		{
		  get { return _price; }
		  set
		  {
			if (_price != value)
			{
			  _price = value;
			  Notify();
			}
		  }
    	}
 
		// Gets the symbol
		public string Symbol
		{
		  get { return _symbol; }
		}
	}
	
	/// The 'ConcreteSubject' class
	class IBM : Stock
  	{
    	// Constructor
    	public IBM(string symbol, double price)
      		: base(symbol, price)
    	{	
    	}
  	}
	
	//=========================================================================//
	
	/// The 'Observer' interface
	interface IInvestor
  	{
    	void Update(Stock stock);
  	}
 
	/// The 'ConcreteObserver' class
	class Investor : IInvestor
  	{
    	private string _name;
    	private Stock _stock;
 
    	// Constructor
    	public Investor(string name)
    	{
      		this._name = name;
    	}
 
    	public void Update(Stock stock)
    	{
      		Console.WriteLine("Notified {0} of {1}'s " + "change to {2:C}", _name, stock.Symbol, stock.Price);
    	}
 
    	// Gets or sets the stock
    	public Stock Stock
    	{
      		get { return _stock; }
      		set { _stock = value; }
    	}
  	}
 
	//=========================================================================//
 
	public class Program
	{
		public static void Main(string[] args)
		{
			// Create IBM stock(ConcreteSubject) and attach investors
      		IBM ibm = new IBM("IBM", 120.00);
      		ibm.Attach(new Investor("SLP"));
      		ibm.Attach(new Investor("OOT"));
 
			// Fluctuating prices will notify investors
			ibm.Price = 198.10;
			ibm.Price = 380.00;
			ibm.Price = 120.50;
			ibm.Price = 155.75;

			Console.ReadLine();
		}
	}
}
