using ArchiveOfWeather.Entities;

namespace ArchiveOfWeather.Services.Interfaces
{
    public interface IWeatherService
    {
        Task UploadExcelFilesAsync(Stream fileStream);

        Task<List<YearlyWeatherData>> GetYearlyWeatherData();
    }
}
