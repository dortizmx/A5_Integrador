using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System.Threading.Tasks;

namespace testapp
{
    public class WebServicesManager
    {
        public WebServicesManager()
        {
        }

        public async Task<Resultado> Get(string ciudad, string pais,CancellationToken ct = default(CancellationToken))
        {

            HttpClient client = new HttpClient();
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={ciudad},{pais}&appid=cc654b6d33a92fe00a041f36527f367f";
            var resultado = await client.GetAsync(url);
            if(resultado.StatusCode == HttpStatusCode.OK)
            {
                var resultJson = resultado.Content.ReadAsStringAsync().Result;
                JObject jsonresult = JObject.Parse(resultJson);
                var results = jsonresult["main"];
                Resultado retval = JsonConvert.DeserializeObject<Resultado>(results.ToString());
                //retval = retval == null ? retval = new Resultado() : retval;
                return retval;
            }
            return null;
            
            

        }
    }
}
