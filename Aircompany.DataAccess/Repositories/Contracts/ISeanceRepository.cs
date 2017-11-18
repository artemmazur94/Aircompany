using System;
using System.Collections.Generic;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.Repositories.Contracts
{
    public interface ISeanceRepository : IDisposable, IRepository<Seance>
    {
        List<Sector> GetSectorsByPlaneId(int planeId);

        bool IsExistTicketPreOrder(int row, int place, int seanceId);

        bool IsExistTicket(int row, int place, int seanceId);

        void AddTicketPreOrder(TicketPreOrder ticketPreOrder);

        List<Ticket> GetSeanceTickets(int seanceId);

        List<TicketPreOrder> GetSeanceTicketPreOrdersOfOtherUsers(int seanceId, int profileId);

        List<TicketPreOrder> GetSeanceTicketPreOrdersForUser(int seanceId, int profileId);

        bool IsSeatBindedToOtherUser(int row, int place, int seanceId, int profileId);

        bool IsSeatBindedByCurrnetUser(int row, int place, int seanceId, int profileId);

        TicketPreOrder GetTicketPreOrderBySeanceData(int row, int place, int seanceId, int profileId);

        void RemoveTicketPreOrder(TicketPreOrder ticketPreOrder);

        void MarkSeanceTicketPreOrdersAsDeletedForUser(int seanceId, int profileId);

        void AddTickets(List<Ticket> tickets);

        List<Ticket> GetTicketsForUser(int profileId);

        int GetSeatType(int planeId, int row, int place);

        List<Plane> GetAllPlanes();

        bool IsAvailableSeanceTime(int planeId, DateTime dateTime, int movieLength);

        List<int> GetSeatTypesForPlane(int planeId);

        decimal GetPriceBySeatTypeId(int seatTypeId, int seanceId);

        List<Seance> GetSeancesThisWeek();
    }
}