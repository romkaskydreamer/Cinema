namespace CinemaBookingDto.Models
{
    public class PriceCategory : IEntity
    {
        public PriceCategory(PriceCategory c)
        {
            Id = c.Id;
            Name = c.Name;
            MultiplierRate = c.MultiplierRate;
        }

        public PriceCategory() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public double MultiplierRate { get; set; }
    }
}