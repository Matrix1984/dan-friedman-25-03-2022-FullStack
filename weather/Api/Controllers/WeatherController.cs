using AutoMapper;
using Infrastructure.AcuWeatherHttp;
using Infrastructure.Repositories.CityRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.AccuWeatherResponses;
using Models.DTO.Cities;
using Models.DTO.Errors;
using Models.Entities;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IAcuWeatherHttpService httpService;

        private readonly ICityRepository cityRepository;

        public readonly IMapper mapper;
        public WeatherController(IAcuWeatherHttpService acuWeatherHttpService,
             ICityRepository repo,
            IMapper mapper)
        {
            this.httpService = acuWeatherHttpService;
            this.cityRepository = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherByLocation(string cityKey, string cityName)
        {

            if (String.IsNullOrWhiteSpace(cityKey) || String.IsNullOrWhiteSpace(cityName))
                return BadRequest();

            City city = await this.cityRepository.GetByKey(cityKey);

            if (city != null) 
                return Ok(this.mapper.Map<CitySelectDTO>(city)); 

            var httpResponseMessage = await this.httpService.GetWeatherConditionsByCityKey(cityKey);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                WeatherConditionsDTO weatherDTO = null;

                try
                {
                    weatherDTO = await JsonSerializer.DeserializeAsync
                                                  <WeatherConditionsDTO>(contentStream);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO()
                    {
                        Status = "Error",
                        Message = "Error fetching weather for the city."
                    });
                }

                if (weatherDTO != null)
                {
                    city = new();
                    city.CityName = cityName;
                    city.CityKey = cityKey;
                    city.WeatherText = weatherDTO.WeatherConditions[0].WeatherText;
                    city.CelsiusTemperature = weatherDTO.WeatherConditions[0].Temperature.Metric.Value;
                    await this.cityRepository.Add(city);
                }

                return Ok(this.mapper.Map<CitySelectDTO>(city));
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO()
                {
                    Status = "Error",
                    Message = "Error fetching the weather data from the server."
                });
            }
        }
    }
}
