using System;
using CinemaBookingDto.Models;

namespace CinemaBookingWeb.Models
{
    public class Poster
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public DateTime DateMovie { get; set; }
        public double BasePrice { get; set; }

        public Movie Movie { get; set; }
        public Hall Hall { get; set; }

        public Poster() { }

        public Poster(PlayBill playbill)
        {
            Id = playbill.Id;
            MovieId = playbill.MovieId;
            HallId = playbill.HallId;
            DateMovie = playbill.DateMovie;
            BasePrice = playbill.BasePrice;
        }
    }

    public class GroupedPoster
    {
        public System.Collections.Generic.List<Poster> Films { get; set; }
    }
}