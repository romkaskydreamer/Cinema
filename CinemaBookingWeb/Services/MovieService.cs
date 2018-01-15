using CinemaBookingDto;
using CinemaBookingWeb.Models.Dto;

namespace CinemaBookingWeb.Services
{
    public interface IMovieService
    {
        MovieDto GetMovieById(int id);
    }

    public class MovieService : IMovieService
    {
        private readonly IRepository _repo;
        public MovieService(IRepository repo)
        {
            _repo = repo;
        }

        public MovieDto GetMovieById(int id)
        {
            var movie = _repo.FindMovieById(id);
            return new MovieDto(movie);
        }

    }
}