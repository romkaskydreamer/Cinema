using CinemaBookingDto;
using Moq;
using NUnit.Framework;

namespace CinemaBookingWebTests
{
    [TestFixture]
    class JsonRepositoryTests
    {
        private readonly IRepository repo;
        private readonly string pathToTestJsonFiles = @"D:\Projects\Cinema\CinemaBookingWeb\";
        private RepositoryHelper helper;

        public JsonRepositoryTests()
        {
            repo = new CinemaBookingData.JsonRepository(new RepoConfig { path = pathToTestJsonFiles });
            helper = new RepositoryHelper(repo);
        }

        [Test]
        public void CheckHallsCount()
        {
            helper.CheckHallsCount();
        }

        [Test]
        public void CheckMoviesCount()
        {
            helper.CheckMoviesCount();
        }

        [Test]
        public void CheckPricesCategoryCount()
        {
            helper.CheckPricesCategoryCount();
        }

    }
}
