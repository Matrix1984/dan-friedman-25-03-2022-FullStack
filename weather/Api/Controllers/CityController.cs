using AutoMapper;
using Infrastructure.AcuWeatherHttp;
using Infrastructure.Repositories.CityRepo; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.AppSettingsDTOs;
using Models.DTO.AccuWeatherResponses;
using Models.DTO.Cities;
using Models.DTO.Errors;
using Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IAcuWeatherHttpService httpService;

        private readonly ICityRepository cityRepository;

        public readonly IMapper mapper;
        public CityController(IAcuWeatherHttpService acuWeatherHttpService,
             ICityRepository repo,
            IMapper mapper)
        {
            this.httpService = acuWeatherHttpService;
            this.cityRepository = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SearchByName(string searchCity)
        {
            IEnumerable<LocationSearchResponseDTO> locationSearchResponseDTO = null;

            if (String.IsNullOrWhiteSpace(searchCity))
                return BadRequest();

            var httpResponseMessage = await this.httpService.SearchByName(searchCity); 

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                try
                {
                    locationSearchResponseDTO = await JsonSerializer.DeserializeAsync
                             <IEnumerable<LocationSearchResponseDTO>>(contentStream);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO()
                    {
                        Status = "Error",
                        Message = "Error fetching locations."
                    });
                }
              
                return Ok(locationSearchResponseDTO);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO()
                {
                    Status = "Error",
                    Message = "Error fetching locations."
                });
            }
        }

        [HttpPatch]
        public async Task<IActionResult> MakeCityFav([FromQuery]int cityId, [FromBody] CityUpdateDTO dto)
        {
            if(cityId==0)
               return BadRequest("City id is 0.");

           City city= await this.cityRepository.GetById(cityId);

            if (city == null)
                return NotFound();

            city.IsFavourite = dto.IsFavourite;

            await this.cityRepository.Update(city);

            return NoContent();
        }

        [HttpGet("ListFavCities")]
        public async Task<IActionResult> ListFavCities()
          => Ok(this.mapper.Map<IEnumerable<CitySelectDTO>>(await this.cityRepository.ListFavourites())); 
        
    }
}
