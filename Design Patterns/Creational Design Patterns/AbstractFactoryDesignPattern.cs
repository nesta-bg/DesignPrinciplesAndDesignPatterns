using System;

namespace AbstractFactoryDP
{
	/// <summary>
	/// The AbstractFactory class, which defines methods for creating abstract objects.
	/// </summary>
	abstract class MenuFactory
	{
		public abstract Appetizer CreateAppetizer();
		public abstract MainDish CreateMainDish();
		public abstract Dessert CreateDessert();
	}
	
	//==============================//
	
	/// <summary>
	/// A ConcreteFactory which creates concrete objects by implementing the abstract factory's methods.
	/// </summary>
	class AdultCuisineFactory : MenuFactory
	{
		public override Appetizer CreateAppetizer()
		{
			return new ChickenSoup();
		}
		
		public override MainDish CreateMainDish()
		{
			return new Steak();
		}

		public override Dessert CreateDessert()
		{
			return new CremeBrulee();
		}
	}
	
	/// <summary>
	/// A concrete factory which creates concrete objects by implementing the abstract factory's methods.
	/// </summary>
	class KidCuisineFactory : MenuFactory
	{
		public override Appetizer CreateAppetizer()
		{
			return new VeggieSoup();
		}
		
		public override MainDish CreateMainDish()
		{
			return new GrilledCheese();
		}

		public override Dessert CreateDessert()
		{
			return new IceCreamSundae();
		}
	}
	
	//==========================================================================================//
	
	/// <summary>
	/// An abstract product.
	/// </summary>
	abstract class Appetizer { }
	
	/// <summary>
	/// An abstract product.
	/// </summary>
	abstract class MainDish { }

	/// <summary>
	/// An abstract product.
	/// </summary>
	abstract class Dessert { }
	
	//===================================//
	
	/// <summary>
	/// A ConcreteProduct
	/// </summary>
	class ChickenSoup : Appetizer { }
	
	/// <summary>
	/// A ConcreteProduct
	/// </summary>
	class Steak : MainDish { }

	/// <summary>
	/// A ConcreteProduct
	/// </summary>
	class CremeBrulee : Dessert { }
	
	/// <summary>
	/// A ConcreteProduct
	/// </summary>
	class VeggieSoup : Appetizer { }
	
	/// <summary>
	/// A concrete object
	/// </summary>
	class GrilledCheese : MainDish { }

	/// <summary>
	/// A concrete object
	/// </summary>
	class IceCreamSundae : Dessert { }
	
//==============================================================================//
	
	public class Program
	{
		public static void Main()
		{
			Console.WriteLine("Who are you? (A)dult or (C)hild?");
			
			char input = Convert.ToChar(Console.ReadLine());
			MenuFactory factory;
			switch(input)
			{
				case 'A':
					factory = new AdultCuisineFactory();
					break;

				case 'C':
					factory = new KidCuisineFactory();
					break;

				default:
					throw new NotImplementedException();

			}

			var appetizer = factory.CreateAppetizer();
			var mainDish = factory.CreateMainDish();
			var dessert = factory.CreateDessert();

			Console.WriteLine("Appetizer: " + appetizer.GetType().Name);
			Console.WriteLine("MainDish: " + mainDish.GetType().Name);
			Console.WriteLine("Dessert: " + dessert.GetType().Name);

			Console.ReadLine();
		}
	}
}
