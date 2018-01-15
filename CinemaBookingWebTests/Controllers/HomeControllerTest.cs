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
    public class HomeControllerTest
    {
        private string pathToTestJsonFiles = @"D:\Projects\Cinema\CinemaBookingWeb\";
        private readonly CinemaBookingData.JsonRepository repo;
        private readonly IPlayBillService srv;
        public HomeControllerTest()
        {
            repo = new CinemaBookingData.JsonRepository(new RepoConfig { path = pathToTestJsonFiles });
            srv = new PlayBillService(repo);
        }

        [Test]
        public void ReturnViewNameTest()
        {
            var controller = new HomeController(srv);
            var result = controller.Index() as ViewResult;
            var pb = (PlayBillViewModel)result.ViewData.Model;
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(pb.Posters);
        }

    }
}
