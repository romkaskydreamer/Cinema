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
            var objs = _repo.GetPlayBill().Where(x => x.DateMovie.Date >= DateTime.Now.Date);
            var m = new PlayBillViewModel(objs);
            m.Posters.ForEach(f =>
            {
                f.Movie = _repo.FindMovieById(f.MovieId);
                f.Hall = _repo.FindHallById(f.HallId);
            });

            return View(m);
        }

        public ActionResult BookingForm(int playBillId)
        {
            var m = PrepareModel(playBillId);
            return View(m);
        }

        [HttpPost]
        public ActionResult BookingConfirm(BookingFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var m = PrepareModel(model.Poster.Id);
                m.ClientEmail = model.ClientEmail;
                m.ClientName = model.ClientName;
                m.SeatId = model.SeatId;
                var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).Select(r => r[0].ErrorMessage).ToList();
                m.Errors = String.Join("\n", errors);
                return View("BookingForm", m);
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
            var res = _repo.AddBooking(booking);
            return res != 0 ? View() : View(model);
        }

        public ActionResult Movie(int id)
        {
            var mov = _repo.FindMovieById(id);
            var model = new MovieViewModel { Description = mov.Description, Name = mov.Name };
            return View(model);//view movies
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Your admin page.";

            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Initializer()
        {
            ViewBag.Message = "Your initializer page.";

            return View();
        }

        private BookingFormViewModel PrepareModel(int id)
        {
            var playbill = _repo.FindPlayBillById(id);
            var m = new BookingFormViewModel { Poster = new Models.Poster(playbill) };
            m.Poster.Movie = _repo.FindMovieById(m.Poster.MovieId);
            m.Poster.Hall = _repo.FindHallById(m.Poster.HallId);
            var allSeats = _repo.GetSeats().Where(x => x.HallId == playbill.HallId);
            var busySeats = _repo.GetAllBookings().Where(x => x.PlayBillId == id);
            var freeSeats = allSeats.Where(x => !busySeats.Select(y => y.SeatId).Contains(x.Id)).ToList();
            var pricePolicies = _repo.GetPriceCategories();
            var fseatsVm = new List<SeatDdl>();
            foreach (var s in freeSeats)
            {
                var s1 = new SeatDdl(s);
                s1.Price = playbill.BasePrice * pricePolicies.Where(x => x.Id == s.PriceCategoryId).Select(x => x.MultiplierRate).FirstOrDefault();
                fseatsVm.Add(s1);
            }
            m.FreeSeats = fseatsVm;
            return m;
        }



    }
}