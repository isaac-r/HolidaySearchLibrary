using HolidaySearchLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchLibrary.Repositories
{
    public interface IFlightRepository
    {
        public List<Flight> GetFlights(string departureAirport, string destinationAirport, string departureDate);

        public List<Flight> LoadFlightData();
    }
}
