using CinemaBookingDto.Models;

namespace CinemaBookingWeb.Models.Dto
{
    public class SeatDto : Seat
    {
        public HallDto Hall { get; set; }
        public PriceCategoryDto PriceCategory { get; set; }

        public SeatDto(Seat seat) : base(seat) { }

    }

}