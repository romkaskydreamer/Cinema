using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaBookingDto;
using CinemaBookingWeb.Models;
using CinemaBookingWeb.ViewModel;

namespace CinemaBookingWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repo;

        public HomeController(IRepository repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            var playBill = _repo.GetPlayBill().Where(x => x.DateMovie >= DateTime.Now);
            var model = new PlayBillViewModel(playBill);
            model.Posters.ForEach(poster =>
            {
                poster.Movie = _repo.FindMovieById(poster.MovieId);
                poster.Hall = _repo.FindHallById(poster.HallId);
            });

            return View(model);
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
                var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).Select(r => r[0].ErrorMessage).ToList();
                model.Errors = String.Join("\n", errors);
                return View("BookingForm", model);
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
            return res != 0 ? View("_Result", new ResultViewModel(message)) : View(model);
        }

        public ActionResult Movie(int id)
        {
            var movie = _repo.FindMovieById(id);
            var model = new MovieViewModel { Description = movie.Description, Name = movie.Name };
            return View(model);
        }

        //[Authorize]
        public ActionResult Admin()
        {
            var bookings = _repo.GetAllBookings().ToList();
            var adminBookings = new List<BookingDetailsViewModel>();
            bookings.ForEach(x => adminBookings.Add(GetBookingDetailsVm(x.Id)));
            var model = new BookingsListViewModel { Bookings = adminBookings };

            //var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            return View("Admin", model);
        }
        public ActionResult Delete(int id)
        {
            var success = _repo.RemoveBooking(id);
            if (success) RedirectToAction("Admin");
            return View("_Result", new ResultViewModel("Server error occured: ("));
        }

        public ActionResult Initializer()
        {
            ViewBag.Message = "Your initializer page.";

            return View();
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