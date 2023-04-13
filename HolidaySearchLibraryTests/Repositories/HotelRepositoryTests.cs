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

        [TestMethod()]
        public void GetHotelsTest()
        {
            var hotelRepo = new HotelRepository();

            var expectedHotels = new List<Hotel>()
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
            var actualHotels = hotelRepo.GetHotels("TFS", "2022-11-05", 7);

            Assert.AreEqual(expectedHotels.Count, actualHotels.Count, "Not equal number of returned hotels");
            Assert.AreEqual(expectedHotels.First().Id, actualHotels.First().Id);
        }
    }
}