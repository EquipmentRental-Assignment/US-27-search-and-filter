using System.Net.Mail;

namespace US_27_search_and_filter.Models;

public abstract class Customer( string email, string phoneNumber, bool isCompany)
{
    public Guid CustomerId { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = email;
    public string PhoneNumber { get; set; } = phoneNumber;
    public bool IsCompany { get; set; } = isCompany;

    private static string ValidateCustomer(string input)
    {
        if(string.IsNullOrWhiteSpace(input))
            throw new ArgumentNullException("You need to input something!");

        return input.Trim();
    }
    private static string ValidateEmail(string input)
    {
        ValidateCustomer(input);

        if (!MailAddress.TryCreate(input, out var _))
            throw new InvalidOperationException("You need to enter a valid email!"); 

        return null;
    }
}
