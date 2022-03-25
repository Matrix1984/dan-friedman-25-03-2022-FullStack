using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AcuWeatherHttp
{
    public interface IAcuWeatherHttpService
    {
        Task<HttpResponseMessage> SearchByName(string searchCity);

        Task<HttpResponseMessage> GetWeatherConditionsByCityKey(string cityKeyId);
    }
}
