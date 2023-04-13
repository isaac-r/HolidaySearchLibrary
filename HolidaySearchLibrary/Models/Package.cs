using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearchLibrary.Models
{
    public class Package
    {
        public Flight Flight { get; set; }
        public Hotel Hotel { get; set; }
        public int TotalPrice
        {
            get
            {
                return Flight.Price + (Hotel.PricePerNight * Hotel.Nights);
            }
        }
    }
}
