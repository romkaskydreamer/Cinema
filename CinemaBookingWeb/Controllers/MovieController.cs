using CinemaBookingDto;
using CinemaBookingWeb.ViewModel;
using System.Web.Mvc;

namespace CinemaBookingWeb.Controllers
{
    public class MovieController : Controller
    {
        private readonly IRepository _repo;

        public MovieController(IRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Movie", new { id = 0 });
        }

        public ActionResult Movie(int id)
        {
            var movie = _repo.FindMovieById(id);
            var model = new MovieViewModel
            {
                Description = movie.Description,
                Name = movie.Name,
                Img = movie.Img
            };
            return View(model);
        }

    }
}