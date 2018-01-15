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
    public class MovieControllerTest
    {
        private string pathToTestJsonFiles = @"D:\Projects\Cinema\CinemaBookingWeb\";
        private readonly CinemaBookingData.JsonRepository repo;
        private readonly IMovieService srv;
        public MovieControllerTest()
        {
            repo = new CinemaBookingData.JsonRepository(new RepoConfig { path = pathToTestJsonFiles });
            srv = new MovieService(repo);
        }

        [Test]
        public void ReturnViewNameTest()
        {
            var controller = new MovieController(srv);
            var result = controller.Movie(1) as ViewResult;
            var mov = (MovieViewModel) result.ViewData.Model;
            Assert.AreEqual("Movie", result.ViewName);
            Assert.IsNotNull(mov);
            Assert.AreEqual("Superman", mov.Name);
            Assert.IsNotEmpty(mov.Description);
            Assert.AreEqual("~/Content/img/superman.jpg", mov.Img);
        }
    }
}
