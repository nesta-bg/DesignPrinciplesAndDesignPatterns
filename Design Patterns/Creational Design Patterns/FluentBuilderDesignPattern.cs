using System;
using System.Collections.Generic;

namespace FluentBuliderDP
{
	/// The 'Director' class
	class Shop
	{
		// Builder uses a complex series of steps
		public void Construct(VehicleBuilder vehicleBuilder)
		{
			//4.
		  	vehicleBuilder.BuildFrame()
		  		.BuildEngine()
		  		.BuildWheels()
		  		.BuildDoors();
		}
	}
	
	//========================================================//
 
	/// The 'Builder' abstract class
	abstract class VehicleBuilder
	{
		protected Vehicle vehicle;

		// Gets vehicle instance
		public Vehicle Vehicle
		{
			get { return vehicle; }
		}

		// Abstract build methods
		//1.
		//public abstract void BuildFrame();
		public abstract VehicleBuilder BuildFrame();
		public abstract VehicleBuilder BuildEngine();
		public abstract VehicleBuilder BuildWheels();
		public abstract VehicleBuilder BuildDoors();
	}
	
	//========================================================//
 
	/// The 'ConcreteBuilder1' class
	class MotorCycleBuilder : VehicleBuilder
	{
		public MotorCycleBuilder()
		{
			vehicle = new Vehicle("MotorCycle");
		}

		//2.
		//public override void BuildFrame()
		public override VehicleBuilder BuildFrame()
		{
			vehicle["frame"] = "MotorCycle Frame";
		  	//3.
		  	return this;
		}

		public override VehicleBuilder BuildEngine()
		{
			vehicle["engine"] = "500 cc";
		  	return this;
		}

		public override VehicleBuilder BuildWheels()
		{
			vehicle["wheels"] = "2";
		  	return this;
		}

		public override VehicleBuilder BuildDoors()
		{
			vehicle["doors"] = "0";
		  	return this;
		}
	}
 
	 /// The 'ConcreteBuilder2' class
	class CarBuilder : VehicleBuilder
	{
		public CarBuilder()
		{
			vehicle = new Vehicle("Car");
		}

		public override VehicleBuilder BuildFrame()
		{
		  	vehicle["frame"] = "Car Frame";
		  	return this;
		}

		public override VehicleBuilder BuildEngine()
		{
			vehicle["engine"] = "2500 cc";
		  	return this;
		}

		public override VehicleBuilder BuildWheels()
		{
			vehicle["wheels"] = "4";
		  	return this;
		}

		public override VehicleBuilder BuildDoors()
		{
			vehicle["doors"] = "4";
		  	return this;
		}
	}
 
	/// The 'ConcreteBuilder3' class
	class ScooterBuilder : VehicleBuilder
	{
		public ScooterBuilder()
		{
			vehicle = new Vehicle("Scooter");
		}

		public override VehicleBuilder BuildFrame()
		{
		  	vehicle["frame"] = "Scooter Frame";
		  	return this;
		}

		public override VehicleBuilder BuildEngine()
		{
			vehicle["engine"] = "50 cc";
		  	return this;
		}

		public override VehicleBuilder BuildWheels()
		{
			vehicle["wheels"] = "2";
		  	return this;
		}

		public override VehicleBuilder BuildDoors()
		{
			vehicle["doors"] = "0";
		  	return this;
		}
	}
	
	//========================================================//
 
	/// The 'Product' class
	class Vehicle
	{
		private string _vehicleType;
		private Dictionary<string,string> _parts = new Dictionary<string,string>();

		// Constructor
		public Vehicle(string vehicleType)
		{
			this._vehicleType = vehicleType;
		}

		// Indexer
		public string this[string key]
		{
			get { return _parts[key]; }
		  	set { _parts[key] = value; }
		}

		public void Show()
		{
			Console.WriteLine("\n---------------------------");
		  	Console.WriteLine("Vehicle Type: {0}", _vehicleType);
		  	Console.WriteLine(" Frame : {0}", _parts["frame"]);
		  	Console.WriteLine(" Engine : {0}", _parts["engine"]);
		  	Console.WriteLine(" #Wheels: {0}", _parts["wheels"]);
		  	Console.WriteLine(" #Doors : {0}", _parts["doors"]);
		}
	}

	public class Program
	{
		public static void Main()
		{
			//Abstract Builder
			VehicleBuilder builder;
 
			//Director
      			// Create shop with vehicle builders
      			Shop shop = new Shop();
 
      			// Construct and display vehicles
      			builder = new ScooterBuilder();
      			shop.Construct(builder);
			//call base class VehicleBuilder
      			builder.Vehicle.Show();
 
      			builder = new CarBuilder();
      			shop.Construct(builder);
      			builder.Vehicle.Show();
 
      			builder = new MotorCycleBuilder();
      			shop.Construct(builder);
      			builder.Vehicle.Show();
 
      			// Wait for user
      			Console.ReadLine();	
		}
	}
}

