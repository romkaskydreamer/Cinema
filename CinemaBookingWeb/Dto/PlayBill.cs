using System;

namespace CinemaBookingWeb.Dto
{
    public class PlayBill
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public DateTime DateMovie { get; set; }
        public double BasePrice { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Hall Hall { get; set; }
    }
}