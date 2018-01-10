using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using CinemaBookingDto;
using CinemaBookingDto.Models;
using Newtonsoft.Json;

namespace CinemaBookingWeb.Controllers
{
    public class TestController : Controller
    {
        private readonly IRepository _repo;

        public TestController(IRepository repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Go()
        {
            var halls = new List<Hall>();
            halls.Add(new Hall { Id = 1, Name = "Red" });
            halls.Add(new Hall { Id = 2, Name = "Yellow" });
            halls.Add(new Hall { Id = 3, Name = "Green" });

            var movies = new List<Movie>();
            movies.Add(new Movie { Id = 1, Name = "Superman", Description = "sdakjfsjkdf hkjasdhfgjkasjk dgjkhadgjk" , Img = "~/Content/img/superman.jpg" });
            movies.Add(new Movie { Id = 2, Name = "James Bond", Description = "sdakjfsjkdf hkjasdhfgjkasjk dgjkhadgjk", Img = "~/Content/img/skyfall.jpg" });
            movies.Add(new Movie { Id = 3, Name = "Back To The Future", Description = "sdakjfsjkdf hkjasdhfgjkasjk dgjkhadgjk sdf", Img = "~/Content/img/btf.jpg" });
            movies.Add(new Movie { Id = 4, Name = "Baby Driver", Description = "sdakjfsjkdf hkjasdhfgjkasjk dgjkhadgjk sdf", Img = "~/Content/img/babydriver.jpg" });
            movies.Add(new Movie { Id = 5, Name = "Star Wars", Description = "sdakjfsjkdf hkjasdhfgjkasjk dgjkhadgjk qefs", Img = "~/Content/img/looper.jpg" });
            movies.Add(new Movie { Id = 6, Name = "Spiderman", Description = "sdakjfsjkdf hkjasdhfgjkasjk dgjkhadgjk qwqw", Img = "~/Content/img/spider.jpg" });

            var priceCtaegoriesd = new List<PriceCategory>();
            priceCtaegoriesd.Add(new PriceCategory { Id = 1, Name = "Low", MultiplierRate = 1 });
            priceCtaegoriesd.Add(new PriceCategory { Id = 2, Name = "Middle", MultiplierRate = 1.2 });
            priceCtaegoriesd.Add(new PriceCategory { Id = 3, Name = "High", MultiplierRate = 1.5 });

            var seats = new List<Seat>();
            //hall1 
            seats.Add(new Seat { Id = 1, HallId = 1, PriceCategoryId = 1, RowNum = 1, SeatNum = 1 });
            seats.Add(new Seat { Id = 2, HallId = 1, PriceCategoryId = 1, RowNum = 1, SeatNum = 2 });
            seats.Add(new Seat { Id = 3, HallId = 1, PriceCategoryId = 1, RowNum = 1, SeatNum = 3 });
            seats.Add(new Seat { Id = 4, HallId = 1, PriceCategoryId = 1, RowNum = 1, SeatNum = 4 });
            seats.Add(new Seat { Id = 5, HallId = 1, PriceCategoryId = 1, RowNum = 1, SeatNum = 5 });
            seats.Add(new Seat { Id = 6, HallId = 1, PriceCategoryId = 2, RowNum = 2, SeatNum = 6 });
            seats.Add(new Seat { Id = 7, HallId = 1, PriceCategoryId = 2, RowNum = 2, SeatNum = 7 });
            seats.Add(new Seat { Id = 8, HallId = 1, PriceCategoryId = 2, RowNum = 2, SeatNum = 8 });
            seats.Add(new Seat { Id = 9, HallId = 1, PriceCategoryId = 2, RowNum = 2, SeatNum = 9 });
            seats.Add(new Seat { Id = 10, HallId = 1, PriceCategoryId = 2, RowNum = 2, SeatNum = 10 });
            seats.Add(new Seat { Id = 11, HallId = 1, PriceCategoryId = 3, RowNum = 3, SeatNum = 11 });
            seats.Add(new Seat { Id = 12, HallId = 1, PriceCategoryId = 3, RowNum = 3, SeatNum = 12 });
            //hall2
            seats.Add(new Seat { Id = 13, HallId = 2, PriceCategoryId = 1, RowNum = 1, SeatNum = 1 });
            seats.Add(new Seat { Id = 14, HallId = 2, PriceCategoryId = 1, RowNum = 1, SeatNum = 2 });
            seats.Add(new Seat { Id = 15, HallId = 2, PriceCategoryId = 1, RowNum = 1, SeatNum = 3 });
            seats.Add(new Seat { Id = 16, HallId = 2, PriceCategoryId = 1, RowNum = 1, SeatNum = 4 });
            seats.Add(new Seat { Id = 17, HallId = 2, PriceCategoryId = 2, RowNum = 2, SeatNum = 5 });
            seats.Add(new Seat { Id = 18, HallId = 2, PriceCategoryId = 2, RowNum = 2, SeatNum = 6 });
            seats.Add(new Seat { Id = 19, HallId = 2, PriceCategoryId = 2, RowNum = 2, SeatNum = 7 });
            seats.Add(new Seat { Id = 20, HallId = 2, PriceCategoryId = 2, RowNum = 2, SeatNum = 8 });
            seats.Add(new Seat { Id = 21, HallId = 2, PriceCategoryId = 3, RowNum = 3, SeatNum = 9 });
            seats.Add(new Seat { Id = 22, HallId = 2, PriceCategoryId = 3, RowNum = 3, SeatNum = 10 });
            seats.Add(new Seat { Id = 23, HallId = 2, PriceCategoryId = 3, RowNum = 3, SeatNum = 11 });
            seats.Add(new Seat { Id = 24, HallId = 2, PriceCategoryId = 3, RowNum = 3, SeatNum = 12 });
            //hall3
            seats.Add(new Seat { Id = 25, HallId = 3, PriceCategoryId = 1, RowNum = 1, SeatNum = 1 });
            seats.Add(new Seat { Id = 26, HallId = 3, PriceCategoryId = 1, RowNum = 1, SeatNum = 2 });
            seats.Add(new Seat { Id = 27, HallId = 3, PriceCategoryId = 1, RowNum = 1, SeatNum = 3 });
            seats.Add(new Seat { Id = 28, HallId = 3, PriceCategoryId = 1, RowNum = 1, SeatNum = 4 });
            seats.Add(new Seat { Id = 29, HallId = 3, PriceCategoryId = 1, RowNum = 1, SeatNum = 5 });
            seats.Add(new Seat { Id = 30, HallId = 3, PriceCategoryId = 1, RowNum = 1, SeatNum = 6 });
            seats.Add(new Seat { Id = 31, HallId = 3, PriceCategoryId = 2, RowNum = 2, SeatNum = 7 });
            seats.Add(new Seat { Id = 32, HallId = 3, PriceCategoryId = 2, RowNum = 2, SeatNum = 8 });
            seats.Add(new Seat { Id = 33, HallId = 3, PriceCategoryId = 2, RowNum = 2, SeatNum = 9 });
            seats.Add(new Seat { Id = 34, HallId = 3, PriceCategoryId = 2, RowNum = 2, SeatNum = 10 });
            seats.Add(new Seat { Id = 35, HallId = 3, PriceCategoryId = 3, RowNum = 3, SeatNum = 11 });
            seats.Add(new Seat { Id = 36, HallId = 3, PriceCategoryId = 3, RowNum = 3, SeatNum = 12 });

            var playbill = new List<PlayBill>();
            playbill.Add(new PlayBill { Id = 1, HallId = 1, MovieId = 1, BasePrice = 55, DateMovie = new DateTime(2018, 2, 15, 1, 2, 0) });
            playbill.Add(new PlayBill { Id = 2, HallId = 2, MovieId = 1, BasePrice = 55, DateMovie = new DateTime(2018, 2, 15, 1, 2, 0) });
            playbill.Add(new PlayBill { Id = 3, HallId = 3, MovieId = 1, BasePrice = 55, DateMovie = new DateTime(2018, 2, 15, 1, 2, 0) });
            playbill.Add(new PlayBill { Id = 4, HallId = 1, MovieId = 2, BasePrice = 155, DateMovie = new DateTime(2018, 2, 16, 1, 2, 0) });
            playbill.Add(new PlayBill { Id = 5, HallId = 2, MovieId = 2, BasePrice = 200, DateMovie = new DateTime(2018, 2, 16, 1, 2, 0) });
            playbill.Add(new PlayBill { Id = 6, HallId = 3, MovieId = 2, BasePrice = 100, DateMovie = new DateTime(2018, 2, 16, 1, 2, 0) });
            playbill.Add(new PlayBill { Id = 7, HallId = 1, MovieId = 3, BasePrice = 12, DateMovie = new DateTime(2018, 2, 17, 1, 2, 0) });
            playbill.Add(new PlayBill { Id = 8, HallId = 3, MovieId = 3, BasePrice = 123, DateMovie = new DateTime(2018, 2, 18, 1, 2, 0) });
            playbill.Add(new PlayBill { Id = 9, HallId = 1, MovieId = 4, BasePrice = 234, DateMovie = new DateTime(2018, 2, 15, 1, 2, 0) });
            playbill.Add(new PlayBill { Id = 10, HallId = 1, MovieId = 5, BasePrice = 456, DateMovie = new DateTime(2018, 2, 15, 1, 2, 0) });
            playbill.Add(new PlayBill { Id = 11, HallId = 2, MovieId = 6, BasePrice = 678, DateMovie = new DateTime(2018, 2, 15, 1, 2, 0) });
            playbill.Add(new PlayBill { Id = 12, HallId = 3, MovieId = 6, BasePrice = 89, DateMovie = new DateTime(2018, 2, 15, 1, 2, 0) });

            var targetDir = "/App_Data/Data";
            if (!Directory.Exists(HostingEnvironment.MapPath(targetDir)))
            {
                Directory.CreateDirectory(HostingEnvironment.MapPath(targetDir));
            }

            var hallsJson = JsonConvert.SerializeObject(halls);
            var hallsPath = HostingEnvironment.MapPath(Path.Combine(HostingEnvironment.MapPath(targetDir), $"/Hall.json"));
            System.IO.File.WriteAllText(hallsPath, hallsJson, Encoding.UTF8);

            var moviesJson = JsonConvert.SerializeObject(movies);
            var moviesPath = HostingEnvironment.MapPath(Path.Combine(HostingEnvironment.MapPath(targetDir), $"/Movie.json"));
            System.IO.File.WriteAllText(moviesPath, moviesJson, Encoding.UTF8);

            var pricecatJson = JsonConvert.SerializeObject(priceCtaegoriesd);
            var prPath = HostingEnvironment.MapPath(Path.Combine(HostingEnvironment.MapPath(targetDir), $"/PriceCategory.json"));
            System.IO.File.WriteAllText(prPath, pricecatJson, Encoding.UTF8);

            var seatsson = JsonConvert.SerializeObject(seats);
            var seaPath = HostingEnvironment.MapPath(Path.Combine(HostingEnvironment.MapPath(targetDir), $"/Seat.json"));
            System.IO.File.WriteAllText(seaPath, seatsson, Encoding.UTF8);

            var playBillJson = JsonConvert.SerializeObject(playbill);
            var playBilPath = HostingEnvironment.MapPath(Path.Combine(HostingEnvironment.MapPath(targetDir), $"/PlayBill.json"));
            System.IO.File.WriteAllText(playBilPath, playBillJson, Encoding.UTF8);

            //var bookJson = JsonConvert.SerializeObject(booki);
            //var bookPath = HostingEnvironment.MapPath(Path.Combine(HostingEnvironment.MapPath(targetDir), $"/Booking.json"));
            //System.IO.File.WriteAllText(bookPath, bookJson, Encoding.UTF8);
            return null;
        }


    }
}