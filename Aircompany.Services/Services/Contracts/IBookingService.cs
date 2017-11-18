using System;
using System.Collections.Generic;
using Aircompany.DataAccess.Entities;

namespace Aircompany.Services.Services.Contracts
{
    public interface IBookingService : IDisposable
    {
        void Commit();

        List<Seance> GetActiveSeancesByMovieId(int movieId);

        Seance GetSeance(int id);

        List<Sector> GetSectorsByPlaneId(int planeId);

        bool IsTicketAbleToBook(int row, int place, int seanceId);

        void AddTicketPreOrder(TicketPreOrder ticketPreOrder);

        List<Ticket> GetSeanceTickets(int seanceId);

        List<TicketPreOrder> GetSeanceTicketPreOrdersOfOtherUsers(int seanceId, int profileId);

        List<TicketPreOrder> GetSeanceTicketPreOrdersForCurrentUser(int seanceId, int profileId);

        bool IsSeatBindedToOtherUser(int row, int place, int seanceId, int profileId);

        bool IsSeatBindedByCurrnetUser(int row, int place, int seanceId, int profileId);

        void RemoveTicketPreOrderForUser(int row, int place, int seeanceId, int profileId);

        void MarkTicketPreOrdersAsDeletedForUser(int seanceId, int profileId);

        void BookTickets(List<Ticket> tickets);

        void RemoveTicketPreOrdersForUser(int seanceId, int profileId);

        List<Ticket> GetTicketsForUser(int profileId);

        int GetSeatType(int planeId, int row, int place);

        List<Plane> GetAllPlanes();

        bool IsAvailableSeanceTime(int planeId, DateTime dateTime, int movieLength);

        void AddSeance(Seance seance);

        List<int> GetSeatTypesForPlane(int planeId);

        void SendTickets(List<Ticket> tickets, int languageId, string serverPath, Profile profile);

        List<Seance> GetSeancesThisWeek();
    }
}