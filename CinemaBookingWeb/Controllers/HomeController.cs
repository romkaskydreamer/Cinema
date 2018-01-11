using System;
using System.Linq;
using System.Web.Mvc;
using CinemaBookingDto;
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
    }
}