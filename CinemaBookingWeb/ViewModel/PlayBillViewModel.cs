using CinemaBookingWeb.Models;
using System.Collections.Generic;
using System.Linq;
using CinemaBookingDto.Models;

namespace CinemaBookingWeb.ViewModel
{
    public class PlayBillViewModel
    {
        //public List<GroupedPoster> GroupedPosters { get; set; }
        public List<Poster> Posters { get; set; }

        public PlayBillViewModel()
        {
            Posters = new List<Poster>();
        }

        public PlayBillViewModel(IEnumerable<PlayBill> movies)
        {
            Posters = movies.Select(x => new Poster
            {
                BasePrice = x.BasePrice,
                DateMovie = x.DateMovie,
                HallId = x.HallId,
                Id = x.Id,
                MovieId = x.MovieId
            }).ToList();
        }
    }
}