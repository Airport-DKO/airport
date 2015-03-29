using System;

namespace Aircraft_Generator.Commons
{
    public class Flight
    {
        public Int32 FlightNumber { get; set; }
        public City City { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }

        public Flight(int flightNumber, City city, DateTime arrivalTime, DateTime departureTime)
        {
            FlightNumber = flightNumber;
            City = city;
            ArrivalTime = arrivalTime;
            DepartureTime = departureTime;
        }

        public Flight()
        {
        }
    }
}