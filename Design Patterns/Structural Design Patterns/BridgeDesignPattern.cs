using System;

namespace BridgeDP
{
	/// <summary>
	/// Implementor which defines an interface for placing an order
	/// </summary>
	public interface IOrderingSystem
	{
		void Place(string order);
	}
	
	/// <summary>
	/// ConcreteImplementor for an ordering system at a diner.
	/// </summary>
	public class DinerOrders : IOrderingSystem
	{
		public void Place(string order)
		{
			Console.WriteLine("Placing order for " + order + " at the Diner.");
		}
	}

	/// <summary>
	/// ConcreteImplementor for an ordering system at a fancy restaurant.
	/// </summary>
	public class FancyRestaurantOrders : IOrderingSystem
	{
		public void Place(string order)
		{
			Console.WriteLine("Placing order for " + order + " at the Fancy Restaurant.");
		}
	}
	
	//==============================================================//
	
	/// <summary>
	/// Abstraction which represents the sent order 
	/// and maintains a reference to the restaurant where the order is going.
	/// </summary>
	public abstract class SendOrder
	{
		//Reference to the Implementor
		public IOrderingSystem _restaurant;

		public abstract void Send();
	}
	
	/// <summary>
	/// RefinedAbstraction for a dairy-free order
	/// </summary>
	public class SendDairyFreeOrder : SendOrder
	{
		public override void Send()
		{
			_restaurant.Place("Dairy-Free Order");
		}
	}

	/// <summary>
	/// RefinedAbstraction for a gluten free order
	/// </summary>
	public class SendGlutenFreeOrder : SendOrder
	{
		public override void Send()
		{
			_restaurant.Place("Gluten-Free Order");
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			//Abstraction
			SendOrder _sendOrder = new SendDairyFreeOrder();
			//Implementor
			_sendOrder._restaurant = new DinerOrders();
			_sendOrder.Send();

			_sendOrder._restaurant = new FancyRestaurantOrders();
			_sendOrder.Send();

			//Abstraction
			_sendOrder = new SendGlutenFreeOrder();
			//Implementor
			_sendOrder._restaurant = new DinerOrders();
			_sendOrder.Send();

			_sendOrder._restaurant = new FancyRestaurantOrders();
			_sendOrder.Send();

			Console.ReadLine();
		}	
	}
}
