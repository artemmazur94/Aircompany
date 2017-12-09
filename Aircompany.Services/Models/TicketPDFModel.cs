using System;

namespace Aircompany.Services.Models
{
    public class TicketPDFModel
    {
        public Guid Guid { get; set; }

        public string FlightCode { get; set; }
        public string DepartureAirportCode { get; set; }
        public string DepartureCity { get; set; }
        public string DepartureCountry { get; set; }

        public string ArivingAirportCode { get; set; }
        public string ArivingCity { get; set; }
        public string ArivingCountry { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public string PlaneModel { get; set; }

        public int Row { get; set; }

        public int Place { get; set; }

        public decimal Price { get; set; }

        public int SeatTypeId { get; set; }

        public int HandLuggage { get; set; }
        public int Luggage { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string PassportNumber { get; set; }
    }
}