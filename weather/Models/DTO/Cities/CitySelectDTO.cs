using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.DTO.Cities
{
    public class CitySelectDTO
    {
        [JsonPropertyName("cityId")]
        public int CityId { get; set; }

        [JsonPropertyName("cityName")]
        public string CityName { get; set; }

        [JsonPropertyName("cityKey")]
        public string CityKey { get; set; }

        [JsonPropertyName("celsiusTemperature")]
        public decimal CelsiusTemperature { get; set; }

        [JsonPropertyName("weatherText")]
        public string WeatherText { get; set; }

        [JsonPropertyName("isFavourite")]
        public bool IsFavourite { get; set; }
    }
}
