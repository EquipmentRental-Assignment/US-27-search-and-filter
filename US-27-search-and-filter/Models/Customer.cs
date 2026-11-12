using System.Net.Mail;

namespace US_27_search_and_filter.Models;

public class Customer(string name, string email, string phoneNumber, bool isCompany, string? organizationNumber = null)
{
    public Guid CustomerId { get; } = Guid.NewGuid();
    public string CustomerName { get; } = ValidateCustomer(name);
    public string Email { get; } = ValidateEmail(email);
    public string PhoneNumber { get; } = ValidateCustomer(phoneNumber);
    public bool IsCompany { get; } = isCompany;
    public string? OrganizationNumber { get; } = ValidateOrganizationNumber(organizationNumber, isCompany);

    private static string ValidateCustomer(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("You need to input something!", nameof(input));

        return input.Trim();
    }

    private static string ValidateEmail(string input)
    {
        var validatedInput = ValidateCustomer(input);

        if (!MailAddress.TryCreate(validatedInput, out _))
            throw new ArgumentException("You need to enter a valid email!", nameof(input));

        return validatedInput;
    }

    private static string? ValidateOrganizationNumber(string? organizationNumber, bool isCompany)
    {
        if (isCompany && string.IsNullOrWhiteSpace(organizationNumber))
            throw new ArgumentException("Company customers must have an organization number.", nameof(organizationNumber));

        return string.IsNullOrWhiteSpace(organizationNumber) ? null : organizationNumber.Trim();
    }
}