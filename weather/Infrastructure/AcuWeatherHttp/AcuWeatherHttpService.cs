using Infrastructure.Repositories.CityRepo;
using Microsoft.Extensions.Options;
using Models.AppSettingsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AcuWeatherHttp
{
    public class AcuWeatherHttpService : IAcuWeatherHttpService
    {
        private readonly IHttpClientFactory httpClientFactory;

        private readonly AccurateWeatherOptions accurateWeatherOptions;
 
        public AcuWeatherHttpService(ICityRepository cityRepository,
            IHttpClientFactory httpClientFac,
            IOptions<AccurateWeatherOptions> ops )
        {
            this.httpClientFactory = httpClientFac;
            this.accurateWeatherOptions = ops.Value; 
        }

        public async Task<HttpResponseMessage> SearchByName(string searchCity)
        { 
            string requestUrl = String.Format("{0}/locations/v1/cities/autocomplete?apikey={1}&q={2}",
                 this.accurateWeatherOptions.Url,
                 this.accurateWeatherOptions.APIkey,
                 searchCity);

            return await MakeRequest(requestUrl);
        }

        public async Task<HttpResponseMessage> GetWeatherConditionsByCityKey(string cityKeyId)
           =>  await MakeRequest( String.Format("{0}/currentconditions/v1/{2}?apikey={1}",
                 this.accurateWeatherOptions.Url,
                 this.accurateWeatherOptions.APIkey,
                 cityKeyId));



        private async Task<HttpResponseMessage> MakeRequest(string requestUrl)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                requestUrl);

            var httpClient = this.httpClientFactory.CreateClient();

            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}
