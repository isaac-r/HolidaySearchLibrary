using Microsoft.VisualStudio.TestTools.UnitTesting;
using HolidaySearchLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using HolidaySearchLibrary.Repositories;
using HolidaySearchLibrary.Models;

namespace HolidaySearchLibrary.Services.Tests
{
    [TestClass()]
    public class HolidaySearchServiceTests
    {
        private IFlightRepository _flightRepository;
        private IHotelRepository _hotelRepository;
        [TestMethod()]
        public void PackageHolidayResultsTest()
        {
            var HolidaySearchService = new HolidaySearchService(_flightRepository, _hotelRepository);

            var flights = new List<Flight>()
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

            var hotels = new List<Hotel>()
            {
                new Hotel
                {
                    Id = 1,
                    ArrivalDate = "2022-11-05",
                    LocalAirports = new string[]
                    {
                        "TFS"
                    },
                    Nights = 7
                },
                new Hotel
                {
                    Id = 2,
                    ArrivalDate = "2022-11-05",
                    LocalAirports = new string[]
                    {
                        "TFS"
                    },
                    Nights = 7
                }
            };

            var results = HolidaySearchService.PackageHolidayResults(flights, hotels);

            Assert.IsNotNull(results);
            Assert.AreEqual(2, results.Count);
        }
    }
}