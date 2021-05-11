using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandDP
{
	/// <summary>
	/// Represents an item being ordered from this restaurant.
	/// </summary>
	public class MenuItem
	{
		public string Name { get; set; }
		public int Amount { get; set; }
		public double Price { get; set; }

		public MenuItem(string name, int amount, double price)
		{
			Name = name;
			Amount = amount;
			Price = price;
		}

		public void Display()
		{
			Console.WriteLine("\nName: " + Name);
			Console.WriteLine("Amount: " + Amount.ToString());
			Console.WriteLine("Price: $" + Price.ToString());
		}
	}
	
	//==============================================================================//
	
	/// <summary>
	/// The Invoker class
	/// </summary>
	public class Patron
	{
		// The Command abstract class
		private OrderCommand _orderCommand;
		// manuItem class
		private MenuItem _menuItem;
		///The Receiver
		private FastFoodOrder _order;

		public Patron()
		{
			_order = new FastFoodOrder();
		}

		public void SetCommand(int commandOption)
		{
			_orderCommand = new CommandFactory().GetCommand(commandOption);
		}

		public void SetMenuItem(MenuItem item)
		{
			_menuItem = item;
		}

		public void ExecuteCommand()
		{
			_order.ExecuteCommand(_orderCommand, _menuItem);
		}

		public void ShowCurrentOrder()
		{
			_order.ShowCurrentItems();
		}
	}
	
	public class CommandFactory
	{
		//Factory method
		public OrderCommand GetCommand(int commandOption)
		{
			switch (commandOption)
			{
				case 1:
					return new AddCommand();
				case 2:
					return new ModifyCommand();
				case 3:
					return new RemoveCommand();
				default:
					return new AddCommand();
			}
		}
	}
	
	//==============================================================================//
	
	/// <summary>
	/// The Receiver
	/// </summary>
	public class FastFoodOrder
	{
		public List<MenuItem> currentItems { get; set; }
		
		public FastFoodOrder()
		{
			currentItems = new List<MenuItem>();
		}

		public void ExecuteCommand(OrderCommand command, MenuItem item)
		{
			command.Execute(this.currentItems, item);
		}

		public void ShowCurrentItems()
		{
			foreach(var item in currentItems)
			{
				item.Display();
			}
			Console.WriteLine("-----------------------");
		}
	}
	
	//==============================================================================//
	
	/// <summary>
	/// The Command abstract class
	/// </summary>
	public abstract class OrderCommand
	{
		public abstract void Execute(List<MenuItem> order, MenuItem newItem);
	}
		
	/// <summary>
	/// A concrete command
	/// </summary>
	public class AddCommand : OrderCommand
	{
		public override void Execute(List<MenuItem> currentItems, MenuItem newItem)
		{
			currentItems.Add(newItem);
		}
	}

	/// <summary>
	/// A concrete command
	/// </summary>
	public class RemoveCommand : OrderCommand
	{
		public override void Execute(List<MenuItem> currentItems, MenuItem newItem)
		{
			currentItems.Remove(currentItems.Where(x=>x.Name == newItem.Name).First());
		}
	}

	/// <summary>
	/// A concrete command
	/// </summary>
	public class ModifyCommand : OrderCommand
	{
		public override void Execute(List<MenuItem> currentItems, MenuItem newItem)
		{
			var item = currentItems.Where(x => x.Name == newItem.Name).First();
			item.Price = newItem.Price;
			item.Amount = newItem.Amount;
		}
	}
	
	//==============================================================================//
	
	public class Program
	{
		public static void Main(string[] args)
		{
			//Invoker class (linked with abstract command OrderCommand, SetMenuItem and Receiver FastFoodOrder)
			Patron patron = new Patron();
			//Concrete Command
			patron.SetCommand(1 /*Add*/);
			patron.SetMenuItem(new MenuItem("French Fries", 2, 1.99));
			//Receiver
			patron.ExecuteCommand();

			patron.SetCommand(1 /*Add*/);
			patron.SetMenuItem(new MenuItem("Hamburger", 2, 2.59));
			patron.ExecuteCommand();

			patron.SetCommand(1 /*Add*/);
			patron.SetMenuItem(new MenuItem("Drink", 2, 1.19));
			patron.ExecuteCommand();

			patron.ShowCurrentOrder();

			//Remove the french fries
			patron.SetCommand(3 /*Remove*/);
			patron.SetMenuItem(new MenuItem("French Fries", 2, 1.99));
			patron.ExecuteCommand();

			patron.ShowCurrentOrder();

			//Now we want 4 hamburgers rather than 2
			patron.SetCommand(2 /*Edit*/);
			patron.SetMenuItem(new MenuItem("Hamburger", 4, 2.59));
			patron.ExecuteCommand();

			patron.ShowCurrentOrder();

			Console.ReadLine();
		}
	}
}
