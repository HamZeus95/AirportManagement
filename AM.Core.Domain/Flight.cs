using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Flight
    {
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public int EffectiveArrival { get; set; }
        public int EstimateDuration { get; set; }
        public string Comment { get; set; }

        [ForeignKey("MyPlane")]
        public int PlaneId { get; set; }

        // or :[ForeignKey("PlaneId")]
        public Plane MyPlane { get; set; }
        public IList<Passenger> Passengers { get; set; }

         public override string ToString()
         {
             return "FlightÎd" + FlightId + "Destination" + Destination + "Departure" + Departure + "FlightDate"+ FlightDate+ "EffectiveArrival"+ EffectiveArrival+ "EstimateDuration" + EstimateDuration + "MyPlane" + MyPlane.ToString() ;
         }
        

       

    }
}
