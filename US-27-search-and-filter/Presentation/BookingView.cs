using US_27_search_and_filter.Interface;
using US_27_search_and_filter.Models;
using US_27_search_and_filter.Models.Enums;

namespace US_27_search_and_filter.Presentation;

public class BookingView(IBookingService bookingService)
{
    private readonly IBookingService _bookingService = bookingService;

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n--- BOOKING SYSTEM - TEST MENU ---");
            Console.WriteLine("1. Show all bookings");
            Console.WriteLine("2. Test search by email");
            Console.WriteLine("3. Test search by booking number");
            Console.WriteLine("4. Test upcoming bookings");
            Console.WriteLine("5. Test status filtering");
            Console.WriteLine("6. Test no matching bookings (A1)");
            Console.WriteLine("7. Test no bookings after filtering (A2)");
            Console.WriteLine("0. Exit");
            Console.Write("\nChoose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowBookings(_bookingService.SearchBookings(""));
                    break;

                case "2":
                    ShowBookings(_bookingService.SearchBookings("tomas@gmail.com"));
                    break;

                case "3":
                    var bookings = _bookingService.SearchBookings("");
                    var bookingNumber = bookings.FirstOrDefault()?.BookingExternalId;

                    if (bookingNumber != null)
                        ShowBookings(_bookingService.SearchBookings(bookingNumber));
                    else
                        ShowBookings([]);
                    break;

                case "4":
                    ShowBookings(_bookingService.SearchBookings("", BookingFilter.Upcoming));
                    break;

                case "5":
                    ShowBookings(_bookingService.SearchBookings("", BookingFilter.All, BookingStatus.Confirmed));
                    break;

                case "6":
                    ShowBookings(_bookingService.SearchBookings("unknown@gmail.com"));
                    break;

                case "7":
                    ShowBookings(_bookingService.SearchBookings("tomas@gmail.com", BookingFilter.Past, BookingStatus.Cancelled));
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private static void ShowBookings(List<Booking> bookings)
    {
        Console.WriteLine("\n--- SEARCH RESULTS ---");

        if (bookings.Count == 0)
        {
            Console.WriteLine("No bookings found.");
            return;
        }

        foreach (Booking booking in bookings)
        {
            Console.WriteLine($"\nBooking number: {booking.BookingExternalId}");
            Console.WriteLine($"Title: {booking.Title}");
            Console.WriteLine($"Customer: {booking.Customer.CustomerName}");
            Console.WriteLine($"Email: {booking.Customer.Email}");
            Console.WriteLine($"Period: {booking.StartDate:yyyy-MM-dd} - {booking.EndDate:yyyy-MM-dd}");
            Console.WriteLine($"Status: {booking.Status}");
            Console.WriteLine($"Total price: {booking.TotalPrice} SEK");
        }

        Console.WriteLine($"\nTotal bookings found: {bookings.Count}");
    }
}