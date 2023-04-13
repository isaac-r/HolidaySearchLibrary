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

            Assert.AreEqual(2, results.Count);
        }

        [TestMethod()]
        public void HolidaySearch_ConcreteRepos_ManchesterMalaga2023_7Nights()
        {
            // Move to Moq
            FlightRepository flightsRepository = new();
            HotelRepository hotelsRepository = new();

            var HolidaySearchService = new HolidaySearchService(flightsRepository, hotelsRepository);

            var results = HolidaySearchService.HolidaySearch("2023-07-01", new string[] { "MAN" }, "AGP", 7);

            Assert.AreEqual(2, results.First().Flight.Id);
            Assert.AreEqual(9, results.First().Hotel.Id);
        }

        [TestMethod()]
        public void HolidaySearch_ConcreteRepos_AnyLondonMallorca_10Nights()
        {
            // Move to Moq
            FlightRepository flightsRepository = new();
            HotelRepository hotelsRepository = new();

            var HolidaySearchService = new HolidaySearchService(flightsRepository, hotelsRepository);

            var results = HolidaySearchService.HolidaySearch("2023-06-15", new string[] { "LTN", "LGW" }, "PMI", 10);

            Assert.AreEqual(4, results.Count);

            Assert.AreEqual(6, results.First().Flight.Id);
            Assert.AreEqual(5, results.First().Hotel.Id);
        }

        [TestMethod()]
        public void HolidaySearch_ConcreteRepos_AnyAirport_14Nights()
        {
            // Move to Moq
            FlightRepository flightsRepository = new();
            HotelRepository hotelsRepository = new();

            var HolidaySearchService = new HolidaySearchService(flightsRepository, hotelsRepository);

            var results = HolidaySearchService.HolidaySearch("2022-11-10", new string[] { "LTN", "LGW", "MAN" }, "LPA", 14);

            Assert.AreEqual(7, results.First().Flight.Id);
            Assert.AreEqual(6, results.First().Hotel.Id);
        }

        [TestMethod()]
        public void SortHolidayResultsByPriceTest()
        {
            var packages = new List<Package>()
            {
                new Package
                {
                    Flight = new Flight
                    {
                        Id = 1,
                        Price = 100
                    },
                    Hotel = new Hotel
                    {
                        Id = 1,
                        PricePerNight = 100,
                        Nights = 9
                    }
                },
                new Package
                {
                    Flight = new Flight
                    {
                        Id = 2,
                        Price = 50
                    },
                    Hotel = new Hotel
                    {
                        Id = 2,
                        PricePerNight = 10,
                        Nights = 5
                    }
                }
            };

            var hss = new HolidaySearchService(_flightRepository, _hotelRepository);

            var sortedHolidays = hss.SortHolidayResultsByPrice(packages);

            Assert.AreEqual(2, sortedHolidays.Count());
            Assert.AreEqual(100, sortedHolidays.First().TotalPrice);
            Assert.AreEqual(1000, sortedHolidays[1].TotalPrice);
        }
    }
}