using System;

namespace CinemaBookingWeb.Dto
{
    public class BookingDto
    {
        public int Id { get; set; }

        public int PlayBillId { get; set; }
        public int SeatId { get; set; }

        public string ClientName { get; set; }
        public string ClientEmail { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual PlayBill PlayBill { get; set; }
        public virtual Seat Seat { get; set; }
    }
}