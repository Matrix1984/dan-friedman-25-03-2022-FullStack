using AutoMapper;
using Infrastructure.Repositories.CityRepo;
using Infrastructure.UnitOfWorks.CityUoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.AppSettingsDTOs;
using Models.DTO.AccuWeatherResponses;
using Models.DTO.Cities;
using Models.DTO.Errors;
using Models.Entities;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;

        private readonly AccurateWeatherOptions accurateWeatherOptions;

        private readonly ICityCreateUoW cityUoW;

        public readonly IMapper autoMapper;
        public CityController(ICityRepository cityRepository,
            IHttpClientFactory httpClientFac,
            IOptions<AccurateWeatherOptions> ops,
            ICityCreateUoW cityU,
            IMapper mapper)
        {
            this.httpClientFactory = httpClientFac;
            this.accurateWeatherOptions = ops.Value;
            this.cityUoW = cityU;
            this.autoMapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> SearchByName(string searchCity)
        {
            string requestUrl = String.Format("{0}/locations/v1/cities/autocomplete?apikey={1}&q={2}", 
                 this.accurateWeatherOptions.Url,
                 this.accurateWeatherOptions.APIkey,
                 searchCity);

            var httpRequestMessage = new HttpRequestMessage(
             HttpMethod.Get,
             requestUrl);

            var httpClient = this.httpClientFactory.CreateClient();

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            LocationSearchResponseDTO locations = new LocationSearchResponseDTO();

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                try
                {
                    locations = await JsonSerializer.DeserializeAsync
                                   <LocationSearchResponseDTO>(contentStream);
                }
                catch (Exception ex)
                { 
                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO()
                    {
                        Status = "Error",
                        Message = "Error fetching the targe cities."
                    });
                } 
            }

            if (locations.Locations.Length == 0)
                return NotFound();

            IEnumerable<City> cities = await this.cityUoW.Create(locations);
              
            return Ok(this.autoMapper.Map<IEnumerable<CitySelectDTO>>(cities));
        }
    }
}
