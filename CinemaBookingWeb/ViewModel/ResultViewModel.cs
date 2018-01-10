namespace CinemaBookingWeb.ViewModel
{
    public class ResultViewModel
    {
        public string Message { get; set; }

        public ResultViewModel(string message)
        {
            Message = message;
        }
    }
}