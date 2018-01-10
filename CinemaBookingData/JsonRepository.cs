using System;
using System.Collections.Generic;
using CinemaBookingDto;
using CinemaBookingDto.Models;
using Newtonsoft.Json;
using System.Linq;

namespace CinemaBookingData
{
    public class JsonRepository : IRepository
    {
        private readonly string path = @"D:\Projects\Cinema\CinemaBookingWeb";

        public Booking FindBookingById(int id)
        {
            var objs = GetAllBookings();
            var obj = objs.ToList().FirstOrDefault(x => x.Id == id);
            return obj;
        }

        public Hall FindHallById(int id)
        {
            var objs = GetHalls();
            var obj = objs.ToList().FirstOrDefault(x => x.Id == id);
            return obj;
        }

        public Movie FindMovieById(int id)
        {
            var objs = GetMovies();
            var obj = objs.ToList().FirstOrDefault(x => x.Id == id);
            return obj;
        }

        public PlayBill FindPlayBillById(int id)
        {
            var objs = GetPlayBill();
            var obj = objs.ToList().FirstOrDefault(x => x.Id == id);
            return obj;
        }

        public PriceCategory FindPriceCategoryById(int id)
        {
            var objs = GetPriceCategories();
            var obj = objs.ToList().FirstOrDefault(x => x.Id == id);
            return obj;
        }

        public Seat FindSeatById(int id)
        {
            var objs = GetSeats();
            var obj = objs.ToList().FirstOrDefault(x => x.Id == id);
            return obj;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            var objs = GetList<Booking>("Booking.json");
            return objs;
        }

        public IEnumerable<Hall> GetHalls()
        {
            var objs = GetList<Hall>("Hall.json");
            return objs;
        }

        public IEnumerable<Movie> GetMovies()
        {
            var objs = GetList<Movie>("Movie.json");
            return objs;
        }

        public IEnumerable<PlayBill> GetPlayBill()
        {
            var objs = GetList<PlayBill>("PlayBill.json");
            return objs;
        }

        public IEnumerable<PriceCategory> GetPriceCategories()
        {
            var objs = GetList<PriceCategory>("PriceCategory.json");
            return objs;
        }

        public IEnumerable<Seat> GetSeats()
        {
            var objs = GetList<Seat>("Seat.json");
            return objs;
        }

        public bool RemoveBooking(int bookingId)
        {
            try
            {
                var allBookings = GetAllBookings().ToList();
                allBookings.Remove(allBookings.FirstOrDefault(i => i.Id == bookingId));
                System.IO.File.WriteAllText(System.IO.Path.Combine($@"{path}/Booking.json"), 
                    JsonConvert.SerializeObject(allBookings), System.Text.Encoding.UTF8);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int AddBooking(Booking booking)
        {
            try {
                var allBookings = GetAllBookings().ToList();
                var nextId = allBookings.Count == 0 ? 1 : (allBookings.Max(x => x.Id)) + 1;
                booking.Id = nextId;
                allBookings.Add(booking);
                System.IO.File.WriteAllText(System.IO.Path.Combine($@"{path}/Booking.json"), JsonConvert.SerializeObject(allBookings), System.Text.Encoding.UTF8);
                return nextId;
            } catch (Exception) {
                return 0;
            }
        }

        private IEnumerable<T> GetList<T>(string fileName)
        {
            var fPath = System.IO.Path.Combine($@"{path}/{fileName}");
            var text = System.IO.File.ReadAllText(fPath);
            var objs = JsonConvert.DeserializeObject<IEnumerable<T>>(text);
            return objs ?? new List<T>();
        }

    }
}
