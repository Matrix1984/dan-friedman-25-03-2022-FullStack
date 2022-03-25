using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Weather
    {
        public int WeatherId { get; set; }
        public int CityId { get; set; } 
        public City City { get; set; } 
        public decimal CelsiusTemperature  { get; set; } 
        public string WeatherText { get; set; }
    }
}
