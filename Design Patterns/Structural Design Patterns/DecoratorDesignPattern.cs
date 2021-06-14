using System;

namespace DecoratorDP
{
	//Component
	public interface ICar
    	{
        	string Make { get; }
        	double GetPrice();
    	}
	
	//ConcreteComponent
	public sealed class Hyndai : ICar
    	{
        	public string Make
        	{
            		get { return "HatchBack"; }
        	}
		
        	public double GetPrice()
        	{
            		return 800000;
        	}
    	}
	
	//ConcreteComponent
	public sealed class Suzuki : ICar
    	{
        	public string Make
        	{
            		get { return "Sedan"; }
        	}
		
        	public double GetPrice()
        	{
            		return 1000000;
        	}
    	}
	
	//=======================================================//
	
	//Decorator
	public abstract class CarDecorator : ICar
    	{
        	private ICar car;
		
        	public CarDecorator(ICar Car)
        	{
            		car = Car;
        	}
		
        	public string Make { get { return car.Make; } }

        	public double GetPrice()
        	{
            		return car.GetPrice();
        	}
		
        	public abstract double GetDiscountedPrice();
    	}
	
	//ConcreteDecorator
    	public class OfferPrice : CarDecorator
    	{
        	public OfferPrice(ICar car) 
			: base(car)
        	{
        	}
		
        	public override double GetDiscountedPrice()
        	{
            		return .8 * base.GetPrice();
        	}
    	}
	
	public class Program
	{
		public static void Main()
		{
			ICar car = new Suzuki();
            		CarDecorator decorator = new OfferPrice(car);
            
			Console.WriteLine(string.Format("Make :{0}  Price:{1} " +
                		"DiscountPrice : {2}"
                		, decorator.Make,  decorator.GetPrice(),
                		decorator.GetDiscountedPrice()));
			
            		ICar car2 = new Hyndai();
			CarDecorator decorator2 = new OfferPrice(car2);
			
			Console.WriteLine(string.Format("Make :{0}  Price:{1} " +
                		"DiscountPrice : {2}"
                		, decorator2.Make,  decorator2.GetPrice(),
                		decorator2.GetDiscountedPrice()));
			
			Console.WriteLine();
		}	
	}
}
