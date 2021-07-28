//=======================FIRST EXAMPLE=================================//

using System;
using System.Collections.Generic;

namespace InterpreterdDP
{
	// The 'Context' class
	class Context
  	{
    		private string _input;
    		private int _output;
 
    		// Constructor
    		public Context(string input)
    		{
      			this._input = input;
    		}
 
    		// Gets or sets input
    		public string Input
    		{
      			get { return _input; }
      			set { _input = value; }
    		}
 
    		// Gets or sets output
    		public int Output
    		{
      			get { return _output; }
      			set { _output = value; }
    		}
  	}
 
	// The 'AbstractExpression' class
	abstract class Expression
  	{
    		public void Interpret(Context context)
    		{
      			if (context.Input.Length == 0)
        			return;
 
		  	if (context.Input.StartsWith(Nine()))
		  	{
				context.Output += (9 * Multiplier());
				context.Input = context.Input.Substring(2);
		  	}
		  	else if (context.Input.StartsWith(Four()))
		  	{
				context.Output += (4 * Multiplier());
				context.Input = context.Input.Substring(2);
		  	}
		  	else if (context.Input.StartsWith(Five()))
		  	{
				context.Output += (5 * Multiplier());
				context.Input = context.Input.Substring(1);
		  	}

		  	while (context.Input.StartsWith(One()))
		  	{
				context.Output += (1 * Multiplier());
				context.Input = context.Input.Substring(1);
		  	}
    		}
 
    		public abstract string One();
    		public abstract string Four();
    		public abstract string Five();
    		public abstract string Nine();
    		public abstract int Multiplier();
	}

	/// A 'TerminalExpression' class
	/// <remarks>
  	/// Thousand checks for the Roman Numeral M 
  	/// </remarks>

	class ThousandExpression : Expression
  	{
    		public override string One() { return "M"; }
    		public override string Four() { return " "; }
    		public override string Five() { return " "; }
    		public override string Nine() { return " "; }
    		public override int Multiplier() { return 1000; }
  	}

	/// A 'TerminalExpression' class
	/// <remarks>
	/// Hundred checks C, CD, D or CM
	/// </remarks>

	class HundredExpression : Expression
	{
		public override string One() { return "C"; }
		public override string Four() { return "CD"; }
		public override string Five() { return "D"; }
		public override string Nine() { return "CM"; }
		public override int Multiplier() { return 100; }
	}

	/// A 'TerminalExpression' class
	/// <remarks>
	/// Ten checks for X, XL, L and XC
	/// </remarks>

	class TenExpression : Expression
	{
		public override string One() { return "X"; }
		public override string Four() { return "XL"; }
		public override string Five() { return "L"; }
		public override string Nine() { return "XC"; }
		public override int Multiplier() { return 10; }
	}
 

	/// A 'TerminalExpression' class
	/// <remarks>
	/// One checks for I, II, III, IV, V, VI, VI, VII, VIII, IX
	/// </remarks>
	/// </summary>

	class OneExpression : Expression
	{
		public override string One() { return "I"; }
		public override string Four() { return "IV"; }
		public override string Five() { return "V"; }
		public override string Nine() { return "IX"; }
		public override int Multiplier() { return 1; }
	}
	
	public class Program
	{
		public static void Main(string[] args)
		{
			string roman = "MCMXXVIII";
      			Context context = new Context(roman);
 
      			// Build the 'parse tree'
      			List<Expression> tree = new List<Expression>();
      			tree.Add(new ThousandExpression());
      			tree.Add(new HundredExpression());
      			tree.Add(new TenExpression());
      			tree.Add(new OneExpression());
 
      			// Interpret
      			foreach (Expression exp in tree)
      			{
        			exp.Interpret(context);
      			}
 
      			Console.WriteLine("{0} = {1}", roman, context.Output);
 
      			Console.ReadLine();
		}
	}
}

//=======================SECOND EXAMPLE=================================//

using System;
using System.Collections.Generic;

namespace InterpreterDesignPattern
{
	public class Context
   	{
        	public string expression { get; set; }
        	public DateTime date { get; set; }
        
		public Context(DateTime date)
        	{
            		this.date = date;
        	}
    	}
	
	//=======================================================//
	
	public interface AbstractExpression
    	{
        	void Evaluate(Context context);
    	}
	
	public class DayExpression : AbstractExpression
    	{
        	public void Evaluate(Context context)
        	{
            		string expression = context.expression;
            		context.expression = expression.Replace("DD", context.date.Day.ToString());
        	}
    	}
	
	public class MonthExpression : AbstractExpression
    	{
        	public void Evaluate(Context context)
        	{
            		string expression = context.expression;
            		context.expression = expression.Replace("MM", context.date.Month.ToString());
        	}
    	}
	
	public class YearExpression : AbstractExpression
    	{
        	public void Evaluate(Context context)
        	{
            		string expression = context.expression;
            		context.expression = expression.Replace("YYYY", context.date.Year.ToString());
        	}
    	}
	
	class SeparatorExpression : AbstractExpression
    	{
        	public void Evaluate(Context context)
        	{
            		string expression = context.expression;
            		context.expression = expression.Replace(" ", "-");
        	}
    	}
		
	public class Program
	{
		public static void Main()
		{
            		Context context = new Context(DateTime.Now);
            		Console.WriteLine("Please select the Expression  : MM DD YYYY or YYYY MM DD or DD MM YYYY ");
            		context.expression = Console.ReadLine();
            
			List<AbstractExpression> objExpressions = new List<AbstractExpression>();
			string[] strArray = context.expression.Split(' ');
            		foreach(var item in strArray)
            		{
                		if(item == "DD")
                		{
                    			objExpressions.Add(new DayExpression());
                		}
                		else if (item == "MM")
                		{
                    			objExpressions.Add(new MonthExpression());
                		}
                		else if (item == "YYYY")
                		{
                    			objExpressions.Add(new YearExpression());
                		}
            		}
            		objExpressions.Add(new SeparatorExpression());
            		foreach(var obj in objExpressions)
            		{
                		obj.Evaluate(context);
            		}
            		Console.WriteLine(context.expression);
		}
	}
}


