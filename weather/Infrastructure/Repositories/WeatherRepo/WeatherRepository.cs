using Models.Entities;

namespace Infrastructure.Repositories.WeatherRepo
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WeatherDbContext _dbContext;
        public WeatherRepository(WeatherDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task Add(Weather weather)
        {
            _dbContext.Weathers.Add(weather);
             
            await this._dbContext.SaveChangesAsync();
        }
    }
}
