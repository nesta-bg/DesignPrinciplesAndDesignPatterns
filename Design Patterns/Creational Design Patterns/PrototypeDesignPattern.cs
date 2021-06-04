//===================================FIRST EXAMPLE (Shallow copy)==================================//

using System;
using System.Collections.Generic;

namespace PrototypeDP
{
	/// <summary>
	/// The Prototype abstract class
	/// </summary>
	abstract class SandwichPrototype
	{
		public abstract SandwichPrototype Clone();
	}
	
  	/// <summary>
  	/// The ConcretePrototype class
  	/// <summary>
	class Sandwich : SandwichPrototype
	{
		private string Bread;
		private string Meat;
		private string Cheese;
		private string Veggies;

		public Sandwich(string bread, string meat, string cheese, string veggies)
		{
			Bread = bread;
			Meat = meat;
			Cheese = cheese;
			Veggies = veggies;
		}

		public override SandwichPrototype Clone()
		{
			return MemberwiseClone() as SandwichPrototype;
		}
	}

	class SandwichMenu
	{
		private Dictionary<string, SandwichPrototype> _sandwiches 
			= new Dictionary<string, SandwichPrototype>();

		public SandwichPrototype this[string name]
		{
			get { return _sandwiches[name]; }
			set { _sandwiches.Add(name, value); }
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			 SandwichMenu sandwichMenu = new SandwichMenu();

			// Initialize with default sandwiches
			sandwichMenu["BLT"] 
				= new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
			sandwichMenu["PB&J"] 
				= new Sandwich("White", "", "", "Peanut Butter, Jelly");
			sandwichMenu["Turkey"] 
				= new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

			// Deli manager adds custom sandwiches
			sandwichMenu["LoadedBLT"] 
				= new Sandwich("Wheat", "Turkey, Bacon", "American", "Lettuce, Tomato, Onion, Olives");
			sandwichMenu["ThreeMeatCombo"] 
				= new Sandwich("Rye", "Turkey, Ham, Salami", "Provolone", "Lettuce, Onion");
			sandwichMenu["Vegetarian"] 
				= new Sandwich("Wheat", "", "", "Lettuce, Onion, Tomato, Olives, Spinach");

			// Now we can clone these sandwiches
			Sandwich sandwich1 = sandwichMenu["BLT"].Clone() as Sandwich;
			Sandwich sandwich2 
				= sandwichMenu["ThreeMeatCombo"].Clone() as Sandwich;
			Sandwich sandwich3 
				= sandwichMenu["Vegetarian"].Clone() as Sandwich;

			// Wait for user
			Console.ReadLine();
		}
	}
}

//===================================SECOND EXAMPLE (Shallow and Deep copy)==================================//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
	/// <summary>
	/// The Prototype abstract class
	/// <summary>
	public abstract class CloneablePrototype<T>
	{
		// Shallow copy
		public T Clone()
		{
			return (T)this.MemberwiseClone();
		}

		// Deep Copy
		public T DeepCopy()
		{
			string result = JsonConvert.SerializeObject(this);
			return JsonConvert.DeserializeObject<T>(result);
		}
	}

	/// <summary>
	/// The ConcretePrototype class
	/// </summary>
	public class Employee : CloneablePrototype<Employee>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

		public int DepartmentID { get; set; }

		public Address AddressDetails { get; set; }
		public override string ToString()
		{
			return string.Format(" Name : {0}, DepartmentID : {1} , " +
				"Address : {2}",
				this.Name, this.DepartmentID.ToString(),
				this.AddressDetails.ToString());
		}
	}

	public class Address
	{
		public Address() { }

		public int DoorNumber { get; set; }
		public int StreetNumber { get; set; }
		public int Zipcode { get; set; }
		public string Country { get; set; }

		public override string ToString()
		{
			return string.Format("AddressDetails : Door : {0}, Street: {1}, ZipCode : {2}," +
				" Country : {3}", this.DoorNumber, this.StreetNumber, this.Zipcode.ToString(),
				this.Country);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Employee empJohn = new Employee()
			{
				Id = Guid.NewGuid(),
				Name = "John",
				DepartmentID = 150,
				AddressDetails = new Address()
				{
					DoorNumber = 10,
					StreetNumber = 20,
					Zipcode = 90025,
					Country = "US"
				}
			};

			Console.WriteLine(empJohn.ToString());

			Employee empSam = (Employee)empJohn.DeepCopy();
			//Employee empSam = (Employee)empJohn.Clone();

			empSam.Name = "Sam Paul";
			empSam.DepartmentID = 151;
			empSam.AddressDetails.DoorNumber = 11;
			empSam.AddressDetails.StreetNumber = 21;
			
			Console.WriteLine(empSam.ToString());

			Console.WriteLine("Modified Details of John");
			empJohn.DepartmentID = 160;
			empJohn.AddressDetails.DoorNumber = 30;
			empJohn.AddressDetails.StreetNumber = 40;

			
			Console.WriteLine(empJohn.ToString());
			Console.WriteLine(empSam.ToString());
			Console.ReadLine();
		}
	}
}


