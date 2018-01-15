namespace CinemaBookingDto.Models
{
    public class Hall : IEntity
    {
        public Hall(Hall hall)
        {
            Id = hall.Id;
            Name = hall.Name;
        }

        public Hall() { }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}