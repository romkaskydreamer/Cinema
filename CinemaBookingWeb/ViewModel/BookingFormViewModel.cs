using System.Collections.Generic;
using CinemaBookingWeb.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CinemaBookingWeb.Models.Dto;

namespace CinemaBookingWeb.ViewModel
{
    public class BookingFormViewModel
    {
        public PlayBillDto Poster { get; set; }

        [Required]
        [DisplayName("Please choose your seat")]
        [Range(1, int.MaxValue, ErrorMessage = "Please choose seat number")]
        public int SeatId { get; set; }

        [DisplayName("Please enter your name")]
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 2)]
        public string ClientName { get; set; }

        [DisplayName("Please enter your email")]
        [Required]
        [EmailAddress]
        public string ClientEmail { get; set; }

        public List<SeatDdl> FreeSeats { get; set; }

        public string Errors { get; set; }

        public BookingFormViewModel()
        {
            FreeSeats = new List<SeatDdl>();
        }
    }
}