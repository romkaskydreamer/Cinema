using CinemaBookingWeb.Services;
using CinemaBookingWeb.ViewModel;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace CinemaBookingWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookingService _bookingService;
        public AdminController(IBookingService srv)
        {
            _bookingService = srv;
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
            var bookings = _bookingService.GetAllBookings().ToList();
            var list = new BookingsListViewModel();
            foreach (var b in bookings)
            {
                var bd = new BookingDetailsViewModel
                {
                    ClientEmail = b.ClientEmail,
                    ClientName = b.ClientName,
                    DateCreated = b.DateCreated,
                    Id = b.Id,
                    MovieName = b.PlayBill.Movie.Name,
                    Hall = b.PlayBill.Hall.Name,
                    SeatSummary = $"Row: {b.Seat.RowNum}, Seat: {b.Seat.SeatNum}"
                };
                list.Bookings.Add(bd);
            }
            return View("Admin", list);
        }

        public ActionResult Delete(int id)
        {
            var success = _bookingService.RemoveBooking(id);
            if (success) return RedirectToAction("Admin");
            return View("_Result", new ResultViewModel("Server error occured: ("));
        }

    }
}