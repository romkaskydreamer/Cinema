namespace CinemaBookingWeb.App_Start
{
    public class RepoConfigFactory
    {
        public static CinemaBookingDto.Models.RepoConfig CreateFrom(string path)
        {
            return new CinemaBookingDto.Models.RepoConfig { path = path };
        }
    }
}