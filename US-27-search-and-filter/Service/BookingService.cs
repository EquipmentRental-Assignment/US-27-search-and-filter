using US_27_search_and_filter.Interface;
using US_27_search_and_filter.Models;
using US_27_search_and_filter.Models.Enums;

namespace US_27_search_and_filter.Service;

public class BookingService(IBookingRepository bookingRepository) : IBookingService
{
    private readonly IBookingRepository _bookingRepository = bookingRepository;

    public List<Booking> SearchBookings(string searchTerm, BookingStatus? status = null)
    {
        var bookings = _bookingRepository.GetAllBookings();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            string normalizedSearch = searchTerm.Trim();

            bookings = bookings.Where(b => b.BookingExternalId.Contains(normalizedSearch, StringComparison.OrdinalIgnoreCase) ||
                                           b.Customer.Email.Contains(normalizedSearch, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (status.HasValue)
        {
            bookings = bookings.Where(b => b.Status == status.Value).ToList();
        }

        return bookings;
    }
}