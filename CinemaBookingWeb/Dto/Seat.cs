namespace CinemaBookingWeb.Dto
{
    public class Seat
    {
        public int Id { get; set; }
        public int HallId { get; set; }
        public int RowNum { get; set; }
        public int SeatNum { get; set; }
        public int PriceCategoryId { get; set; }

        public virtual Hall Hall { get; set; }
        public virtual PriceCategory PriceCategory { get; set; }
    }
}