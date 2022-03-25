﻿using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CityRepo
{
    public interface ICityRepository
    {
        Task Add(City city);
        Task<City> GetByName(string cityName);
    }
}