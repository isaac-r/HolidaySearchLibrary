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
        public List<Package> HolidaySearch(string DepartureDate, string DepartureAirport, string DestinationAirport, int Duration)
        {
            var matchedFlights = _flightRepository.GetFlights(DepartureAirport, DestinationAirport, DepartureDate);
            var matchedHotels = _hotelRepository.GetHotels(DestinationAirport, DepartureDate, Duration);

            var packageDeals = PackageHolidayResults(matchedFlights, matchedHotels);

            var sortedHolidays = SortHolidayResultsByPrice(packageDeals);

            return sortedHolidays;
        }

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
        public List<Package> SortHolidayResultsByPrice(List<Package> holidayPackages)
        {
            return holidayPackages.OrderBy(p => p.TotalPrice).ToList();            
        }
    }
}
