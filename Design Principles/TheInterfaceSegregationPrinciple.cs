//Code before Interface Segregation Principle.
namespace ISP
{
	public interface ILead  
	{  
		void CreateSubTask();  
		void AssignTask();  
		void WorkOnTask();  
	}
	
	public class TeamLead : ILead  
	{ 
	   public void CreateSubTask()  
	   {  
		  //Code to create a sub task  
	   } 
	
	   public void AssignTask()  
	   {  
		  //Code to assign a task.  
	   }  
	   
	   public void WorkOnTask()  
	   {  
		  //Code to implement perform assigned task.  
	   }  
	}  

	public class Manager: ILead  
	{ 
	   public void CreateSubTask()  
	   {  
		  //Code to create a sub task.  
	   } 
	
	   public void AssignTask()  
	   {  
		  //Code to assign a task.  
	   }  
	   
	   public void WorkOnTask()  
	   {  
		  throw new Exception("Manager can't work on Task");  
	   }  
	}
	
	public class Programmer : ILead
	{
	   public void WorkOnTask()  
	   {  
		   //Code to implement perform assigned task.    
	   } 
	
	   public void CreateSubTask()  
	   {  
			throw new Exception("Programmer can't create a Task");    
	   } 
	
	   public void AssignTask()  
	   {  
		  throw new Exception("Programmer can't assign a Task");   
	   } 	
	}

	public class Program
	{
		public static void Main()
		{

		}
	}
} 

//Code after Interface Segregation Principle
namespace ISP
{
	public interface IProgrammer  
	{  
   		void WorkOnTask();  
	} 

	public interface ILead  
	{  
	   void AssignTask();  
	   void CreateSubTask();  
	} 

	public class Programmer: IProgrammer  
	{  
	   public void WorkOnTask()  
	   {  
		  //code to implement to work on the Task.  
	   }  
	}

	public class Manager: ILead  
	{  
	   public void AssignTask()  
	   {  
		  //Code to assign a Task  
	   }  
	   public void CreateSubTask()  
	   {  
	   //Code to create a sub taks from a task.  
	   }  
	} 

	public class TeamLead: IProgrammer, ILead  
	{  
	   public void AssignTask()  
	   {  
		  //Code to assign a Task  
	   }  
	   public void CreateSubTask()  
	   {  
		  //Code to create a sub task from a task.  
	   }  
	   public void WorkOnTask()  
	   {  
		  //code to implement to work on the Task.  
	   }  
	}

	public class Program
	{
		public static void Main()
		{

		}
	}
} 
