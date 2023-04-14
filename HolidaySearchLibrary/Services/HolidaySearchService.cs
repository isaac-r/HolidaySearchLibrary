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
        private List<Flight> _flights;
        private List<Hotel> _hotels;
        public HolidaySearchService(IFlightRepository flightRepository, IHotelRepository hotelRepository)
        {
            _flightRepository = flightRepository;
            _hotelRepository = hotelRepository;

            // Loading Data from JSON into Service
            _flights = _flightRepository.LoadFlightData();
            _hotels = _hotelRepository.LoadHotelData();
        }

        public List<Package> HolidaySearch(string DepartureDate, string[] DepartureAirports, string DestinationAirport, int Duration)
        {
            var matchedFlights = _flightRepository.GetFlights(DepartureAirports, DestinationAirport, DepartureDate, _flights);
            var matchedHotels = _hotelRepository.GetHotels(DestinationAirport, DepartureDate, Duration, _hotels);

            var packageDeals = PackageHolidayResults(matchedFlights, matchedHotels);

            var sortedHolidays = SortHolidayResultsByPrice(packageDeals);

            return sortedHolidays;
        }

        public List<Package> PackageHolidayResults(List<Flight> flightsList, List<Hotel> hotelsList)
        {
            var holidayPackages = new List<Package>();
            foreach (var flight in flightsList)
            {
                foreach (var hotel in hotelsList)
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

        public List<Package> SortHolidayResultsByPrice(List<Package> holidayPackages)
        {
            return holidayPackages.OrderBy(p => p.TotalPrice).ToList();
        }
    }
}
