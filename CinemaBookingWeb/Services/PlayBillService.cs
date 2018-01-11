using System;
using System.Linq;
using CinemaBookingDto;
using CinemaBookingWeb.ViewModel;

namespace CinemaBookingWeb.Services
{
    public interface IPlayBillService
    {
        PlayBillViewModel GetPlayBillViewModel();
    }

    public class PlayBillService : IPlayBillService
    {
        private readonly IRepository _repo;

        public PlayBillService(IRepository repo)
        {
            _repo = repo;
        }

        public PlayBillViewModel GetPlayBillViewModel()
        {
            var playBill = _repo.GetPlayBill().Where(x => x.DateMovie >= DateTime.Now);
            var model = new PlayBillViewModel(playBill);
            model.Posters.ForEach(poster =>
            {
                poster.Movie = _repo.FindMovieById(poster.MovieId);
                poster.Hall = _repo.FindHallById(poster.HallId);
            });
            return model;
        }
    }
}