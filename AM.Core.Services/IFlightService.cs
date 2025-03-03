using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Core.Domain;

namespace AM.Core.Services
{
    internal interface IFlightService
    {
        IList<DateTime> GetFlightDates(String Destination) ;
        IList<DateTime> GetFlightDatesLink(String Destination);
        IList<Flight>  GetFlights(string filterType, string filterValue);
        IList<Flight> GetFlights2(string filterType, string filterValue);
        void ShowFlightDetails(Plane plane);
        int GetWeeklyFlightNumber(DateTime StartDate);
        double GetDurationAverage(string destination);
        IList<Flight> SortFlights();
        IList<Passenger> GetThreeOlderTravellers(Flight flight);
        void ShowGroupedFlights();

    }
}
