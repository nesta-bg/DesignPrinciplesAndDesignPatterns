using System;
					
namespace StrategyDP
{
	/// <summary>
	/// The Strategy abstract class, which defines an 
	/// interface common to all supported strategy algorithms.
	/// </summary>
	abstract class CookStrategy
	{
		public abstract void Cook(string food);
	}

	//===========================================================================================//

	/// <summary>
	/// A Concrete Strategy class
	/// </summary>
	class Grilling : CookStrategy
	{
		public override void Cook(string food)
		{
			Console.WriteLine("\nCooking " + food + " by grilling it.");
		}
	}

	/// <summary>
	/// A Concrete Strategy class
	/// </summary>
	class OvenBaking : CookStrategy
	{
		public override void Cook(string food)
		{
			Console.WriteLine("\nCooking " + food + " by oven baking it.");
		}
	}

	/// <summary>
	/// A Concrete Strategy class
	/// </summary>
	class DeepFrying : CookStrategy
	{
		public override void Cook(string food)
		{
			Console.WriteLine("\nCooking " + food + " by deep frying it");
		}
	}

	//===========================================================================================//

	/// <summary>
	/// The Context class, which maintains a reference to the chosen Strategy.
	/// </summary>
	class CookingMethod
	{
		private string _food;
		private CookStrategy _cookStrategy;

		public void SetCookStrategy(CookStrategy cookStrategy)
		{
			this._cookStrategy = cookStrategy;
		}

		public void SetFood(string name)
		{
			_food = name;
		}

		public void Cook()
		{
			_cookStrategy.Cook(_food);
			Console.WriteLine();
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			/// The Context class,
			CookingMethod cookMethod = new CookingMethod();

			Console.WriteLine("What food would you like to cook?");
			var food = Console.ReadLine();
			cookMethod.SetFood(food);

			Console.WriteLine("What cooking strategy would you like to use (1-3)?");
			int input = int.Parse(Console.ReadLine());

			switch(input)
			{
				case 1:
					cookMethod.SetCookStrategy(new Grilling());
					cookMethod.Cook();
					break;

				case 2:
					cookMethod.SetCookStrategy(new OvenBaking());
					cookMethod.Cook();
					break;

				case 3:
					cookMethod.SetCookStrategy(new DeepFrying());
					cookMethod.Cook();
					break;

				default:
					Console.WriteLine("Invalid Selection!");
					break;
			}
			Console.ReadLine();
		}
	}
}
