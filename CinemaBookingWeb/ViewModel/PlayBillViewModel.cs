using System.Collections.Generic;
using CinemaBookingWeb.Models.Dto;

namespace CinemaBookingWeb.ViewModel
{
    public class PlayBillViewModel
    {
        public IList<PlayBillDto> Posters { get; set; }

        public PlayBillViewModel()
        {
            Posters = new List<PlayBillDto>();
        }
    }
}