using CinemaBookingDto;
using CinemaBookingWeb.Models;
using CinemaBookingWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaBookingWeb.Services
{
    public interface IBookingService
    {
        BookingFormViewModel GetBookingFormVm(int id);
        ResultViewModel AddBooking(BookingFormViewModel vm);
        bool RemoveBooking(int id);
        BookingsListViewModel GetAllBookings();
    }
    public class BookingService : IBookingService
    {
        private readonly IRepository _repo;

        public BookingService(IRepository repo)
        {
            _repo = repo;
        }

        public ResultViewModel AddBooking(BookingFormViewModel model)
        {
            var booking = new CinemaBookingDto.Models.Booking
            {
                ClientEmail = model.ClientEmail,
                ClientName = model.ClientName,
                DateCreated = DateTime.Now,
                SeatId = model.SeatId,
                PlayBillId = model.Poster.Id,
                Id = 0
            };
            bool isTicketBusy = _repo.IsBookingBusy(booking);
            int res = isTicketBusy ? 0 : _repo.AddBooking(booking);
            string message = isTicketBusy ? "Sorry. Ticket was already booked." : "Server error occured :(";
            if (res != 0) message = "You successfully boocked a ticket";
            return new ResultViewModel(message);
        }

        public BookingsListViewModel GetAllBookings()
        {
            var bookings = _repo.GetAllBookings().ToList();
            var adminBookings = new List<BookingDetailsViewModel>();
            bookings.ForEach(x => adminBookings.Add(GetBookingDetailsVm(x.Id)));
            var model = new BookingsListViewModel { Bookings = adminBookings };
            return model;
        }

        public BookingFormViewModel GetBookingFormVm(int id)
        {
            var playbill = _repo.FindPlayBillById(id);
            var model = new BookingFormViewModel { Poster = new Poster(playbill) };
            model.Poster.Movie = _repo.FindMovieById(model.Poster.MovieId);
            model.Poster.Hall = _repo.FindHallById(model.Poster.HallId);
            var allSeats = _repo.GetSeats().Where(x => x.HallId == playbill.HallId);
            var busySeats = _repo.GetAllBookings().Where(x => x.PlayBillId == id);
            var freeSeats = allSeats.Where(x => !busySeats.Select(y => y.SeatId).Contains(x.Id)).ToList();
            var pricePolicies = _repo.GetPriceCategories();
            var freeSeatsVm = new List<SeatDdl>();
            foreach (var s in freeSeats)
            {
                var ddlItem = new SeatDdl(s);
                ddlItem.Price = playbill.BasePrice * pricePolicies.Where(x => x.Id == s.PriceCategoryId).Select(x => x.MultiplierRate).FirstOrDefault();
                freeSeatsVm.Add(ddlItem);
            }
            model.FreeSeats = freeSeatsVm;
            return model;
        }

        public bool RemoveBooking(int id)
        {
            return _repo.RemoveBooking(id);
        }

        private BookingDetailsViewModel GetBookingDetailsVm(int bookingId)
        {
            var booking = _repo.FindBookingById(bookingId);
            var playbill = _repo.FindPlayBillById(booking.PlayBillId);
            var model = new BookingDetailsViewModel { ClientEmail = booking.ClientEmail, ClientName = booking.ClientName, DateCreated = booking.DateCreated, Id = booking.Id };
            model.MovieName = _repo.FindMovieById(playbill.MovieId).Name;
            var seat = _repo.FindSeatById(booking.SeatId);
            model.SeatSummary = $"Row: {seat.RowNum}, Seat: {seat.SeatNum}";
            model.Hall = _repo.FindHallById(playbill.HallId).Name;
            return model;
        }
    }
}