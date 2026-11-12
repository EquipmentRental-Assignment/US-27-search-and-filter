using US_27_search_and_filter.Models;
using US_27_search_and_filter.Models.Enums;

namespace US_27_search_and_filter.Interface;

public interface IBookingService
{
    List<Booking> SearchBookings(string searchTerm, BookingStatus? status = null);
}