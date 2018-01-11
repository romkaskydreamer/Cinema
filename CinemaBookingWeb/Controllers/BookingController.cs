using CinemaBookingDto;
using CinemaBookingWeb.Models;
using CinemaBookingWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CinemaBookingWeb.Controllers
{
    public class BookingController : Controller
    {
        private readonly IRepository _repo;

        public BookingController(IRepository repo)
        {
            _repo = repo;
        }

        public ActionResult BookingForm(int playBillId)
        {
            var model = GetBookingFormVm(playBillId);
            return View(model);
        }

        [HttpPost]
        public ActionResult BookingConfirm(BookingFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var m = GetBookingFormVm(model.Poster.Id);
                m.ClientEmail = model.ClientEmail;
                m.ClientName = model.ClientName;
                m.SeatId = model.SeatId;
                var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).Select(r => r[0].ErrorMessage).ToList();
                m.Errors = String.Join("\n", errors);
                return View("BookingForm", m);
            }

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
            return View("_Result", new ResultViewModel(message));
        }

        private BookingFormViewModel GetBookingFormVm(int id)
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

    }
}