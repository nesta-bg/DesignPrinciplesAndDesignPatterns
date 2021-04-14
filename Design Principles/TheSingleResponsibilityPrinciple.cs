//Code without Single Responsibility Principle
public class InvitationService
{
	public void SendInvite(string email, string firstName, string lastName)
    {
    	if(String.IsNullOrWhiteSpace(firstName) || String.IsNullOrWhiteSpace(lastName))
        {
         	throw new Exception("Name is not valid!");
        }
    	
    	if(!email.Contains("@") || !email.Contains("."))
        {
        	throw new Exception("Email is not valid!!");
        }
        SmtpClient client = new SmtpClient();
        client.Send(new MailMessage("mysite@nowhere.com", email) { Subject = "Please join me at my party!" });
    }
}


//Code after Single Responsibility Principle 
public class UserService
{
    public void Validate(string firstName, string lastName)
    {
        if(String.IsNullOrWhiteSpace(firstName) || String.IsNullOrWhiteSpace(lastName))
        {
            throw new Exception("The name is invalid!");
        }
    }
}

public class EmailService
{
    public void Validate(string email)
    {
        if (!email.Contains("@") || !email.Contains("."))
        {
            throw new Exception("Email is not valid!!");
        }
    }
}

public class InvitationService
{
    UserService _userService;
    EmailService _emailService;

    public InvitationService(UserService userService, EmailService emailService)
    {
        _userService = userService;
        _emailService = emailService;
    }
    public void SendInvite(string email, string firstName, string lastName)
    {
        _userService.Validate(firstName, lastName);
        _emailService.Validate(email);
        SmtpClient client = new SmtpClient();
        client.Send(new MailMessage("sitename@invites2you.com", email) { Subject = "Please join me at my party!" });
    }
}
