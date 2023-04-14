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
using Moq;
using System.ComponentModel;

namespace HolidaySearchLibrary.Services.Tests
{
    [TestClass()]
    public class HolidaySearchServiceTests
    {
        [TestMethod()]
        public void PackageHolidayResults_OneFlightAndTwoHotels_TwoHolidayPackages()
        {
            var flights = new List<Flight>()
            {
                new Flight{}
            };
            var hotels = new List<Hotel>()
            {
                new Hotel{},
                new Hotel{}
            };
            var mockFlightRepo = new Mock<IFlightRepository>();

            var mockHotelRepo = new Mock<IHotelRepository>();

            var HolidaySearchService = new HolidaySearchService(mockFlightRepo.Object, mockHotelRepo.Object);

            var results = HolidaySearchService.PackageHolidayResults(flights, hotels);

            Assert.AreEqual(2, results.Count);
        }

        [TestMethod()]
        public void PackageHolidayResults_ThreeFlightsAndTwoHotels_6HolidayPackages()
        {
            var flights = new List<Flight>()
            {
                new Flight{},
                new Flight{},
                new Flight{}
            };
            var hotels = new List<Hotel>()
            {
                new Hotel{},
                new Hotel{}
            };
            var mockFlightRepo = new Mock<IFlightRepository>();

            var mockHotelRepo = new Mock<IHotelRepository>();

            var HolidaySearchService = new HolidaySearchService(mockFlightRepo.Object, mockHotelRepo.Object);

            var results = HolidaySearchService.PackageHolidayResults(flights, hotels);

            Assert.AreEqual(6, results.Count);
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

            var mockFlightRepo = new Mock<IFlightRepository>();
            var mockHotelRepo = new Mock<IHotelRepository>();

            var hss = new HolidaySearchService(mockFlightRepo.Object, mockHotelRepo.Object);

            var sortedHolidays = hss.SortHolidayResultsByPrice(packages);

            Assert.AreEqual(2, sortedHolidays.Count());
            Assert.AreEqual(100, sortedHolidays.First().TotalPrice);
            Assert.AreEqual(1000, sortedHolidays[1].TotalPrice);
        }
    }
}