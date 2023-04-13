using HolidaySearchLibrary.Models;
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
        public List<Package> PackageHolidayResults(List<Flight> flightsList, List<Hotel> hotelsList)
        {
            var holidayPackages = new List<Package>();
            foreach (var flight in flightsList)
            {
                foreach(var hotel in hotelsList)
                {
                    holidayPackages.Add(new Package
                    {
                        Flight = flight,
                        Hotel = hotel
                    });
                }
            }
            return holidayPackages;
        }

        // SortHolidayResultsByPrice
    }
}
