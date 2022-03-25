using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.FavouriteRepo
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly WeatherDbContext _dbContext;
        public FavouriteRepository(WeatherDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Favourite> GetById(int id)
        {
            return await _dbContext.Favourites.FindAsync(id);
        }

        public async Task Add(Favourite fav)
        {
            _dbContext.Favourites.Add(fav);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task Delete(Favourite fav)
        {
            _dbContext.Favourites.Remove(fav);

            await this._dbContext.SaveChangesAsync();
        }
    }
}
