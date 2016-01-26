using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace _10_WeatherApp.Core.Domain
{
    public class ConditionsResult
    {
        public Current_Observation current_observation { get; set; }
        public Display_Location display_location { get; set; }
    }

    public class Current_Observation
    {
        public Display_Location display_location { get; set; }
        public string weather { get; set; }
        public string temperature_string { get; set; }
        public string feelslike_string { get; set; }
        public string wind_string { get; set; }
        public string wind_dir { get; set; }
        public string relative_humidity { get; set; }
        public string UV { get; set; }
        public string precip_today_string { get; set; }
        public string visibility_mi { get; set; }
        public string icon_url { get; set; }
        public string icon { get; set; }
        public string observation_time { get; set; }
    }

    public class Display_Location
    {
        public string city { get; set; }
        public string state { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string elevation { get; set; }
    }
}
