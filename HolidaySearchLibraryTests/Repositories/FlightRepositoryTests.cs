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
        //[TestMethod()]
        //public void LoadFlightData_FlightJson_JsonParsed()
        //{
        //    var flightRepo = new FlightRepository();

        //    var parsedFlightJson = flightRepo.LoadFlightData();

        //    Assert.IsNotNull(parsedFlightJson);

        //    var flightListType = new List<Flight>();

        //    Assert.IsInstanceOfType(parsedFlightJson, flightListType.GetType());
        //}

        [TestMethod()]
        public void GetFlights_FromManchesterToMalagaJuly_Flight2Returned()
        {
            var flightRepo = new FlightRepository();

            var actualFlights = flightRepo.GetFlights(new string[] { "MAN" }, "AGP", "2023-07-01", flights);

            var orderedFlights = actualFlights.OrderBy(f => f.Price).ToList();

            Assert.AreEqual(1, orderedFlights.Count);
            Assert.AreEqual(2, orderedFlights.First().Id);
        }

        [TestMethod()]
        public void GetFlights_FromLondonToMallorcaJune_2FlightsReturned()
        {
            var flightRepo = new FlightRepository();

            var actualFlights = flightRepo.GetFlights(new string[] { "LTN", "LGW" }, "PMI", "2023-06-15", flights);

            var orderedFlights = actualFlights.OrderBy(f => f.Price).ToList();

            Assert.AreEqual(2, orderedFlights.Count);
            Assert.AreEqual(6, orderedFlights[0].Id);
            Assert.AreEqual(4, orderedFlights[1].Id);
        }

        [TestMethod()]
        public void GetFlights_FromAllToCanariaNovember_Flight7Returned()
        {
            var flightRepo = new FlightRepository();

            var actualFlights = flightRepo.GetFlights(new string[] { "MAN", "LTN", "LGW" }, "LPA", "2022-11-10", flights);

            var orderedFlights = actualFlights.OrderBy(f => f.Price).ToList();

            Assert.AreEqual(1, orderedFlights.Count);
            Assert.AreEqual(7, orderedFlights[0].Id);
        }
    }
}