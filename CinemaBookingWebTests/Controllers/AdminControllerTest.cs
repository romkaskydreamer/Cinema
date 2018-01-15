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
    public class AdminControllerTest
    {
        private string pathToTestJsonFiles = @"D:\Projects\Cinema\CinemaBookingWeb\";
        private readonly CinemaBookingData.JsonRepository repo;
        private readonly IBookingService srv;
        public AdminControllerTest()
        {
            repo = new CinemaBookingData.JsonRepository(new RepoConfig { path = pathToTestJsonFiles });
            srv = new BookingService(repo);
        }

        [Test]
        public void BookingFormTest()
        {
            var controller = new AdminController(srv);
            var result = controller.Admin() as ViewResult;
            //var bf = (BookingListViewModel)result.ViewData.Model;
            Assert.AreEqual("Admin", result.ViewName);
        }

    }
}
