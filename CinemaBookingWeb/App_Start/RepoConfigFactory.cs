namespace CinemaBookingWeb.App_Start
{
    public class RepoConfigFactory
    {
        public static CinemaBookingDto.RepoConfig CreateFrom(string path)
        {
            return new CinemaBookingDto.RepoConfig { path = path };
        }
    }
}