using System;

namespace MediatorDP
{
	/// <summary>
	/// The IMediator interface, which 
	/// defines a send message method 
	/// which the concrete mediators must implement.
	/// </summary>
	interface IMediator
	{
		void SendMessage(string message, ConcessionStand concessionStand);
	}
	
	/// <summary>
	/// The Colleague abstract class, representing 
	/// an entity involved in the conversation 
	/// which should receive messages.
	/// </summary>
	abstract class ConcessionStand
	{
		protected IMediator mediator;

		public ConcessionStand(IMediator mediator)
		{
			this.mediator = mediator;
		}
	}
	
	//=============================================================================//
	
	/// <summary>
	/// A Concrete Colleague class
	/// </summary>
	class NorthConcessionStand : ConcessionStand
	{
		// Constructor
		public NorthConcessionStand(IMediator mediator) 
			: base(mediator) { }

		public void Send(string message)
		{
			Console.WriteLine("North Concession Stand sends message: " + message);
			mediator.SendMessage(message, this);
		}

		public void Notify(string message)
		{
			Console.WriteLine("North Concession Stand gets message: "  + message);
		}
	}

	/// <summary>
	/// A Concrete Colleague class
	/// </summary>
	class SouthConcessionStand : ConcessionStand
	{
		public SouthConcessionStand(IMediator mediator) 
			: base(mediator) { }

		public void Send(string message)
		{
			Console.WriteLine("South Concession Stand sends message: " + message);
			mediator.SendMessage(message, this);
		}

		public void Notify(string message)
		{
			Console.WriteLine("South Concession Stand gets message: " + message);
		}
	}
	
	/// <summary>
	/// The Concrete Mediator class, which implement the send message method and keep track of all participants in the conversation.
	/// </summary>
	class ConcessionsMediator : IMediator
	{
		private NorthConcessionStand _northConcessions;
		private SouthConcessionStand _southConcessions;

		public NorthConcessionStand NorthConcessions
		{
			set { _northConcessions = value; }
		}

		public SouthConcessionStand SouthConcessions
		{
			set { _southConcessions = value; }
		}

		public void SendMessage(string message, ConcessionStand colleague)
		{
			if (colleague == _northConcessions)
			{
				_southConcessions.Notify(message);
			}
			else
			{
				_northConcessions.Notify(message);
			}
		}
	}
	
	public class Program
	{
		public static void Main(string[] args)
		{
			/// The Concrete Mediator class
			ConcessionsMediator mediator = new ConcessionsMediator();

			/// The Concrete Colleague classes
			NorthConcessionStand leftKitchen = new NorthConcessionStand(mediator);
			SouthConcessionStand rightKitchen = new SouthConcessionStand(mediator);

			mediator.NorthConcessions = leftKitchen;
			mediator.SouthConcessions = rightKitchen;

			leftKitchen.Send("Can you send some popcorn?");
			rightKitchen.Send("Sure thing, Kenny's on his way.");

			rightKitchen.Send("Do you have any extra hot dogs?  We've had a rush on them over here.");
			leftKitchen.Send("Just a couple, we'll send Kenny back with them.");

			Console.ReadLine();
		}
	}
}
