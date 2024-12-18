using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceClass
{
    public interface IFlightBooking
    {
        void Login(string username, string password);
        void SelectFlightDetails(string from, string to, DateTime departureDate, int passengers, DateTime returnDate);
        void BookFlight();
        void Close();
    }

}
