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
    }
}
