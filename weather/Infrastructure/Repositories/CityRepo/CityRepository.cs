using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Infrastructure.Repositories.CityRepo
{
    public class CityRepository : ICityRepository
    {
        private readonly WeatherDbContext _dbContext;
        public CityRepository(WeatherDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<City> GetByName(string cityName) 
        => await _dbContext.Cities.Where(x=>x.CityName==cityName).FirstOrDefaultAsync(); 

        public async Task Add(City city)
        {
            _dbContext.Cities.Add(city);
            await this._dbContext.SaveChangesAsync(); 
        }
    }
}
