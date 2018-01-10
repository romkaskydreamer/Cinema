namespace CinemaBookingDto.Models
{
    public class PriceCategory : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MultiplierRate { get; set; }
    }
}