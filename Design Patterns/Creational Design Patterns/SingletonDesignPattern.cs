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
