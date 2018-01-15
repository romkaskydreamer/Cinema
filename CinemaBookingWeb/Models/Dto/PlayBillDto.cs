using CinemaBookingDto.Models;

namespace CinemaBookingWeb.Models.Dto
{
    public class PlayBillDto : PlayBill
    {
        public MovieDto Movie { get; set; }
        public HallDto Hall { get; set; }

        public PlayBillDto() { }
        public PlayBillDto(PlayBill pb) : base(pb) { }
    }
}