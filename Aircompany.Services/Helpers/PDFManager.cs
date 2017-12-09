using System;
using System.Configuration;
using System.IO;
using Aircompany.DataAccess.Enums;
using Aircompany.Services.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Aircompany.Services.Helpers
{
    public static class PDFManager
    {
        private const string TICKETS_DIRECTORY_KEY = "TicketsDirectory";

        public static void CreateTicket(TicketPDFModel ticket, string serverPath)
        {
            if (!Directory.Exists(serverPath + ConfigurationManager.AppSettings[TICKETS_DIRECTORY_KEY]))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(serverPath + ConfigurationManager.AppSettings[TICKETS_DIRECTORY_KEY]));
            }

            using (var fileStream = new FileStream(serverPath + ConfigurationManager.AppSettings[TICKETS_DIRECTORY_KEY] +
                    $"\\Ticket-{ticket.Guid}.pdf", FileMode.OpenOrCreate))
            {
                using (var document = new Document(PageSize.A5.Rotate()))
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                    {
                        document.Open();
                        document.NewPage();
                        
                        document.Add(CreateBarcode(ticket.Guid).PlaceBarcode(writer.DirectContentUnder, null, null));

                        document.Add(new Paragraph("FLIGHT TICKET"));
                        document.Add(Chunk.NEWLINE);
                        document.Add(new Paragraph($"Flight code: {ticket.FlightCode}"));
                        document.Add(new Paragraph($"Name: {ticket.Name}"));
                        document.Add(new Paragraph($"Surname: {ticket.Surname}"));
                        document.Add(new Paragraph($"Passport number: {ticket.PassportNumber}"));
                        document.Add(new Paragraph($"Departure airport: {ticket.DepartureAirportCode}, {ticket.DepartureCity}, {ticket.DepartureCountry}"));
                        document.Add(new Paragraph($"Ariving airport: {ticket.ArivingAirportCode}, {ticket.ArivingCity}, {ticket.ArivingCountry}"));
                        document.Add(new Paragraph($"Date: {ticket.Date.ToShortDateString()}"));
                        document.Add(new Paragraph($"Time: {ticket.Time}"));
                        document.Add(new Paragraph($"Hand luggage: {ticket.HandLuggage} kg, luggage {ticket.Luggage} kg"));
                        document.Add(new Paragraph($"Plane model: {ticket.PlaneModel}"));
                        document.Add(new Paragraph($"Row: {ticket.Row}   Place: {ticket.Place}"));
                        document.Add(new Paragraph($"Price: {ticket.Price}"));
                        document.Add(new Paragraph($"Seat type class: {(SeatType) ticket.SeatTypeId}"));
                        document.Add(new Paragraph($"Ticket identifier: {ticket.Guid}"));
                    }
                    document.Close();
                }
            }
        }

        private static Barcode128 CreateBarcode(Guid guid)
        {
            return new Barcode128
            {
                Code = guid.ToString(),
                Font = null,
                BarHeight = 50,
            };
        }
    }
}