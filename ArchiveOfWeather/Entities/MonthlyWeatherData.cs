namespace ArchiveOfWeather.Entities
{
    public class MonthlyWeatherData
    {
        public int Month { get; set; }

        public List<DailyWeatherData> DailyData { get; set; }
    }
}
