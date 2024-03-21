namespace ArchiveOfWeather.Entities
{
    public class WeatherInfo
    {
        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public double Temperature { get; set; }

        public double RelativeHumidity { get; set; }

        public double DewPoint { get; set; }

        public double AtmosphericPressure { get; set; }

        public string WindDirection { get; set; }

        public double WindSpeed { get; set; }

        public double Cloudiness { get; set; }

        public double CloudBase { get; set; }

        public double Visibility { get; set; }

        public string WeatherPhenomena { get; set; }
    }
}
