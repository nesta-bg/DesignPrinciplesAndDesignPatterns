//1.Example

using System.Collections.Generic;

namespace FactoryMethodDP
{
	/// <summary>
	/// Product
	/// </summary>
	abstract class Ingredient { }

	//===============================//

	/// <summary>
	/// Concrete Product
	/// </summary>
	class Bread : Ingredient { }

	/// <summary>
	/// Concrete Product
	/// </summary>
	class Turkey : Ingredient { }

	/// <summary>
	/// Concrete Product
	/// </summary>
	class Lettuce : Ingredient { }

	/// <summary>
	/// Concrete Product
	/// </summary>
	class Mayonnaise : Ingredient { }

	//=====================================================================================//

	/// <summary>
	/// Creator
	/// </summary>
	abstract class Sandwich
	{
		private List<Ingredient> _ingredients = new List<Ingredient>();

		public Sandwich()
		{
			CreateIngredients();
		}

		//Factory method
		public abstract void CreateIngredients();

		public List<Ingredient> Ingredients
		{
			get { return _ingredients; }
		}
	}

	//==========================================//

	/// <summary>
	/// Concrete Creator
	/// </summary>
	class TurkeySandwich : Sandwich
	{
		public override void CreateIngredients()
		{
			Ingredients.Add(new Bread());
			Ingredients.Add(new Mayonnaise());
			Ingredients.Add(new Lettuce());
			Ingredients.Add(new Turkey());
			Ingredients.Add(new Turkey());
			Ingredients.Add(new Bread());
		}
	}
	
	/// <summary>
	/// Concrete Creator
	/// </summary>
	class Dagwood : Sandwich //OM NOM NOM
	{
		public override void CreateIngredients()
		{
			Ingredients.Add(new Bread());
			Ingredients.Add(new Turkey());
			Ingredients.Add(new Turkey());
			Ingredients.Add(new Lettuce());
			Ingredients.Add(new Lettuce());
			Ingredients.Add(new Mayonnaise());
			Ingredients.Add(new Bread());
			Ingredients.Add(new Turkey());
			Ingredients.Add(new Turkey());
			Ingredients.Add(new Lettuce());
			Ingredients.Add(new Lettuce());
			Ingredients.Add(new Mayonnaise());
			Ingredients.Add(new Bread());
			Ingredients.Add(new Turkey());
			Ingredients.Add(new Turkey());
			Ingredients.Add(new Lettuce());
			Ingredients.Add(new Lettuce());
			Ingredients.Add(new Mayonnaise());
			Ingredients.Add(new Bread());
			Ingredients.Add(new Turkey());
			Ingredients.Add(new Turkey());
			Ingredients.Add(new Lettuce());
			Ingredients.Add(new Lettuce());
			Ingredients.Add(new Mayonnaise());
			Ingredients.Add(new Bread());
			Ingredients.Add(new Turkey());
			Ingredients.Add(new Turkey());
			Ingredients.Add(new Lettuce());
			Ingredients.Add(new Lettuce());
			Ingredients.Add(new Mayonnaise());
			Ingredients.Add(new Bread());
			Ingredients.Add(new Turkey());
			Ingredients.Add(new Turkey());
			Ingredients.Add(new Lettuce());
			Ingredients.Add(new Lettuce());
			Ingredients.Add(new Mayonnaise());
			Ingredients.Add(new Bread());
		}
	}
		
	//=====================================================================================//
	
	public class Program
	{
		public static void Main()
		{
		      var turkeySandwich = new TurkeySandwich();
        	var dagwood = new Dagwood();
		}
	}
}



//2.Example

using System;
using System.Collections.Generic;

namespace FactoryMethodDP
{
	/// The 'Product' abstract class
	abstract class Page
	{
	}
	
	//====================================//

	/// A 'ConcreteProduct' class
	class SkillsPage : Page
	{
	}
 
	/// A 'ConcreteProduct' class
	class EducationPage : Page
	{
	}

	/// A 'ConcreteProduct' class
	class ExperiencePage : Page
	{
	}

	/// A 'ConcreteProduct' class
	class IntroductionPage : Page
	{
	}

	/// A 'ConcreteProduct' class
	class ResultsPage : Page
	{
	}

	/// A 'ConcreteProduct' class
	class ConclusionPage : Page
	{
	}

	/// A 'ConcreteProduct' class
	class SummaryPage : Page
	{
	}

	/// A 'ConcreteProduct' class
	class BibliographyPage : Page
	{
	}
	
	//=============================================================================================//

	/// The 'Creator' abstract class
	abstract class Document
	{
		private List<Page> _pages = new List<Page>();

		// Constructor calls abstract Factory method
		public Document()
		{
		  this.CreatePages();
		}

		public List<Page> Pages
		{
		  get { return _pages; }
		}

		// Factory Method
		public abstract void CreatePages();
	}
	
	//====================================//
 
	/// A 'ConcreteCreator' class
	class Resume : Document
  	{
    	// Factory Method implementation
		public override void CreatePages()
		{
		  Pages.Add(new SkillsPage());
		  Pages.Add(new EducationPage());
		  Pages.Add(new ExperiencePage());
		}
  	}
 
	/// A 'ConcreteCreator' class
	class Report : Document
	{
		// Factory Method implementation
		public override void CreatePages()
		{
		  Pages.Add(new IntroductionPage());
		  Pages.Add(new ResultsPage());
		  Pages.Add(new ConclusionPage());
		  Pages.Add(new SummaryPage());
		  Pages.Add(new BibliographyPage());
		}
	}
	
	public class Program
	{
		public static void Main()
		{
      		Document[] documents = new Document[2];
 
      		documents[0] = new Resume();
      		documents[1] = new Report();
 
      		foreach (Document document in documents)
      		{
        		Console.WriteLine("\n" + document.GetType().Name + "--");
        		foreach (Page page in document.Pages)
        		{
          			Console.WriteLine(" " + page.GetType().Name);
        		}
      		}
 
      		// Wait for user
      		Console.ReadLine();
		}
	}
}
