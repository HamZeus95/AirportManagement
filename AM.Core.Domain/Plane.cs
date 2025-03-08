using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{

    public enum PlaneType
    {
        Boing  , Airbus 
    }

    public class Plane
    {
        /*private  int capacity;
         public int getcapacity() 
         { 
             return capacity; 

         }
         public void setcapacityt(int capacity) 
         {
             this.capacity = capacity;


         }

         */


        [Range(0, int.MaxValue, ErrorMessage = " Capacity must be positive")]
        public int Capacity { get; set; }
        public DateTime ManufacturDate { get; set; }

        [Key]
        [Required]
        public int PlaneId { get; set; }

        public PlaneType  MyPlaneType { get; set; }

        public virtual IList<Flight> Flights { get; set; }

        /*public override string ToString()
        {
            return   "MyPlaneType" + MyPlaneType +  "Capacity" + Capacity + "ManufacturDate" + ManufacturDate  ; 
        }
        */

        public override string ToString()
        {
            return $"Capacity : {Capacity} " + $"ManufacturDate : {ManufacturDate}" + $"PlaneId : {PlaneId}" + $"MyPlaneType : {MyPlaneType}";
        }

        // ctor to create default constructor
        public Plane()
        {
            
        }
        public Plane(PlaneType pt, int capacity, DateTime date)
          {
              MyPlaneType = pt;
              Capacity = capacity; // this est ajouter si ils sont les meme valeurs  this.Capacity = Capacity;
              ManufacturDate = date;
          }

          



    }


}
