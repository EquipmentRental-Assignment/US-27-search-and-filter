using US_27_search_and_filter.Models;

namespace US_27_search_and_filter.Interface;

public interface IBookingRepository
{
    void AddBooking(Booking booking);
    List<Booking> GetAllBookings();
}
