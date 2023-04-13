using HolidaySearchLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchLibrary.Services
{
    public class HolidaySearchService
    {
        private IFlightRepository _flightRepository;
        private IHotelRepository _hotelRepository;
        public HolidaySearchService(IFlightRepository flightRepository, IHotelRepository hotelRepository)
        {
            _flightRepository = flightRepository;
            _hotelRepository = hotelRepository;
        }

        // HolidaySearch

        // PackageHolidayResults

        // PackageHoliday

        // SortHolidayResultsByPrice
    }
}
