using System;
using System.Collections.Generic;
using System.Linq;
using CinemaBookingDto;
using CinemaBookingWeb.Models.Dto;

namespace CinemaBookingWeb.Services
{
    public interface IPlayBillService
    {
        IList<PlayBillDto> GetTodayPlayBill();
    }

    public class PlayBillService : IPlayBillService
    {
        private readonly IRepository _repo;
        public PlayBillService(IRepository repo)
        {
            _repo = repo;
        }

        public IList<PlayBillDto> GetTodayPlayBill()
        {
            var playBill = _repo.GetPlayBill().Where(x => x.DateMovie >= DateTime.Now).ToList();
            var list = new List<PlayBillDto>();
            playBill.ForEach(x => list.Add(new PlayBillDto(x)));
            list.ForEach(x => {
                x.Movie = new MovieDto(_repo.FindMovieById(x.MovieId));
                x.Hall = new HallDto(_repo.FindHallById(x.HallId)); });
            return list;
        }
    }
}