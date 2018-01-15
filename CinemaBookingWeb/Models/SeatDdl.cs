using CinemaBookingDto.Models;

namespace CinemaBookingWeb.Models
{
    public class SeatDdl
    {
        public int Id { get; set; }
        public int HallId { get; set; }
        public int RowNum { get; set; }
        public int SeatNum { get; set; }
        public double Price { get; set; }
        public string Summary { get { return $"Row: {RowNum}, Seat: {SeatNum}, Price: {Price}"; } set { Summary = value; } }

        public SeatDdl(Seat seat)
        {
            Id = seat.Id;
            HallId = seat.HallId;
            RowNum = seat.RowNum;
            SeatNum = seat.SeatNum;
            Price = 0;
        }
        //public virtual Hall Hall { get; set; }
        //public virtual PriceCategory PriceCategory { get; set; }
    }
}