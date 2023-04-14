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
        //[TestMethod()]
        //public void LoadHotelData_HotelJson_JsonParsed()
        //{
        //    var hotelRepo = new HotelRepository();

        //    var parsedHotelJson = hotelRepo.LoadData();

        //    Assert.IsNotNull(parsedHotelJson);

        //    var hotelListType = new List<Hotel>();

        //    Assert.IsInstanceOfType(parsedHotelJson, hotelListType.GetType());
        //}

        [TestMethod()]
        public void GetHotels_MalagaJuly7Nights_Hotel9Returned()
        {
            var hotelRepo = new HotelRepository();

            var actualHotels = hotelRepo.GetHotels("AGP", "2023-07-01", 7, hotels);

            Assert.AreEqual(1, actualHotels.Count);
            Assert.AreEqual(9, actualHotels[0].Id);
        }

        [TestMethod()]
        public void GetHotels_MallorcaJune10Nights_TwoHotelsReturned()
        {
            var hotelRepo = new HotelRepository();

            var actualHotels = hotelRepo.GetHotels("PMI", "2023-06-15", 10, hotels);

            Assert.AreEqual(2, actualHotels.Count);
            Assert.AreEqual(5, actualHotels[0].Id);
            Assert.AreEqual(13, actualHotels[1].Id);
        }

        [TestMethod()]
        public void GetHotels_CanariaNovember14Nights_TwoHotelsReturned()
        {
            var hotelRepo = new HotelRepository();

            var actualHotels = hotelRepo.GetHotels("LPA", "2022-11-10", 14, hotels);

            Assert.AreEqual(1, actualHotels.Count);
            Assert.AreEqual(6, actualHotels[0].Id);
        }
    }
}