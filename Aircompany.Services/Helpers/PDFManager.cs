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
            using (var fileStream = new FileStream(serverPath + ConfigurationManager.AppSettings[TICKETS_DIRECTORY_KEY] +
                    $"\\Ticket-{ticket.Guid}.pdf", FileMode.Create))
            {
                using (var document = new Document(PageSize.A6.Rotate()))
                {
                    using (PdfWriter writer = PdfWriter.GetInstance(document, fileStream))
                    {
                        document.Open();
                        document.Add(new Paragraph("TICKET"));
                        document.Add(new Paragraph($"Movie: {ticket.MovieName}"));
                        document.Add(new Paragraph($"Date: {ticket.Date.ToShortDateString()}"));
                        document.Add(new Paragraph($"Time: {ticket.Time}"));
                        document.Add(new Paragraph($"Plane model: {ticket.PlaneModel}"));
                        document.Add(new Paragraph($"Row: {ticket.Row}   Place: {ticket.Place}"));
                        document.Add(new Paragraph($"Price: {ticket.Price}"));
                        document.Add(new Paragraph($"Seat type class: {(SeatType) ticket.SeatTypeId}"));
                        document.Add(new Paragraph($"Ticket identifier: {ticket.Guid}"));
                        document.Close();
                    }
                }
            }
        }
    }
}