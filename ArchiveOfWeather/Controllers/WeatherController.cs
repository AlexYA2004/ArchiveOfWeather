using ArchiveOfWeather.Enums;
using ArchiveOfWeather.Models;
using ArchiveOfWeather.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArchiveOfWeather.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherService _weatherService;

        private ILogger<WeatherController> _logger;

        public WeatherController(IWeatherService weatherService, ILogger<WeatherController> logger) 
        {
            _weatherService = weatherService;

            _logger = logger;
        }


        public async Task<IActionResult> WeatherStatistic(string viewType, int year, int month)
        {
            try
            {
                var model = new YearlyWeatherStatisticViewModel();

                var yearToFind = year == 0 ? 2010 : year;

                var monthToFind = month == 0 ? 1 : month;

                var allData = await _weatherService.GetYearlyWeatherData();

                model.YearWeatherData = allData.FirstOrDefault(d => d.Year == yearToFind);

                model.ViewType = viewType == "monthly" ? ViewType.Monthly : ViewType.Yearly;

                model.MonthlyWeatherData = model.YearWeatherData.MonthlyData.FirstOrDefault(m => m.Month == monthToFind);

                model.SelectedYear = yearToFind;

                model.SelectedMonth = monthToFind;

                model.FirstYear = allData.First().Year;

                model.LastYear = allData.Last().Year;

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while loading data");

                return RedirectToAction("StatisticError", "Home");
            }
        }

        public IActionResult UploadWeatherStatistic() => View();

        public async Task<IActionResult> UploadExcelFiles()
        {
            try
            {
                var files = Request.Form.Files;

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        await _weatherService.UploadExcelFilesAsync(file.OpenReadStream());
                    }
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while uploading Excel files");

                return RedirectToAction("Error", "Home");
            }
        }
    }
}
