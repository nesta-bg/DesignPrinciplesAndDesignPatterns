//code before DIP
namespace DIP
{
	public class Email
	{
		public string ToAddress { get; set; }
		public string Subject { get; set; }
		public string Content { get; set; }
		public void SendEmail()
		{
			//Send email
		}
	}

	public class SMS
	{
		public string PhoneNumber { get; set; }
		public string Message { get; set; }
		public void SendSMS()
		{
			//Send sms
		}
	}

	public class Notification
	{
		private Email _email;
		private SMS _sms;
		public Notification()
		{
			_email = new Email();
			_sms = new SMS();
		}

		public void Send()
		{
			_email.SendEmail();
			_sms.SendSMS();
		}
	}			
	
}


//code after DIP
namespace DIP
{
	public interface IMessage
	{
		void SendMessage();
	}

	public class Email : IMessage
	{
		public string ToAddress { get; set; }
		public string Subject { get; set; }
		public string Content { get; set; }
		public void SendMessage()
		{
			//Send email
		}
	}

	public class SMS : IMessage
	{
		public string PhoneNumber { get; set; }
		public string Message { get; set; }
		public void SendMessage()
		{
			//Send sms
		}
	}

	public class Notification
	{
		private ICollection<IMessage> _messages;

		public Notification(ICollection<IMessage> messages)
		{
			this._messages = messages;
		}
		public void Send()
		{
			foreach(var message in _messages)
			{
				message.SendMessage();
			}
		}
	}
}
