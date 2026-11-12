using US_27_search_and_filter.Interface;
using US_27_search_and_filter.Models;

namespace US_27_search_and_filter.Repository;

public class BookingRepository : IBookingRepository
{
    private readonly List<Booking> _bookingsList = [];
    public void AddBooking(Booking booking)
    {
        if (booking == null)
            throw new ArgumentNullException(nameof(booking), "You cannot add an empty booking!");

        _bookingsList.Add(booking);
    }
    public List<Booking> GetAllBookings()
    {
        return _bookingsList.ToList();
    }
}
