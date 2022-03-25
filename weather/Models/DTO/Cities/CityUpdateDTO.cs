﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.DTO.Cities
{
    public class CityUpdateDTO
    {
        [JsonPropertyName("cityId")]
        public bool IsFavourite { get; set; }
    }
}
