using ArchiveOfWeather.DAL.Interfaces;
using ArchiveOfWeather.Entities;

namespace ArchiveOfWeather.DAL.Repositories
{
    public class WeatherInfoRepository : IBaseRepository<WeatherInfo>
    {
        private AppDbContext _dbContext;

        public WeatherInfoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(WeatherInfo entity)
        {
            await _dbContext.WeatherInfo.AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(WeatherInfo entity)
        {
            _dbContext.WeatherInfo.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<WeatherInfo> GetAll()
        {
            return _dbContext.WeatherInfo.AsQueryable();
        }

        public async Task UpdateAsync(WeatherInfo entity)
        {
            _dbContext.WeatherInfo.Update(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
