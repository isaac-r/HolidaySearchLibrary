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
        //[TestMethod()]
        //public void LoadFlightData_FlightJson_JsonParsed()
        //{
        //    var flightRepo = new FlightRepository();

        //    var parsedFlightJson = flightRepo.LoadFlightData();

        //    Assert.IsNotNull(parsedFlightJson);

        //    var flightListType = new List<Flight>();

        //    Assert.IsInstanceOfType(parsedFlightJson, flightListType.GetType());
        //}

        //[TestMethod()]
        //public void GetFlights_AllFlightParams_TwoFlightsReturned()
        //{
        //    var flightRepo = new FlightRepository();            

        //    var actualFlights = flightRepo.GetFlights(new string[]{ "MAN" }, "AGP", "2023-07-01");

        //    Assert.AreEqual(1, actualFlights.Count);
        //    Assert.AreEqual(2, actualFlights.First().Id);
        //}
    }
}