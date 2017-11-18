using System;

namespace Aircompany.Services.Models
{
    public class TicketPDFModel
    {
        public Guid Guid { get; set; }

        public string MovieName { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public string PlaneModel { get; set; }

        public int Row { get; set; }

        public int Place { get; set; }

        public decimal Price { get; set; }

        public int SeatTypeId { get; set; }
    }
}