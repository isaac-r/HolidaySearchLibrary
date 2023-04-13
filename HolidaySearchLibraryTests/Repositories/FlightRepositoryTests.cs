using Microsoft.VisualStudio.TestTools.UnitTesting;
using HolidaySearchLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //Assert.Fail();
        }
    }
}