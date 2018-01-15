using System.Collections.Generic;

namespace CinemaBookingWeb.ViewModel
{
    public class BookingsListViewModel
    {
        public List<BookingDetailsViewModel> Bookings { get; set; }
        public BookingsListViewModel() { Bookings = new List<BookingDetailsViewModel>(); }
    }
    public class BookingDetailsViewModel
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string SeatSummary { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string Hall { get; set; }
    }
}