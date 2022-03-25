using Infrastructure.Repositories.CityRepo;
using Infrastructure.Repositories.WeatherRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWorks
{
    public class SaveCurrentWeatherUoW : ISaveCurrentWeatherUoW
    {
        private readonly ICityRepository cityRepo;

        private readonly IWeatherRepository weatherRepo;
        public SaveCurrentWeatherUoW(ICityRepository cityRepository,
            IWeatherRepository weatherRepository)
        {
            this.cityRepo= cityRepository;
            this.weatherRepo= weatherRepository;
        }

        public Task<dynamic> Create()
        {

            return null;
        }
    }
}
