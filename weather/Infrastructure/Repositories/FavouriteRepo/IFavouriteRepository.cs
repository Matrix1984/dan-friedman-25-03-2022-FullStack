using Models.Entities;

namespace Infrastructure.Repositories.FavouriteRepo
{
    public interface IFavouriteRepository
    {
        Task<Favourite> GetById(int id); 
        Task Add(Favourite fav); 
        Task Delete(Favourite fav); 
    }
}
