using ArchiveOfWeather.DAL.Interfaces;
using ArchiveOfWeather.DAL.Repositories;
using ArchiveOfWeather.Entities;
using ArchiveOfWeather.Services.ConcrateServices;
using ArchiveOfWeather.Services.Interfaces;

namespace ArchiveOfWeather
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<WeatherInfo>, WeatherInfoRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherService, WeatherService>();
        }
    }
}
