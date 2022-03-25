using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class City
    {
        public int CityId { get; set; } 
        public string CityName { get; set; } 
        public string CityKey { get; set; } 
        public decimal CelsiusTemperature { get; set; }
        public string WeatherText { get; set; } 
        public bool IsFavourite { get; set; }
    }
}
