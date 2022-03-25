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


        public async Task<City> GetByKey(string key)
           => await _dbContext.Cities.Where(x => x.CityKey == key).FirstOrDefaultAsync();


        public async Task<City> GetById(int id)
         => await _dbContext.Cities.FindAsync(id);

        public async Task Add(City city)
        {
            _dbContext.Cities.Add(city);
            await this._dbContext.SaveChangesAsync(); 
        }


        public async Task Update(City city)
        {
            _dbContext.Entry<City>(city).State = EntityState.Modified;

            await this._dbContext.SaveChangesAsync();
        }
    }
}
