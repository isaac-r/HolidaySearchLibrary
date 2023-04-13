using HolidaySearchLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchLibrary.Repositories
{
    public interface IHotelRepository
    {
        public List<Hotel> GetHotels(string arrivalAirport, string arrivalDate, int duration);

        public List<Hotel> LoadHotelData();
    }
}
