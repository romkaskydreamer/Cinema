using System.Web.Mvc;
using CinemaBookingWeb.Services;
using CinemaBookingWeb.ViewModel;

namespace CinemaBookingWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlayBillService _playbillService;
        public HomeController(IPlayBillService srv)
        {
            _playbillService = srv;
        }

        public ActionResult Index()
        {
            var posters = _playbillService.GetTodayPlayBill();
            var playBillViewModel = new PlayBillViewModel { Posters = posters };

            return View("Index", playBillViewModel);
        }
    }
}