namespace CinemaBookingDto.Models
{
    public class Movie : IEntity
    {
        public Movie(Movie mov)
        {
            Id = mov.Id;
            Name = mov.Name;
            Description = mov.Description;
            Img = mov.Img;
        }

        public Movie() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
    }
}