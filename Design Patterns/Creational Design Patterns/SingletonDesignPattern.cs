using System;
using System.Text;
using System.IO;

namespace Logger
{
	public interface ILog
    	{
        	void LogException(string message);
    	}
	
    	public sealed class Log : ILog
    	{
        	private Log()
        	{
        	}
		
        private static readonly Lazy<Log> instance = new Lazy<Log>(() => new Log());

        public static Log GetInstance
        {
        	get
            	{
                	return instance.Value;
            	}
        }

        public void LogException(string message)
        {
        	string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToShortDateString());
            	string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            	StringBuilder sb = new StringBuilder();
		sb.AppendLine("----------------------------------------");
		sb.AppendLine(DateTime.Now.ToString());
		sb.AppendLine(message);
		using (StreamWriter writer = new StreamWriter(logFilePath, true))
		{
			writer.Write(sb.ToString());
			writer.Flush();
		}
        }
    }
}

//===============================================================================//

using System;
using Logger;

namespace Employee
{
	public class EmployeesController : Controller
    	{
        	private ILog _ILog;
        	private EmployeePortalEntities db = new EmployeePortalEntities();
        
		public EmployeesController()
        	{
            		_ILog = Log.GetInstance;
        	}
		
        	protected override void OnException(ExceptionContext filterContext)
        	{
            		_ILog.LogException(filterContext.Exception.ToString());
            		filterContext.ExceptionHandled = true;
            		this.View("Error").ExecuteResult(this.ControllerContext);
        	}
		
		...
	}	
}

//===================================SECOND EXAMPLE===========================================//

using System;
using System.Collections.Generic;

namespace SDP
{
	public sealed class TableServers
	{
		private List<string> servers = new List<string>();
		private int nextServer = 0;
		
		private static readonly Lazy<TableServers> _instance = new Lazy<TableServers>(() => new TableServers());
	
		private TableServers() 
		{
			this.servers.Add("Tim");
			this.servers.Add("Sue");
			this.servers.Add("Mary");
			this.servers.Add("Bob");
			this.servers.Add("John");
			this.servers.Add("Amy");
		}
	
		public static TableServers GetTableServers 
		{
			get 
			{ 
				return _instance.Value; 
			}	
		}
	
		public string GetNextServer() 
		{
			string output = servers[nextServer];
		
			nextServer += 1;
		
			if(nextServer >= servers.Count)
			{
				nextServer = 0;
			}
		
			return output;
		}
	}
		
	public class Program
	{
		static TableServers host1List = TableServers.GetTableServers;  
		static TableServers host2List = TableServers.GetTableServers; 

		
		public static void Main(string[] args)
        	{
			for (int i = 0; i < 10; i++)
			{
				Host1GetNextServer();
				Host2GetNextServer();
			}
		
			Console.ReadLine();
		}
	
		private static void Host1GetNextServer() 
		{
			Console.WriteLine("The next server is: " + host1List.GetNextServer());
		}

		private static void Host2GetNextServer() 
		{
			Console.WriteLine("The next server is: " + host2List.GetNextServer());
		}
	}
}


