using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchLibrary.Models
{
    public class Flight
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("airline")]
        public string Airline { get; set; }
        [JsonProperty("to")]
        public string DestinationAirport { get; set; }
        [JsonProperty("from")]
        public string DepartureAirport { get; set; }
        [JsonProperty("price")]
        public int Price { get; set; }
        [JsonProperty("departure_date")]
        public string DepartureDate { get; set; }
    }
}
