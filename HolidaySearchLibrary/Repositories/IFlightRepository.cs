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
        public List<Flight> GetFlights(string[] departureAirports, string destinationAirport, string departureDate, List<Flight> allFlights);

        public List<Flight> LoadFlightData();
    }
}
