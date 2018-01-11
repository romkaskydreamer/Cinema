using System.Linq;
using CinemaBookingDto;
using NUnit.Framework;

namespace CinemaBookingWebTests
{
    class RepositoryHelper
    {
        private readonly IRepository repo;

        public RepositoryHelper(IRepository rpo)
        {
            repo = rpo;
        }

        private int hallsCount =  3;
        private int pricecategoryCount = 3;
        private int moviesCount =  6;

        public void CheckHallsCount()
        {
            var data = repo.GetHalls();
            Assert.AreEqual(hallsCount, data.Count());
        }

        public void CheckMoviesCount()
        {
            var data = repo.GetMovies();
            Assert.AreEqual(moviesCount, data.Count());
        }

        public void CheckPricesCategoryCount()
        {
            var data = repo.GetPriceCategories();
            Assert.AreEqual(pricecategoryCount, data.Count());
        }

    }

}

