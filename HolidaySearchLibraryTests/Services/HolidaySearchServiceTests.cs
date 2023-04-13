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
        public void PackageHolidayResults_OneFlightAndTwoHotels_TwoHolidayPackages()
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

        [TestMethod()]
        public void HolidaySearchTest()
        {
            // Move to Moq
            FlightRepository flightsRepository = new();
            HotelRepository hotelsRepository = new();

            var HolidaySearchService = new HolidaySearchService(flightsRepository, hotelsRepository);

            var results = HolidaySearchService.HolidaySearch("2023-07-01", "MAN", "AGP", 7);

            Assert.AreEqual(2, results.First().Flight.Id);
            Assert.AreEqual(9, results.First().Hotel.Id);
        }
    }
}