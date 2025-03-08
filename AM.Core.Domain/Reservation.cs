using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Reservation
    {
        public string PassportNumber { get; set; }
        public virtual Passenger Passenger { get; set; }

        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }


        public double Price { get; set; }
        public string Seat { get; set; }
        public bool Vip { get; set; }


    }
}
