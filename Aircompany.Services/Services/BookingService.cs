using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Aircompany.DataAccess;
using Aircompany.DataAccess.Entities;
using Aircompany.Services.Helpers;
using Aircompany.Services.Models;
using Aircompany.Services.Services.Contracts;

namespace Aircompany.Services.Services
{
    public class BookingService : IBookingService
    {
        private const string TICKETS_DIRECTORY_KEY = "TicketsDirectory";
        
        private readonly IUnitOfWork _unitOfWork;

        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public List<Seance> GetActiveSeancesByMovieId(int movieId)
        {
            return _unitOfWork.SeanceRepository.Find(x => x.MovieId == movieId && x.DateTime > DateTime.UtcNow).ToList();
        }

        public Seance GetSeance(int id)
        {
            return _unitOfWork.SeanceRepository.Get(id);
        }

        public List<Sector> GetSectorsByPlaneId(int planeId)
        {
            return _unitOfWork.SeanceRepository.GetSectorsByPlaneId(planeId);
        }

        public bool IsTicketAbleToBook(int row, int place, int seanceId)
        {
            return !_unitOfWork.SeanceRepository.IsExistTicket(row, place, seanceId);
        }

        public void AddTicketPreOrder(TicketPreOrder ticketPreOrder)
        {
            _unitOfWork.SeanceRepository.AddTicketPreOrder(ticketPreOrder);
        }

        public List<Ticket> GetSeanceTickets(int seanceId)
        {
            return _unitOfWork.SeanceRepository.GetSeanceTickets(seanceId);
        }

        public List<TicketPreOrder> GetSeanceTicketPreOrdersOfOtherUsers(int seanceId, int profileId)
        {
            return _unitOfWork.SeanceRepository.GetSeanceTicketPreOrdersOfOtherUsers(seanceId, profileId);
        }

        public List<TicketPreOrder> GetSeanceTicketPreOrdersForCurrentUser(int seanceId, int profileId)
        {
            return _unitOfWork.SeanceRepository.GetSeanceTicketPreOrdersForUser(seanceId, profileId);
        }

        public bool IsSeatBindedToOtherUser(int row, int place, int seanceId, int profileId)
        {
            return _unitOfWork.SeanceRepository.IsSeatBindedToOtherUser(row, place, seanceId, profileId);
        }

        public bool IsSeatBindedByCurrnetUser(int row, int place, int seanceId, int profileId)
        {
            return _unitOfWork.SeanceRepository.IsSeatBindedByCurrnetUser(row, place, seanceId, profileId);
        }

        public void RemoveTicketPreOrderForUser(int row, int place, int seanceId, int profileId)
        {
            TicketPreOrder ticketPreOrder = _unitOfWork.SeanceRepository.GetTicketPreOrderBySeanceData(row, place, seanceId, profileId);
            _unitOfWork.SeanceRepository.RemoveTicketPreOrder(ticketPreOrder);
        }

        public void MarkTicketPreOrdersAsDeletedForUser(int seanceId, int profileId)
        {
            _unitOfWork.SeanceRepository.MarkSeanceTicketPreOrdersAsDeletedForUser(seanceId, profileId);
        }

        public void BookTickets(List<Ticket> tickets)
        {
            tickets.ForEach(ticket => ticket.Guid = Guid.NewGuid());
            _unitOfWork.SeanceRepository.AddTickets(tickets);
        }

        public void SendTickets(List<Ticket> tickets, int languageId, string serverPath, Profile profile)
        {
            List<TicketPDFModel> ticketModels = new List<TicketPDFModel>();
            int seanceId = tickets.First().SeanceId;
            tickets.ForEach(ticket => ticketModels.Add(new TicketPDFModel()
            {
                Date = ticket.Seance.DateTime.ToLocalTime().Date,
                Time = ticket.Seance.DateTime.ToLocalTime().TimeOfDay,
                PlaneModel = $"{ticket.Seance.Plane.Manufacturer} {ticket.Seance.Plane.Model}",
                MovieName = _unitOfWork.MovieRepository.GetMovieLocalization(ticket.Seance.MovieId, languageId).Name,
                Place = ticket.Place,
                Row = ticket.Row,
                Guid = ticket.Guid,
                SeatTypeId = _unitOfWork.SeanceRepository.GetSeatType(ticket.Seance.PlaneId, ticket.Row, ticket.Place),
            }));
            ticketModels.ForEach(
                x => x.Price = _unitOfWork.SeanceRepository.GetPriceBySeatTypeId(x.SeatTypeId, seanceId));
            List<string> pathes =
                tickets.Select(x => serverPath + ConfigurationManager.AppSettings[TICKETS_DIRECTORY_KEY] +
                                    $"\\Ticket-{x.Guid}.pdf").ToList();
            ticketModels.ForEach(x => PDFManager.CreateTicket(x, serverPath));
            EmailManager.TicketEmail(pathes, profile.Email,
                $"{profile.Name} {profile.Surname}");
        }

        public List<Seance> GetSeancesThisWeek()
        {
            return _unitOfWork.SeanceRepository.GetSeancesThisWeek();
        }

        public void RemoveTicketPreOrdersForUser(int seanceId, int profileId)
        {
            List<TicketPreOrder> ticketPreOrders = GetSeanceTicketPreOrdersForCurrentUser(seanceId, profileId);
            ticketPreOrders.ForEach(x => _unitOfWork.SeanceRepository.RemoveTicketPreOrder(x));
        }

        public List<Ticket> GetTicketsForUser(int profileId)
        {
            return _unitOfWork.SeanceRepository.GetTicketsForUser(profileId);
        }

        public int GetSeatType(int planeId, int row, int place)
        {
            return _unitOfWork.SeanceRepository.GetSeatType(planeId, row, place);
        }

        public List<Plane> GetAllPlanes()
        {
            return _unitOfWork.SeanceRepository.GetAllPlanes();
        }

        public bool IsAvailableSeanceTime(int planeId, DateTime dateTime, int movieLength)
        {
            return _unitOfWork.SeanceRepository.IsAvailableSeanceTime(planeId, dateTime, movieLength);
        }

        public void AddSeance(Seance seance)
        {
            _unitOfWork.SeanceRepository.Add(seance);
        }

        public List<int> GetSeatTypesForPlane(int planeId)
        {
            return _unitOfWork.SeanceRepository.GetSeatTypesForPlane(planeId);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}