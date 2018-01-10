namespace CinemaBookingDto.Models
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
    }
}