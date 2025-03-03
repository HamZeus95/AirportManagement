using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AM.Core.Domain;





namespace AM.Core.Services
{
    public class FlightService : IFlightService
    {

        public IList<Flight> Flights { get; set; }
        public IList<DateTime> GetFlightDates(String Destination)
        {
            IList<DateTime> dates = new List<DateTime>();
            foreach (var flight in Flights)
            {
                if (flight.Destination == Destination)
                    dates.Add(flight.FlightDate);
            }
            return dates;

        }


        public IList<DateTime> GetFlightDatesLink(String Destination)
        {
            //Linq intégré
            //return (from flight in Flignts
            //        where flight.Destination == Destination
            //        select flight.FlightDate).ToList();

            //meth: les fct avancées de linq
            return Flights.Where(f => f.Destination == Destination).Select(f => f.FlightDate).ToList();




        }


        public IList<Flight> GetFlights(string filterType, string filterValue)
        {
            IList<Flight> flights = new List<Flight>();



            switch (filterType)
            {
                case "Destination":
                    foreach (var flight in Flights)
                    {
                        if (flight.Destination == filterValue)
                            flights.Add(flight);

                    }
                    break;

                case "Departure":
                    foreach (var flight in Flights)
                    {
                        if (flight.Departure == filterValue)
                            flights.Add(flight);

                    }
                    break;

                case "FlightDate":
                    foreach (var flight in Flights)
                    {
                        if (flight.FlightDate.ToString().Equals(filterValue))
                            flights.Add(flight);

                    }
                    break;

                case "FlightÎd":
                    foreach (var flight in Flights)
                    {
                        if (flight.FlightId.ToString().Equals(filterValue))
                            flights.Add(flight);

                    }
                    break;
                case "EffectiveArrival":
                    foreach (var flight in Flights)
                    {
                        if (flight.EffectiveArrival.ToString().Equals(filterValue))
                            flights.Add(flight);

                    }
                    break;

                case "EstimateDuration":
                    foreach (var flight in Flights)
                    {
                        if (flight.EstimateDuration.ToString().Equals(filterValue))
                            flights.Add(flight);

                    }
                    break;


                default:
                    return flights;



            }
            return flights;


        }

        public IList<Flight> GetFlights2(string filterType, string filterValue)
        {
            IList<Flight> flights = new List<Flight>();
            foreach (var flight in flights)
            {
                if (typeof(Flight).GetProperty(filterType).GetValue(flight).ToString() == filterValue)
                {
                    flights.Add(flight);
                }
            }
            return flights;
        }


        public void ShowFlightDetails(Plane plane)
        {


            var res = (from Flight in Flights
                       where Flight.MyPlane == plane
                       select (Flight.FlightDate, Flight.Destination)
                    ).ToList();

            //Flignts.Where(f => f.Destination == Destination).Select(f => f.FlightDate).ToList();

            //  var flight = Flignts.Where(f => f.MyPlane == plane);

            var result2 = Flights.Where(f => f.MyPlane.PlaneId == plane.PlaneId).Select(f => new { f.Destination, f.FlightDate }).ToList(); //type anonyme : objet
                                                                                                                                            //.Select(f=> (f.FlightDate, f.Destination));
            Console.WriteLine(Flights);
            foreach (var flight in Flights)
            {
                Console.WriteLine("Dte :  ", (flight.FlightDate), "Destination : ", (flight.Destination));

            }
        }

        public int GetWeeklyFlightNumber(DateTime StartDate)
        {
            return  Flights
                .Where(f => f.FlightDate >= StartDate 
                        && f.FlightDate < StartDate.AddDays(7))
                .Count();
            
        }


        public double GetDurationAverage(string destination)
        {
            return Flights
                .Where(f => f.Destination == destination)
                .Average(f => f.EstimateDuration);
                  
        }

        public IList<Flight> SortFlights()
        {
            return Flights.OrderByDescending(f => f.EstimateDuration).ToList();
        }

        public IList<Passenger> GetThreeOlderTravellers(Flight flight)
        {

            //return flight.Passengers.OfType<Traveller>().OrderByDescending(f => f.BirthDate).Take(3);
              return flight.Passengers
               .OfType<Traveller>()
              .OrderBy(p => p.BirthDate )
              .Take(3)
              .ToList<Passenger>();
        }

        public void ShowGroupedFlights()
        {
             IEnumerable<IGrouping<string,Flight>> req = Flights.GroupBy(f => f.Destination);

            foreach (IGrouping<string, Flight> g in req)
            {
                Console.WriteLine("Destination: " + g.Key);
                foreach (Flight f in g)
                Console.WriteLine("les vols: " + f);
            }




        }





    }


}

