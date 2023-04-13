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
    public class HotelRepositoryTests
    {
        [TestMethod()]
        public void LoadHotelData_HotelJson_JsonParsed()
        {
            var hotelRepo = new HotelRepository();

            var parsedHotelJson = hotelRepo.LoadHotelData();

            Assert.IsNotNull(parsedHotelJson);

            var hotelListType = new List<Hotel>();

            Assert.IsInstanceOfType(parsedHotelJson, hotelListType.GetType());
        }
    }
}