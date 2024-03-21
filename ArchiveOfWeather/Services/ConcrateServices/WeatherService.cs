using ArchiveOfWeather.DAL.Interfaces;
using ArchiveOfWeather.DAL.Repositories;
using ArchiveOfWeather.Entities;
using ArchiveOfWeather.Services.Interfaces;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ArchiveOfWeather.Services.ConcrateServices
{
    public class WeatherService : IWeatherService
    {
        private IBaseRepository<WeatherInfo> _weatherRepository;

        public WeatherService(IBaseRepository<WeatherInfo> weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }



        public async Task UploadExcelFilesAsync(Stream fileStream)
        {
            var workbook = new XSSFWorkbook(fileStream);

            for (int sheetIndex = 0; sheetIndex < workbook.NumberOfSheets; sheetIndex++)
            {
                var sheet = workbook.GetSheetAt(sheetIndex);

                for (int i = 4; i <= sheet.LastRowNum; i++)
                {
                    var row = sheet.GetRow(i);

                    if (row != null)
                    {
                        var weatherInfo = new WeatherInfo();

                        weatherInfo.Date = DateTime.Parse(row.GetCell(0).StringCellValue);

                        weatherInfo.Time = TimeSpan.Parse(row.GetCell(1).StringCellValue);

                        weatherInfo.Temperature = row.GetCell(2)?.CellType == CellType.Numeric ? row.GetCell(2).NumericCellValue : 0.0;

                        weatherInfo.RelativeHumidity = row.GetCell(3)?.CellType == CellType.Numeric ? row.GetCell(3).NumericCellValue : 0.0;

                        weatherInfo.DewPoint = row.GetCell(4)?.CellType == CellType.Numeric ? row.GetCell(4).NumericCellValue : 0.0;

                        weatherInfo.AtmosphericPressure = row.GetCell(5)?.CellType == CellType.Numeric ? row.GetCell(5).NumericCellValue : 0.0;

                        weatherInfo.WindDirection = row.GetCell(6)?.StringCellValue ?? "Нет данных";

                        weatherInfo.WindSpeed = row.GetCell(7)?.CellType == CellType.Numeric ? row.GetCell(7).NumericCellValue : 0.0;

                        weatherInfo.Cloudiness = row.GetCell(8)?.CellType == CellType.Numeric ? row.GetCell(8).NumericCellValue : 0.0;

                        weatherInfo.CloudBase = row.GetCell(9)?.CellType == CellType.Numeric ? row.GetCell(9).NumericCellValue : 0.0;

                        weatherInfo.Visibility = row.GetCell(10)?.CellType == CellType.Numeric ? row.GetCell(10).NumericCellValue : 0.0;

                        weatherInfo.WeatherPhenomena = row.GetCell(11)?.StringCellValue ?? "Нет данных";
                        
                        await _weatherRepository.CreateAsync(weatherInfo);
                    }
                }
            }
        }

        public async Task<List<YearlyWeatherData>> GetYearlyWeatherData()
        {
            var yearlyData = _weatherRepository.GetAll()
           .GroupBy(w => w.Date.Year) 
           .Select(g => new YearlyWeatherData
           {
               Year = g.Key,
               MonthlyData = g.GroupBy(w => w.Date.Month) 
                                .Select(m => new MonthlyWeatherData
                                {
                                    Month = m.Key,
                                    DailyData = m.GroupBy(w => w.Date.Day) 
                                                 .Select(d => new DailyWeatherData
                                                 {
                                                     Date = d.First().Date,
                                                     Temperature = d.Average(w => w.Temperature),
                                                     WindSpeed = d.Average(w => w.WindSpeed),
                                                     AtmosphericPressure = d.Average(w => w.AtmosphericPressure)
                                                 })
                                                 .ToList()
                                })
                                .ToList()
           })
           .ToList();

            return yearlyData;
        }
    }
    
}
