using ArchiveOfWeather.Entities;
using ArchiveOfWeather.Enums;

namespace ArchiveOfWeather.Models
{
    public class YearlyWeatherStatisticViewModel
    {
        public YearlyWeatherData YearWeatherData { get; set; }

        public ViewType ViewType { get; set; }

        public int SelectedYear { get; set; }

        public int SelectedMonth { get; set; }

        public int FirstYear { get; set; }

        public int LastYear { get; set; }

        public MonthlyWeatherData MonthlyWeatherData { get; set; }

        
    }
}
