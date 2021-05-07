using System;

namespace FacadeDP
{
	/// <summary>
	/// Patron of the restaurant 
	/// </summary>
	class Patron
	{
		private string _name;

		public Patron(string name)
		{
			this._name = name;
		}

		public string Name
		{
			get { return _name; }
		}
	}
	
	/// <summary>
	/// All items sold in the restaurant must inherit from this.
	/// </summary>
	class FoodItem 
	{ 
		public int DishID; 
	}

	/// <summary>
	/// Each section of the kitchen must implement this interface.
	/// </summary>
	interface IKitchenSection
	{
		FoodItem PrepDish(int DishID);
	}

	/// <summary>
	/// Orders placed by Patrons.
	/// </summary>
	class Order
	{
		public FoodItem Appetizer { get; set; }
		public FoodItem Entree { get; set; }
		public FoodItem Drink { get; set; }
	}
	
	//=============================================================//
	
	/// <summary>
	/// A division of the kitchen.
	/// </summary>
	class ColdPrep : IKitchenSection
	{
		public FoodItem PrepDish(int dishID)
		{
			//Go prep the cold item
			return new FoodItem()
			{
				DishID = dishID
			};
		}
	}

	/// <summary>
	/// A division of the kitchen.
	/// </summary>
	class HotPrep : IKitchenSection
	{
		public FoodItem PrepDish(int dishID)
		{
			//Go prep the hot entree
			return new FoodItem()
			{
				DishID = dishID
			};
		}
	}

	/// <summary>
	/// A division of the kitchen.
	/// </summary>
	class Bar : IKitchenSection
	{
		public FoodItem PrepDish(int dishID)
		{
			//Go mix the drink
			return new FoodItem()
			{
				DishID = dishID
			};
		}
	}
	
	//======================================================//
	
	/// <summary>
	/// The actual "Facade" class, which hides the 
	/// complexity of the KitchenSection classes.
	/// After all, there's no reason a patron 
	/// should order each part of their meal individually.
	/// </summary>
	class Server
	{
		private ColdPrep _coldPrep = new ColdPrep();
		private Bar _bar = new Bar();
		private HotPrep _hotPrep = new HotPrep();

		public Order PlaceOrder(Patron patron, int coldAppID, int hotEntreeID, int drinkID)
		{
			Console.WriteLine("{0} places order for cold app #" 
							  + coldAppID.ToString()
							  + ", hot entree #" + hotEntreeID.ToString()
							  + ", and drink #" + drinkID.ToString() + ".", patron.Name);

			Order order = new Order();
			order.Appetizer = _coldPrep.PrepDish(coldAppID);
			order.Entree = _hotPrep.PrepDish(hotEntreeID);
			order.Drink = _bar.PrepDish(drinkID);

			return order;
		}
	}
	
	
	public class Program
	{
		public static void Main()
		{
			Server server = new Server();

			Console.WriteLine("Hello!  I'll be your server today. What is your name?");
			var name = Console.ReadLine();

			Patron patron = new Patron(name);

			Console.WriteLine("Hello " + patron.Name 
							  + ". What appetizer would you like? (1-15):");
			var appID = int.Parse(Console.ReadLine());

			Console.WriteLine("That's a good one.  What entree would you like? (1-20):");
			var entreeID = int.Parse(Console.ReadLine());

			Console.WriteLine("A great choice!  Finally, what drink would you like? (1-60):");
			var drinkID = int.Parse(Console.ReadLine());

			Console.WriteLine("I'll get that order in right away.");

			//Here's what the Facade simplifies
			server.PlaceOrder(patron, appID, entreeID, drinkID);  

			Console.ReadLine();
		}	
	}
}
