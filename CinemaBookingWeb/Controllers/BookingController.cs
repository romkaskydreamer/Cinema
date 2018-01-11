using CinemaBookingWeb.Services;
using CinemaBookingWeb.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CinemaBookingWeb.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService srv)
        {
            _bookingService = srv;
        }

        public ActionResult BookingForm(int playBillId)
        {
            var model = _bookingService.GetBookingFormVm(playBillId);
            return View(model);
        }

        [HttpPost]
        public ActionResult BookingConfirm(BookingFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var m = _bookingService.GetBookingFormVm(model.Poster.Id);
                m.ClientEmail = model.ClientEmail;
                m.ClientName = model.ClientName;
                m.SeatId = model.SeatId;
                var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).Select(r => r[0].ErrorMessage).ToList();
                m.Errors = String.Join("\n", errors);
                return View("BookingForm", m);
            }

            var resultVm = _bookingService.AddBooking(model);
            return View("_Result", resultVm);
        }

    }
}