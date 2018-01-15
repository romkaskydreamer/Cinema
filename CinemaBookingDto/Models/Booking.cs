using System;

namespace CinemaBookingDto.Models
{
    public class Booking : IEntity
    {
        public Booking() { }
        public Booking(Booking booking)
        {
            Id = booking.Id;
            PlayBillId = booking.PlayBillId;
            SeatId = booking.SeatId;
            ClientEmail = booking.ClientEmail;
            ClientName = booking.ClientName;
            DateCreated = booking.DateCreated;
        }

        public int Id { get; set; }

        public int PlayBillId { get; set; }
        public int SeatId { get; set; }

        public string ClientName { get; set; }
        public string ClientEmail { get; set; }

        public DateTime DateCreated { get; set; }

        //public virtual PlayBill PlayBill { get; set; }
        //public virtual Seat Seat { get; set; }
        
    }
}