using CinemaBookingDto;
using CinemaBookingWeb.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace CinemaBookingWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository _repo;

        public AdminController(IRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Admin");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.User user)
        {
            if (ModelState.IsValid)
            {
                if (user.IsValid(user.UserName, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Initializer()
        {
            return View();
        }

        public ActionResult Admin()
        {
            var bookings = _repo.GetAllBookings().ToList();
            var adminBookings = new List<BookingDetailsViewModel>();
            bookings.ForEach(x => adminBookings.Add(GetBookingDetailsVm(x.Id)));
            var model = new BookingsListViewModel { Bookings = adminBookings };

            return View("Admin", model);
        }

        public ActionResult Delete(int id)
        {
            var success = _repo.RemoveBooking(id);
            if (success) return RedirectToAction("Admin");
            return View("_Result", new ResultViewModel("Server error occured: ("));
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