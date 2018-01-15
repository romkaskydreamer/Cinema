using System.Web.Mvc;
using CinemaBookingDto;
using CinemaBookingWeb.Controllers;
using CinemaBookingWeb.Services;
using CinemaBookingWeb.ViewModel;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace CinemaBookingWebTests.Controllers
{
    [TestFixture]
    public class BookingControllerTest
    {
        private string pathToTestJsonFiles = @"D:\Projects\Cinema\CinemaBookingWeb\";
        private readonly CinemaBookingData.JsonRepository repo;
        private readonly IBookingService srv;
        public BookingControllerTest()
        {
            repo = new CinemaBookingData.JsonRepository(new RepoConfig { path = pathToTestJsonFiles });
            srv = new BookingService(repo);
        }

        [Test]
        public void BookingFormTest()
        {
            var controller = new BookingController(srv);
            var result = controller.BookingForm(1) as ViewResult;
            var bf = (BookingFormViewModel)result.ViewData.Model;
            Assert.AreEqual("BookingForm", result.ViewName);
            Assert.IsNotNull(bf);
            Assert.IsNotNull(bf.Poster);
            Assert.AreEqual(1, bf.Poster.MovieId);
            Assert.AreEqual(1, bf.Poster.HallId);
            Assert.AreEqual(55.0, bf.Poster.BasePrice);
        }

        [Test]
        public void BookingConfirmTest()
        {
            //var testConfirmModel = new BookingListViewModel
            //{
            //    ClientEmail = "test@email.com",
            //    ClientName = "unit-test",
            //    SeatId = 1,
            //    Poster = new CinemaBookingWeb.Models.Poster { Id = 1 }
            //};
            //var controller = new BookingController(srv);
            //var result = controller.BookingConfirm(testConfirmModel) as ViewResult;
            //var res = (ResultViewModel)result.ViewData.Model;
            //Assert.AreEqual("_Result", result.ViewName);
            //Assert.IsNotNull(res);
        }
    }
}
