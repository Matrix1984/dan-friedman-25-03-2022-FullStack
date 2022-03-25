using Infrastructure.Repositories.CityRepo;
using Models.DTO.AccuWeatherResponses;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWorks.CityUoW
{
    public class CityCreateUoW : ICityCreateUoW
    {
        private readonly ICityRepository cityRepo;
         
        public CityCreateUoW(ICityRepository cityRepository)
        {
            this.cityRepo = cityRepository; 
        }

        public async Task<IEnumerable<City>> Create(LocationSearchResponseDTO data)
        {
            IList<City> cities=new List<City>();

            foreach (Location item in data.Locations)
            {
                City city = await this.cityRepo.GetByName(item.LocalizedName);

                if (city==null)
                {
                    city = new();

                    city.CityName = item.LocalizedName;

                    await this.cityRepo.Add(city);
                }
                
                cities.Add(city);
            }
         
            return cities;
        }
    }
} 