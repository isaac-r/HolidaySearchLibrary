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

namespace HolidaySearchLibrary.Services.Tests
{
    [TestClass()]
    public class HolidaySearchServiceTests
    {
        private IFlightRepository _flightRepository;
        private IHotelRepository _hotelRepository;
        private readonly List<Flight> flights = new List<Flight>()
            {
                new Flight {
                    Id = 1,
                    Airline = "First Class Air",
                    DepartureAirport = "MAN",
                    DestinationAirport = "TFS",
                    Price = 470,
                    DepartureDate = "2023-07-01"
                },
                new Flight {

                    Id = 2,
                    Airline = "Oceanic Airlines",
                    DepartureAirport = "MAN",
                    DestinationAirport = "AGP",
                    Price = 245,
                    DepartureDate = "2023-07-01"
                },
                new Flight {

                    Id = 3,
                    Airline = "Trans American Airlines",
                    DepartureAirport = "MAN",
                    DestinationAirport = "PMI",
                    Price = 170,
                    DepartureDate = "2023-06-15"
                },
                new Flight {

                    Id = 4,
                    Airline = "Trans American Airlines",
                    DepartureAirport = "LTN",
                    DestinationAirport = "PMI",
                    Price = 153,
                    DepartureDate = "2023-06-15"

                },
                new Flight {

                    Id = 5,
                    Airline = "Fresh Airways",
                    DepartureAirport = "MAN",
                    DestinationAirport = "PMI",
                    Price = 130,
                    DepartureDate = "2023-06-15"
                },
                new Flight {

                    Id = 6,
                    Airline = "Fresh Airways",
                    DepartureAirport = "LGW",
                    DestinationAirport = "PMI",
                    Price = 75,
                    DepartureDate = "2023-06-15"
                },
                            new Flight {

                    Id = 7,
                    Airline = "Trans American Airlines",
                    DepartureAirport = "MAN",
                    DestinationAirport = "LPA",
                    Price = 125,
                    DepartureDate = "2022-11-10"
                 },
                            new Flight {

                    Id = 8,
                    Airline = "Fresh Airways",
                    DepartureAirport = "MAN",
                    DestinationAirport = "LPA",
                    Price = 175,
                    DepartureDate = "2023-11-10"
                 },
                            new Flight {

                    Id = 9,
                    Airline = "Fresh Airways",
                    DepartureAirport = "MAN",
                    DestinationAirport = "AGP",
                    Price = 140,
                    DepartureDate = "2023-04-11"
                 },
                            new Flight {

                    Id = 10,
                    Airline = "First Class Air",
                    DepartureAirport = "LGW",
                    DestinationAirport = "AGP",
                    Price = 225,
                    DepartureDate = "2023-07-01"
                 },
                            new Flight {

                    Id = 11,
                    Airline = "First Class Air",
                    DepartureAirport = "LGW",
                    DestinationAirport = "AGP",
                    Price = 155,
                    DepartureDate = "2023-07-01"
                 },
                            new Flight {

                    Id = 12,
                    Airline = "Trans American Airlines",
                    DepartureAirport = "MAN",
                    DestinationAirport = "AGP",
                    Price = 202,
                    DepartureDate = "2023-10-25"
                 }
            };
        private readonly List<Hotel> hotels = new List<Hotel>()
            {
                new Hotel {
                  Id = 1,
                  Name ="Iberostar Grand Portals Nous",
                  ArrivalDate="2022-11-05",
                  PricePerNight=100,
                  LocalAirports=new string[]{"TFS"},
                  Nights=7
                },
                new Hotel {
                  Id=2,
                  Name="Laguna Park 2",
                  ArrivalDate="2022-11-05",
                  PricePerNight=50,
                  LocalAirports=new string[]{"TFS"},
                  Nights=7
                },
                new Hotel {
                  Id=3,
                  Name="Sol Katmandu Park & Resort",
                  ArrivalDate="2023-06-15",
                  PricePerNight=59,
                  LocalAirports=new string[]{"PMI"},
                  Nights=14
                },
                new Hotel {
                  Id=4,
                  Name="Sol Katmandu Park & Resort",
                  ArrivalDate="2023-06-15",
                  PricePerNight=59,
                  LocalAirports=new string[]{"PMI"},
                  Nights=14
                },
                new Hotel {
                  Id=5,
                  Name="Sol Katmandu Park & Resort",
                  ArrivalDate="2023-06-15",
                  PricePerNight=60,
                  LocalAirports=new string[]{"PMI"},
                  Nights=10
                },
                new Hotel {
                  Id=6,
                  Name="Club Maspalomas Suites and Spa",
                  ArrivalDate="2022-11-10",
                  PricePerNight=75,
                  LocalAirports=new string[]{"LPA"},
                  Nights=14
                },
                new Hotel {
                  Id=7,
                  Name="Club Maspalomas Suites and Spa",
                  ArrivalDate="2022-09-10",
                  PricePerNight=76,
                  LocalAirports=new string[]{"LPA"},
                  Nights=14
                },
                new Hotel {
                  Id=8,
                  Name="Boutique Hotel Cordial La Peregrina",
                  ArrivalDate="2022-10-10",
                  PricePerNight=45,
                  LocalAirports=new string[]{"LPA"},
                  Nights=7
                },
                new Hotel {
                  Id=9,
                  Name="Nh Malaga",
                  ArrivalDate="2023-07-01",
                  PricePerNight=83,
                  LocalAirports=new string[]{"AGP"},
                  Nights=7
                },

                new Hotel {
                  Id=10,
                  Name="Barcelo Malaga",
                  ArrivalDate="2023-07-05",
                  PricePerNight=45,
                  LocalAirports=new string[]{"AGP"},
                  Nights=10
                },

                new Hotel {
                  Id=11,
                  Name="Parador De Malaga Gibralfaro",
                  ArrivalDate="2023-10-16",
                  PricePerNight=100,
                  LocalAirports=new string[]{"AGP"},
                  Nights=7
                },

                new Hotel {
                  Id=12,
                  Name="MS Maestranza Hotel",
                  ArrivalDate="2023-07-01",
                  PricePerNight=45,
                  LocalAirports=new string[]{"AGP"},
                  Nights=14
                },

                new Hotel {
                  Id=13,
                  Name="Jumeirah Port Soller",
                  ArrivalDate="2023-06-15",
                  PricePerNight=295,
                  LocalAirports=new string[]{"PMI"},
                  Nights=10
                }
            };
        [TestMethod()]
        public void PackageHolidayResults_OneFlightAndTwoHotels_TwoHolidayPackages()
        {
            var mockFlightRepo = new Mock<IFlightRepository>();
            mockFlightRepo
                .Setup(f => f.GetFlights(new string[] { It.IsAny<string>() }, It.IsAny<string>(), It.IsAny<string>()))
                .Returns(flights);

            var mockHotelRepo = new Mock<IHotelRepository>();
            mockHotelRepo.Setup(h => h.GetHotels(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(hotels);

            var HolidaySearchService = new HolidaySearchService(mockFlightRepo.Object, mockHotelRepo.Object);

            var results = HolidaySearchService.PackageHolidayResults(flights, hotels);

            Assert.AreEqual(156, results.Count);
        }

        [TestMethod()]
        public void HolidaySearch_ConcreteRepos_ManchesterMalaga2023_7Nights()
        {
            // Move to Moq
            var mockFlightRepo = new Mock<IFlightRepository>();
            var mockHotelRepo = new Mock<IHotelRepository>();
            mockFlightRepo
                .Setup(f => f.GetFlights(new string[] { It.IsAny<string>() }, It.IsAny<string>(), It.IsAny<string>()))
                .Returns(flights);
            mockHotelRepo
                .Setup(h => h.GetHotels(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns(hotels);

            var HolidaySearchService = new HolidaySearchService(mockFlightRepo.Object, mockHotelRepo.Object);

            var results = HolidaySearchService.HolidaySearch("2023-07-01", new string[] { "MAN" }, "AGP", 7);

            Assert.AreEqual(2, results.First().Flight.Id);
            Assert.AreEqual(9, results.First().Hotel.Id);
        }

        [TestMethod()]
        public void HolidaySearch_ConcreteRepos_AnyLondonMallorca_10Nights()
        {
            var mockFlightRepo = new Mock<IFlightRepository>();
            var mockHotelRepo = new Mock<IHotelRepository>();
            mockFlightRepo
                .Setup(f => f.GetFlights(new string[] { It.IsAny<string>() }, It.IsAny<string>(), It.IsAny<string>()))
                .Returns(flights);
            mockHotelRepo
                .Setup(h => h.GetHotels(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns(hotels);

            var HolidaySearchService = new HolidaySearchService(mockFlightRepo.Object, mockHotelRepo.Object);

            var results = HolidaySearchService.HolidaySearch("2023-06-15", new string[] { "LTN", "LGW" }, "PMI", 10);

            Assert.AreEqual(4, results.Count);

            Assert.AreEqual(6, results.First().Flight.Id);
            Assert.AreEqual(5, results.First().Hotel.Id);
        }

        [TestMethod()]
        public void HolidaySearch_ConcreteRepos_AnyAirport_14Nights()
        {
            var mockFlightRepo = new Mock<IFlightRepository>();
            var mockHotelRepo = new Mock<IHotelRepository>();
            mockFlightRepo
                .Setup(f => f.GetFlights(new string[] { It.IsAny<string>() }, It.IsAny<string>(), It.IsAny<string>()))
                .Returns(flights);
            mockHotelRepo
                .Setup(h => h.GetHotels(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns(hotels);

            var HolidaySearchService = new HolidaySearchService(mockFlightRepo.Object, mockHotelRepo.Object);

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