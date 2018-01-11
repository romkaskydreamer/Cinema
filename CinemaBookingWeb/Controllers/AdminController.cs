using CinemaBookingWeb.Services;
using CinemaBookingWeb.ViewModel;
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
            var bookings = _bookingService.GetAllBookings();
            return View("Admin", bookings);
        }

        public ActionResult Delete(int id)
        {
            var success = _bookingService.RemoveBooking(id);
            if (success) return RedirectToAction("Admin");
            return View("_Result", new ResultViewModel("Server error occured: ("));
        }

    }
}