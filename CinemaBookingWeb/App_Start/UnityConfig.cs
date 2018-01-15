using CinemaBookingData;
using CinemaBookingDto;
using CinemaBookingWeb.Services;
using System;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace CinemaBookingWeb
{

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            string jsonFilesPath = AppDomain.CurrentDomain.BaseDirectory;

            var conf = App_Start.RepoConfigFactory.CreateFrom(jsonFilesPath);
                    
            container.RegisterInstance(typeof(RepoConfig), conf) ;

            container.RegisterType<IRepository, JsonRepository>();

            container.RegisterType<IPlayBillService, PlayBillService>();
            container.RegisterType<IBookingService, BookingService>();
            container.RegisterType<IMovieService, MovieService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}