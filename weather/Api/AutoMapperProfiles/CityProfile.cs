using AutoMapper;
using Models.DTO.Cities;
using Models.Entities;

namespace Api.AutoMapperProfiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CitySelectDTO>();
        }
    }
}
