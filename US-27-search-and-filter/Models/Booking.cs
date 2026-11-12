using US_27_search_and_filter.Models.Enums;

namespace US_27_search_and_filter.Models;

public class Booking(string title, Customer customer, DateTime startDate, DateTime endDate, decimal totalPrice, BookingStatus status)
{
    public Guid BookingInternalId { get; } = Guid.NewGuid();
    public string BookingExternalId { get; } = GenerateExternalId();
    public Customer Customer { get; } = ValidateCustomer(customer);
    public string Title { get; } = ValidateInput(title);
    public DateTime StartDate { get; } = ValidateDate(startDate);
    public DateTime EndDate { get; } = ValidateEndDate(startDate, endDate);
    public decimal TotalPrice { get; } = totalPrice;
    public BookingStatus Status { get; set; } = status;

    private static string ValidateInput(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Invalid title.", nameof(input));

        return input.Trim();
    }

    private static DateTime ValidateDate(DateTime date)
    {
        if (date == default)
            throw new ArgumentException("Invalid date.", nameof(date));

        return date.Date;
    }

    private static DateTime ValidateEndDate(DateTime startDate, DateTime endDate)
    {
        startDate = ValidateDate(startDate);
        endDate = ValidateDate(endDate);

        if (endDate < startDate)
            throw new ArgumentException("End date cannot be before start date.", nameof(endDate));

        return endDate;
    }

    private static Customer ValidateCustomer(Customer customer)
    {
        return customer ?? throw new ArgumentNullException(nameof(customer));
    }

    private static string GenerateExternalId()
    {
        return $"B-{Guid.NewGuid().ToString("N")[..8].ToUpperInvariant()}";
    }
}