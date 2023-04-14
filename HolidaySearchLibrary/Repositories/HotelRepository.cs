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
        public List<Hotel> GetHotels(string arrivalAirport, string arrivalDate, int duration, List<Hotel> allHotels)
        {
            var hotelResults = allHotels.FindAll(h => h.LocalAirports.Contains(arrivalAirport))
                .FindAll(h => h.ArrivalDate == arrivalDate)
                .FindAll(h => h.Nights == duration);
            return hotelResults;
        }

        public List<Hotel> LoadData(string path, bool isFile)
        {
            if (string.IsNullOrEmpty(path))
            {
                path = Directory.GetCurrentDirectory() + @"\Data\HotelData.json";
            }
            string? hotelData;
            if (isFile)
            {
                hotelData = path;
            }
            else
            {
                hotelData = File.ReadAllText(path);
            }

            return JsonConvert.DeserializeObject<List<Hotel>>(hotelData) ?? new List<Hotel>();
        }
    }
}
