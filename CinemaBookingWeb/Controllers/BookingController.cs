using CinemaBookingWeb.Models.Dto;
using CinemaBookingWeb.Services;
using CinemaBookingWeb.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CinemaBookingWeb.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService srv)
        {
            _bookingService = srv;
        }

        public ActionResult BookingForm(int playBillId)
        {
            var poster = _bookingService.GetBookingDtoForm(playBillId);
            var model = new BookingListViewModel { Poster = poster, FreeSeats = _bookingService.GetFreeSeatsForPlayBill(playBillId).ToList() };

            return View("BookingForm", model);
        }

        [HttpPost]
        public ActionResult BookingConfirm(BookingListViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).Select(r => r[0].ErrorMessage).ToList();
                //model.Errors = String.Join("\n", errors);
                return View("BookingForm", model);
            }
            var booking = new BookingDto
            {
                ClientEmail = model.ClientEmail,
                ClientName = model.ClientName,
                DateCreated = DateTime.Now,
                SeatId = model.SeatId,
                PlayBillId = model.Poster.Id,
                Id = 0
            };
            bool isTicketBusy = _bookingService.IsBookingBusy(booking);
            if(isTicketBusy) return View("_Result", new ResultViewModel("Sorry. Ticket was already booked."));
            bool success =  _bookingService.AddBooking(booking);
            string message = success ? "You successfully boocked a ticket" : "Server error occured :(";

            return View("_Result", new ResultViewModel(message));
        }

    }
}