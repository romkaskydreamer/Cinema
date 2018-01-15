using CinemaBookingWeb.Services;
using CinemaBookingWeb.ViewModel;
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
            var movie = _movieService.GetMovieById(id);
            var model = new MovieViewModel
            {
                Description = movie.Description,
                Name = movie.Name,
                Img = movie.Img
            };
            return View("Movie", model);
        }

    }
}