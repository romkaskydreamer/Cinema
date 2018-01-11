using CinemaBookingDto;
using CinemaBookingWeb.ViewModel;

namespace CinemaBookingWeb.Services
{
    public interface IMovieService
    {
        MovieViewModel GetMovieViewModel(int id);
    }

    public class MovieService : IMovieService
    {
        private readonly IRepository _repo;

        public MovieService(IRepository repo)
        {
            _repo = repo;
        }

        public MovieViewModel GetMovieViewModel(int id)
        {
            var movie = _repo.FindMovieById(id);
            var model = new MovieViewModel
            {
                Description = movie.Description,
                Name = movie.Name,
                Img = movie.Img
            };
            return model;
        }

    }
}