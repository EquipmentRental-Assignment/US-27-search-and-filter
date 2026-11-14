using US_27_search_and_filter.Interface;
using US_27_search_and_filter.Models;
using US_27_search_and_filter.Models.Enums;

namespace US_27_search_and_filter.Service;

public class BookingService(IBookingRepository bookingRepository) : IBookingService
{
    private readonly IBookingRepository _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));

    public List<Booking> SearchBookings(string searchTerm, BookingFilter filter = BookingFilter.All, BookingStatus? status = null)
    {
        var bookings = _bookingRepository.GetAllBookings();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            string normalizedSearch = searchTerm.Trim();

            bookings = bookings.Where(b => b.BookingExternalId.Contains(normalizedSearch, StringComparison.OrdinalIgnoreCase) ||
                                           b.Customer.Email.Contains(normalizedSearch, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        DateTime today = DateTime.Today;

        bookings = filter switch
        {
            BookingFilter.Past => bookings.Where(b => b.EndDate < today).ToList(),
            BookingFilter.Upcoming => bookings.Where(b => b.StartDate > today).ToList(),
            _ => bookings
        };

        if (status.HasValue)
        {
            bookings = bookings.Where(b => b.Status == status.Value).ToList();
        }

        return bookings;
    }
}