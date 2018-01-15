using CinemaBookingDto.Models;

namespace CinemaBookingWeb.Models.Dto
{
    public class MovieDto : Movie
    {
        public MovieDto(Movie mov) : base(mov) { }
    }
}