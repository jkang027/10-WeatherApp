using _10_WeatherApp.Core.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _10_WeatherApp.Core
{
    public class WeatherService
    {
        private static string apiKey = "a9ab931f9e6e70df";

        public static ConditionsResult GetWeatherFor(string zipCode)
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString($"http://api.wunderground.com/api/{apiKey}/conditions/q/CA/{zipCode}.json");

                // var o = JObject.Parse(json);
                // var results = new ConditionsResult();
                // result.icon_url = o["current_observation"]["icon_url"].ToString();

                // deser - generic method - turns JSON object "json" into .net class "ConditionsResult"
                
                var result = JsonConvert.DeserializeObject<ConditionsResult>(json);
                return result;
            }
        }

        public static ConditionsResult GetWeatherFor(string state, string city)
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString($"http://api.wunderground.com/api/{apiKey}/conditions/q/{state}/{city}.json");
                
                var result = JsonConvert.DeserializeObject<ConditionsResult>(json);
                return result;
            }
        }
    }
}
