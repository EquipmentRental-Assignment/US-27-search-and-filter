using US_27_search_and_filter.Interface;
using US_27_search_and_filter.Models;
using US_27_search_and_filter.Models.Enums;
using US_27_search_and_filter.Presentation;
using US_27_search_and_filter.Repository;
using US_27_search_and_filter.Service;

IBookingRepository bookingRepository = new BookingRepository();
IBookingService bookingService = new BookingService(bookingRepository);

Customer customer1 = new Customer("Tomas", "tomas@gmail.com", "0701234567", false);
Customer customer2 = new Customer("Erik", "erik@gmail.com", "0709876543", false);

DateTime today = DateTime.Today;

bookingRepository.AddBooking(new Booking("Borrmaskin", customer1, today.AddDays(-10), today.AddDays(-5), 500, BookingStatus.Completed));
bookingRepository.AddBooking(new Booking("Gräsklippare", customer1, today.AddDays(5), today.AddDays(8), 800, BookingStatus.Confirmed));
bookingRepository.AddBooking(new Booking("Högtryckstvätt", customer2, today.AddDays(15), today.AddDays(20), 1200, BookingStatus.Cancelled));

BookingView menu = new BookingView(bookingService);
menu.Run();