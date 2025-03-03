using System.Net.Mail;
using AM.Core.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AM.Data;


/*** Partie 2 : Instanciation des objets ***/


Plane plane = new Plane();
plane.MyPlaneType = PlaneType.Airbus;
plane.Capacity = 150;
plane.ManufacturDate = new DateTime(2015, 05, 06);

Console.WriteLine(plane);

Plane plane2 = new Plane( PlaneType.Airbus , 150 , new DateTime(2015 , 05 , 08) );
Console.WriteLine(plane2);

//initialiseur d'objet
Plane plane3 = new Plane
{
    MyPlaneType = PlaneType.Airbus,
    Capacity = 150,
    ManufacturDate = new DateTime(2016, 05 , 06) 
     
};

Console.WriteLine(plane3.ToString());


/*** Partie 3 : Polymorphisme De Surcharge ***/

Passenger passenger = new Passenger
{
    FirstName = "Ahmed",
    LastName = "Sallem",
    BirthDate = new DateTime(1964, 03, 06),
    EmailAddress = "Sallem.Ahmed@gmail"
};

Console.WriteLine(passenger.CheckProfile("Ahmed" , "Sallem"));
Console.WriteLine(passenger.CheckProfile("Ahmed", "Sallem", "Sallem.Ahmed@gmail"));

/*** Partie 4 : Polymorphisme d’heritage ***/

Staff staff = new Staff
{

    FirstName = "Selma",
    LastName = "Sahli",
    BirthDate = new DateTime(1995, 05, 12),
    EmailAddress = "Selma.Sahli@gmail",
    Salary = 1000,
    EmployementDate = new DateTime(2022,11,15)

};

Traveller traveller = new Traveller {

    FirstName = "Mart",
    LastName = "Kendy",
    BirthDate = new DateTime(1964, 03, 06),
    EmailAddress = "Sallem.Ahmed@gmail" ,
    HealthInformation =  " no disease " ,
    Nationality = "American"

};
Console.WriteLine(passenger.GetPassengerType());
Console.WriteLine(staff.GetPassengerType());
Console.WriteLine(traveller.GetPassengerType());

/*** VI Passage par valeur / Passage par référence ***/

Passenger passenger2 = new Passenger {

    BirthDate = new DateTime(2000,05,06)
};

int age = 0;

passenger2.GetAge(passenger2.BirthDate, ref age);

Console.WriteLine(age);


//passenger2.GetAge(passenger2);

Console.WriteLine(passenger2.Age);

/*** V Encapsulation ***/

Passenger passenger4 = new Passenger
{

    BirthDate = new DateTime(1995, 07, 09)
};

Console.WriteLine(passenger4.Age);



Plane plane4 = new Plane
{
    MyPlaneType = PlaneType.Airbus,
    Capacity = 0,
    ManufacturDate = new DateTime(2016, 05, 06)

};

Flight flight = new Flight
{
    Departure = "Brazil",
    Destination = "Brazil",
    FlightDate = new DateTime(2022, 05, 06),
    EstimateDuration = 3,
    EffectiveArrival = 3,
    Comment = "A very good flight",
    MyPlane = plane4
};

AMContext aMContext = new AMContext();
aMContext.Flights.Add(flight);
aMContext.SaveChanges();

