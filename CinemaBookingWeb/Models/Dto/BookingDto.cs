namespace CinemaBookingWeb.Models.Dto
{
    public class BookingDto : CinemaBookingDto.Models.Booking
    {
        public BookingDto(CinemaBookingDto.Models.Booking booking) : base(booking) { }
        public BookingDto() { }
        public PlayBillDto PlayBill { get; set; }
        public SeatDto Seat { get; set; }
    }
}