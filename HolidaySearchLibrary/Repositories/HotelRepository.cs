using HolidaySearchLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchLibrary.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private List<Hotel> hotels;
        public List<Hotel> GetHotels(string arrivalAirport, string arrivalDate, int duration)
        {
            LoadHotelData();
            var hotelResults = hotels.FindAll(h => h.LocalAirports.Contains(arrivalAirport))
                .FindAll(h => h.ArrivalDate == arrivalDate)
                .FindAll(h => h.Nights == duration);
            return hotelResults;
        }

        public List<Hotel> LoadHotelData()
        {
            var filename = File.ReadAllText((Directory.GetCurrentDirectory() + @"\Data\HotelData.json"));
            hotels = JsonConvert.DeserializeObject<List<Hotel>>(filename) ?? new List<Hotel>();
            return hotels;
        }
    }
}
