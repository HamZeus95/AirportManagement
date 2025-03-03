using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Passenger
    {
//        public int PassengerId { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        public DateTime BirthDate { get; set; }


        [Key]
        [StringLength(7, MinimumLength =7, ErrorMessage = "Invalid length")]
        public string PassportNumber { get; set; }


        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string EmailAddress { get; set; }


        [StringLength(25, MinimumLength =3, ErrorMessage ="Invalid Length")]
        public string FirstName { get; set; }


        public string LastName { get; set; }


        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string TelNumber { get; set; }
        public IList<Flight> Flights { get; set; }


       // public int Age { get; set; }
         public int Age 
         { 
             get
             {
                int age = 0;
                age = DateTime.Now.Year - BirthDate.Year;
                if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
                 age--;
                return age;
                
            }  
         }
         
        public override string ToString()
        {
            return "FirstName" + FirstName + "LastName" + "BirthDate" + BirthDate + "TelNumber" + TelNumber + "PassportNumber" + PassportNumber ;
        }

        public bool CheckProfile(string firstName, string lastName)
        {
             return FirstName == firstName  && LastName == lastName; 
        }
        /*
        public bool CheckProfile(string firstName, string lastName , string emailAddress)
        {
            return this.FirstName == firstName && this.LastName == lastName && this.EmailAddress == emailAddress ;
        }
        */

        public bool CheckProfile(params object[]  args )
        {
            if (args.Length == 2)
                return args[0] == FirstName && args[1] == LastName;

            else if (args.Length == 3)
                return args[0] == FirstName && args[1] == LastName && args[2] == EmailAddress;
            else return false;



        }
        
        public bool CheckProfile(string firstName, string lastName, string emailAddress = null )
         {
             if(emailAddress !=  null) 
             return this.FirstName == firstName && this.LastName == lastName && this.EmailAddress == emailAddress;
             else
             return this.FirstName == firstName && this.LastName == lastName;


         }


         public string GetPassengerType2()
        {

            if (this is Traveller)
            {
                return " I am a Traveller";

            }
            if (this is Staff)
            {
                return " I am a Passenger I am a Stuff";

            }
            return "I am a Passenger ";
        }
        
        

        // Polymorphisme par héritge

        public virtual string  GetPassengerType()
        {
            return "I am passenger" ;
        }

        /*public void GetAge(DateTime birthDate, ref int calculatedAge)
        {

            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now < birthDate.AddYears(age))
            {
                age--;
            }
            calculatedAge = age;
        }
        */

        // ref : forcer la passage par reference ->  de recuperer la valeur 
        public void GetAge(DateTime birthDate, ref int calculatedAge)
        {

             calculatedAge = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
            {
                calculatedAge--;
            }
            
        }

        // les classes yet3edew par rederence 

        /*

        public void GetAge(Passenger aPassenger) 
        {
            aPassenger.Age = DateTime.Now.Year - aPassenger.BirthDate.Year;
            if(DateTime.Now.DayOfYear < aPassenger.BirthDate.DayOfYear)
            {
                aPassenger.Age--;
            }
           

        }

        */



    }
}
