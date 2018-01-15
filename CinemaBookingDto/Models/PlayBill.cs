using System;

namespace CinemaBookingDto.Models
{
    public class PlayBill : IEntity
    {
        public PlayBill(PlayBill pb)
        {
            Id = pb.Id;
            MovieId = pb.MovieId;
            HallId = pb.HallId;
            DateMovie = pb.DateMovie;
            BasePrice = pb.BasePrice;
        }

        public PlayBill()  { }

        public int Id { get; set; }
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public DateTime DateMovie { get; set; }
        public double BasePrice { get; set; }

        //public virtual Movie Movie { get; set; }
        //public virtual Hall Hall { get; set; }
    }
}