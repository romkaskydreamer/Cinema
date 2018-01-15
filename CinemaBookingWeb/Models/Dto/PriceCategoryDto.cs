using CinemaBookingDto.Models;

namespace CinemaBookingWeb.Models.Dto
{
    public class PriceCategoryDto : PriceCategory
    {
        public PriceCategoryDto(PriceCategory c) : base(c) { }
    }
}