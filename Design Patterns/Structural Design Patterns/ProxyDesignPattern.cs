using System;

namespace ProxyDP
{
	/// <summary>
	/// The Subject interface which both the RealSubject and proxy will need to implement
	/// </summary>
	public interface IServer
	{
		void TakeOrder(string order);
		string DeliverOrder();
		void ProcessPayment(string payment);
	}
	
	/// <summary>
	/// The RealSubject class which the Proxy can stand in for
	/// </summary>
	class Server : IServer
	{
		private string Order;
		public void TakeOrder(string order)
		{
			Console.WriteLine("Server takes order for " + order + ".");
			Order = order;
		}

		public string DeliverOrder()
		{
			return Order;
		}

		public void ProcessPayment(string payment)
		{
			Console.WriteLine("Payment for order (" + payment + ") processed by server.");
		}
	}
	
	/// <summary>
	/// The Proxy class, which can substitute for the Real Subject.
	/// </summary>
	class NewServerProxy : IServer
	{
		private string Order;
		private Server _server = new Server();

		public void TakeOrder(string order)
		{
			Console.WriteLine("New trainee server takes order for " + order + ".");
			Order = order;
		}

		public string DeliverOrder()
		{
			return Order;
		}

		public void ProcessPayment(string payment)
		{
			Console.WriteLine("New trainee cannot process payments yet!");
			_server.ProcessPayment(payment);
		}
	}
	
	/// <summary>
	/// Client
	/// <summary>
	public class Serving
	{
		private readonly IServer _iserver;

        public Serving(IServer iserver)
        {
            this._iserver = iserver;
        }
		
		public void Proccess(string order, string payment)
		{
			this._iserver.TakeOrder(order);
			var order_ = this._iserver.DeliverOrder();
			this._iserver.ProcessPayment(payment);
		}
	}
	
	public class Program
	{
		public static void Main(string[] args)
		{
			var server = new Server();
			var serving1 = new Serving(server);
			serving1.Proccess("Order1", "20 dollars");

			Console.WriteLine("*****************************");

			var newServerProxy = new NewServerProxy();
			var serving2 = new Serving(newServerProxy);
			serving2.Proccess("Order2", "80 dollars");
		}
	}
}
