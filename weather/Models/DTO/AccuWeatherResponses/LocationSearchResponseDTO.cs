using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.DTO.AccuWeatherResponses
{ 
    public class LocationSearchResponseDTO
    {
        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("localizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("administrativeArea")]
        public Administrativearea AdministrativeArea { get; set; }
    }

    public class Country
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("localizedName")]
        public string LocalizedName { get; set; }
    }

    public class Administrativearea
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("localizedName")]
        public string LocalizedName { get; set; }
    }
}
