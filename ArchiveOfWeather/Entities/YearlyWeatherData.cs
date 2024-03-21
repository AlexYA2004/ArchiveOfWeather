namespace ArchiveOfWeather.Entities
{
    public class YearlyWeatherData
    {
        public int Year { get; set; }

        public List<MonthlyWeatherData> MonthlyData { get; set; }
    }
}
