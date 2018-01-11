using System.Web.Mvc;
using CinemaBookingWeb.Services;

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
            var model = _playbillService.GetPlayBillViewModel();
            return View(model);
        }
    }
}