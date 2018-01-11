using CinemaBookingWeb.Services;
using System.Web.Mvc;

namespace CinemaBookingWeb.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService srv)
        {
            _movieService = srv;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Movie", new { id = 0 });
        }

        public ActionResult Movie(int id)
        {
            var model = _movieService.GetMovieViewModel(id);

            return View(model);
        }

    }
}