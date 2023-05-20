namespace Application.Common.Models.Email;

public class SendEmailConfirmationDto
{
    public String Name { get; set; }
    public String Email { get; set; }
    public String Token { get; set; }
    public String Link { get; set; }

}