using HolidaySearchLibrary.Models;
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
        public List<Hotel> GetHotels(string arrivalAirport, string arrivalDate, string duration)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> LoadHotelData()
        {
            throw new NotImplementedException();
        }
    }
}
