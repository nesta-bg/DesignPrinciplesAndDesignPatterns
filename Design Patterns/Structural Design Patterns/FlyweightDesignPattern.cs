using System;
using System.Collections.Generic;

namespace FlyweightDP
{
	//Flyweight
	abstract class BaseImage
	{
		//only extrinsic parameters
		public abstract void Display(int x, int y, int width, int height);
	}
	
	//Concrete Flyweight
	class Image : BaseImage
	{
		//intrinsic state of the image
		protected string _filename;
		
		public Image(string filename)
		{
			_filename = filename;
		}
		
		//both intrinsic and extrinsic parameters
		public override void Display(int x, int y, int width, int height)
		{
			Console.WriteLine(@"<img src=""{0}"" style=""left:{1}px; top:{2}px; width:{3}px; height:{4}px;"">", _filename, x, y, width, height);
		}
	}
	
	//Unshared Concrete Flyweight (not used)
	//public class Image
	//{
	//}
	
	//Flyweight Factory
	class ImageFactory
	{
		private Dictionary<string, BaseImage> flyweights = new Dictionary<string, BaseImage>();
		
		public BaseImage GetFlyweight(string filename)
		{
			BaseImage flyweight = null;
			Console.WriteLine();
			
			if(flyweights.ContainsKey(filename))
			{
				flyweight = flyweights[filename] as BaseImage;
				Console.WriteLine("Returning cashe image {0}", filename);
				
			}
			else
			{
				flyweight = new Image(filename);
				flyweights.Add(filename, flyweight);
				Console.WriteLine("Instantiating new image {0}", filename);
			}
			return flyweight;
		}
	}
	
	//Client
	public class WebPageRenderer
	{
		public void Render()
		{
			var factory = new ImageFactory();
			
			var image = factory.GetFlyweight("image png");
			image.Display(0, 0, 400, 250);
			
			image = factory.GetFlyweight("image png");
			image.Display(60, 420, 200, 90);
			
			image = factory.GetFlyweight("image png");
			image.Display(65, 925, 75, 75);
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			var renderer = new WebPageRenderer();
			renderer.Render();
		}	
	}
}
