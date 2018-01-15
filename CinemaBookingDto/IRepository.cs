using CinemaBookingDto.Models;
using System.Collections.Generic;

namespace CinemaBookingDto
{
    public interface IRepository//<T> where T : IEntity
    {
        IEnumerable<Booking> GetAllBookings();
        IEnumerable<PlayBill> GetPlayBill();
        IEnumerable<Movie> GetMovies();
        IEnumerable<Hall> GetHalls();
        IEnumerable<PriceCategory> GetPriceCategories();
        IEnumerable<Seat> GetSeats();

        Booking FindBookingById(int id);
        Seat FindSeatById(int id);
        PlayBill FindPlayBillById(int id);
        PriceCategory FindPriceCategoryById(int id);
        Movie FindMovieById(int id);
        Hall FindHallById(int id);

        int AddBooking(Booking booking);
        bool RemoveBooking(int bookingId);
        bool IsBookingBusy(Booking booking);
        //void Delete(T entity);
        //T FindById(int Id);
    }
}
