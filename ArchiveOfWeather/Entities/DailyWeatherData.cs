namespace ArchiveOfWeather.Entities
{
    public class DailyWeatherData
    {
        public DateTime Date { get; set; }

        public double Temperature { get; set; }

        public double WindSpeed { get; set; }

        public double AtmosphericPressure { get; set; }
    }
}
