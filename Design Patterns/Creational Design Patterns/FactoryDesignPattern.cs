	CREATE TABLE [dbo].[Employee]
	(
		[Id]             INT          IDENTITY (1, 1) NOT NULL,
		[Name]           VARCHAR (50) NOT NULL,
		[JobDescription] VARCHAR (50) NOT NULL,
		[Number]         VARCHAR (50) NOT NULL,
		[Department]     VARCHAR (50) NOT NULL,
		[HourlyPay]      DECIMAL (18) NOT NULL, //***
		[Bonus]          DECIMAL (18) NOT NULL, //***
		[EmployeeTypeID] INT          NOT NULL,
		PRIMARY KEY CLUSTERED ([Id] ASC),
		CONSTRAINT [FK_Employee_EmployeeType] FOREIGN KEY ([EmployeeTypeID]) REFERENCES [dbo].[Employee_Type] ([Id])
	)
  
  //===============================Without Factory Pattern================================================//
  
	public class EmployeesController : BaseController
  	{     
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Name,JobDescription,Number,Department,HourlyPay,Bonus,EmployeeTypeID")] Employee employee)
		{
            		if (ModelState.IsValid)
            		{
				if (employee.EmployeeTypeID == 1)
				{
				    employee.HourlyPay = 8;
				    employee.Bonus = 10;
				}
				else if (employee.EmployeeTypeID == 2)
				{
				    employee.HourlyPay = 12;
				    employee.Bonus = 5;
				}
                		db.Employees.Add(employee);
                		db.SaveChanges();
                		return RedirectToAction("Index");
            		}

            		ViewBag.EmployeeTypeID = new SelectList(db.Employee_Type, "Id", "EmployeeType", employee.EmployeeTypeID);
            		return View(employee);
        	}
	  }
  
   //===============================With Factory Pattern================================================//
   
   	public interface IEmployeeManager
   	{
        	decimal GetBonus();
        	decimal GetPay();
   	}
	
	public class ContractEmployeeManager : IEmployeeManager
	{
		public decimal GetBonus()
		{
			return 5;
		}

		public decimal GetPay()
		{
			return 12;
		}
	}

	public class PermanentEmployeeManager : IEmployeeManager
	{
		public decimal GetBonus()
		{
			return 10;
		}

		public decimal GetPay()
		{
			return 8;
		}
	}
	
	public class EmployeeManagerFactory
    	{
        	public IEmployeeManager GetEmployeeManager(int employeeTypeID)
        	{
            		IEmployeeManager returnValue = null;
			
            		if (employeeTypeID == 1)
            		{
                		returnValue = new PermanentEmployeeManager();
            		}
            		else if (employeeTypeID == 2)
            		{
                		returnValue = new ContractEmployeeManager();
            		}
            		return returnValue;
        	}
    	}
	
	public class EmployeesController : BaseController
	{
		[HttpPost]
        	[ValidateAntiForgeryToken]
        	public ActionResult Create([Bind(Include = "Id,Name,JobDescription,Number,Department,HourlyPay,Bonus,EmployeeTypeID")] Employee employee)
        	{
            		if (ModelState.IsValid)
            		{
                		EmployeeManagerFactory empFactory = new EmployeeManagerFactory();
                		IEmployeeManager empManager = empFactory.GetEmployeeManager(employee.EmployeeTypeID);
                		employee.Bonus = empManager.GetBonus();
                		employee.HourlyPay = empManager.GetPay();
                		db.Employees.Add(employee);
                		db.SaveChanges();
                		return RedirectToAction("Index");
            		}

            		ViewBag.EmployeeTypeID = new SelectList(db.Employee_Type, "Id", "EmployeeType", employee.EmployeeTypeID);
            		return View(employee);
        	}
	}
   
