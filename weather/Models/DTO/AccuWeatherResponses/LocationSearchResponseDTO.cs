﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.DTO.AccuWeatherResponses
{ 
    public class LocationSearchResponseDTO
    { 
        public int Version { get; set; }
         
        public string Key { get; set; }
         
        public string Type { get; set; }
         
        public int Rank { get; set; }
         
        public string LocalizedName { get; set; }
         
        public Country Country { get; set; }
         
        public Administrativearea AdministrativeArea { get; set; }
    }

    public class Country
    { 
        public string ID { get; set; }
         
        public string LocalizedName { get; set; }
    }

    public class Administrativearea
    { 
        public string ID { get; set; }
         
        public string LocalizedName { get; set; }
    }
}
