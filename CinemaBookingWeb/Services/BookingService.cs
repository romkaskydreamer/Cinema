using CinemaBookingDto;
using CinemaBookingWeb.Models;
using System.Collections.Generic;
using System.Linq;
using CinemaBookingWeb.Models.Dto;

namespace CinemaBookingWeb.Services
{
    public interface IBookingService
    {
        bool AddBooking(BookingDto boolking);
        bool RemoveBooking(int id);
        bool IsBookingBusy(BookingDto booking);
        IEnumerable<BookingDto> GetAllBookings();
        IEnumerable<SeatDdl> GetFreeSeatsForPlayBill(int playBillId);
        PlayBillDto GetBookingDtoForm(int playBillId);
    }

    public class BookingService : IBookingService
    {
        private readonly IRepository _repo;

        public BookingService(IRepository repo)
        {
            _repo = repo;
        }

        public bool AddBooking(BookingDto booking)
        {
            int res = _repo.AddBooking(booking);
            return res > 0;
        }

        public IEnumerable<BookingDto> GetAllBookings()
        {
            var bookings = _repo.GetAllBookings().ToList();
            var list = new List<BookingDto>();
            bookings.ForEach(x => list.Add(new BookingDto(x)));
            list.ForEach(x => {
                x.Seat = new SeatDto(_repo.FindSeatById(x.SeatId));
                x.PlayBill = new PlayBillDto(_repo.FindPlayBillById(x.PlayBillId));
                x.PlayBill.Movie = new MovieDto(_repo.FindMovieById(x.PlayBill.MovieId));
                x.PlayBill.Hall = new HallDto(_repo.FindHallById(x.PlayBill.HallId));
            });
            return list;
        }

        public IEnumerable<SeatDdl> GetFreeSeatsForPlayBill(int playBillId)
        {
            var playbill = _repo.FindPlayBillById(playBillId);
            var allSeats = _repo.GetSeats().Where(x => x.HallId == playbill.HallId);
            var busySeats = _repo.GetAllBookings().Where(x => x.PlayBillId == playBillId);
            var freeSeats = allSeats.Where(x => !busySeats.Select(y => y.SeatId).Contains(x.Id)).ToList();
            var pricePolicies = _repo.GetPriceCategories();
            var res = new List<SeatDdl>();
            foreach (var s in freeSeats)
            {
                var ddlItem = new SeatDdl(s);
                ddlItem.Price = playbill.BasePrice * pricePolicies.Where(x => x.Id == s.PriceCategoryId).Select(x => x.MultiplierRate).FirstOrDefault();
                res.Add(ddlItem);
            }
            return res;
        }

        public PlayBillDto GetBookingDtoForm(int id)
        {
            var playbill = _repo.FindPlayBillById(id);
            var playBillDto = new PlayBillDto(playbill);
            playBillDto.Movie = new MovieDto(_repo.FindMovieById(playBillDto.MovieId));
            playBillDto.Hall = new HallDto(_repo.FindHallById(playBillDto.HallId));
            return playBillDto;
        }

        public bool IsBookingBusy(BookingDto booking)
        {
            return _repo.IsBookingBusy(booking);
        }

        public bool RemoveBooking(int id)
        {
            return _repo.RemoveBooking(id);
        }

    }
}