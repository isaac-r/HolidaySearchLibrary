using Microsoft.VisualStudio.TestTools.UnitTesting;
using HolidaySearchLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidaySearchLibrary.Models;

namespace HolidaySearchLibrary.Repositories.Tests
{
    [TestClass()]
    public class FlightRepositoryTests
    {
        [TestMethod()]
        public void LoadFlightData_FlightJson_JsonParsed()
        {
            var flightRepo = new FlightRepository();

            var parsedFlightJson = flightRepo.LoadFlightData();

            Assert.IsNotNull(parsedFlightJson);

            var flightListType = new List<Flight>();

            Assert.IsInstanceOfType(parsedFlightJson, flightListType.GetType());
        }

        [TestMethod()]
        public void GetFlights_AllFlightParams_OneFlightReturned()
        {
            var flightRepo = new FlightRepository();

            var expectedFlights = new List<Flight>()
            {
                new Flight
                {
                    Id = 1,
                    Airline = "",
                    DepartureAirport = "MAN",
                    DestinationAirport = "TFS",
                    DepartureDate = "2023-07-01"
                }
            };

            var actualFlights = flightRepo.GetFlights("MAN", "TFS", "2023-07-01");

            Assert.AreEqual(expectedFlights.Count, actualFlights.Count);
            Assert.AreEqual(expectedFlights.First().Id, actualFlights.First().Id);
        }
    }
}