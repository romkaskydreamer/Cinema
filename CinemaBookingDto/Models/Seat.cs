namespace CinemaBookingDto.Models
{
    public class Seat : IEntity
    {
        public Seat(Seat seat)
        {
            Id = seat.Id;
            HallId = seat.HallId;
            RowNum = seat.RowNum;
            SeatNum = seat.SeatNum;
            PriceCategoryId = seat.PriceCategoryId;
        }

        public Seat() { }

        public int Id { get; set; }
        public int HallId { get; set; }
        public int RowNum { get; set; }
        public int SeatNum { get; set; }
        public int PriceCategoryId { get; set; }

        //public virtual Hall Hall { get; set; }
        //public virtual PriceCategory PriceCategory { get; set; }
    }
}