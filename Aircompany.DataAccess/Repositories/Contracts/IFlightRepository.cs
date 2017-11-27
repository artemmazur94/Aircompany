using System;
using System.Collections.Generic;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.Repositories.Contracts
{
    public interface IFlightRepository : IDisposable, IRepository<Flight>
    {
        List<Sector> GetSectorsByPlaneId(int planeId);

        bool IsExistTicketPreOrder(int row, int place, int flightId);

        bool IsExistTicket(int row, int place, int flightId);

        void AddTicketPreOrder(TicketPreOrder ticketPreOrder);

        List<Ticket> GetFlightTickets(int flightId);

        List<TicketPreOrder> GetFlightTicketPreOrdersOfOtherUsers(int flightId, int profileId);

        List<TicketPreOrder> GetFlightTicketPreOrdersForUser(int flightId, int profileId);

        bool IsSeatBindedToOtherUser(int row, int place, int flightId, int profileId);

        bool IsSeatBindedByCurrnetUser(int row, int place, int flightId, int profileId);

        TicketPreOrder GetTicketPreOrderByFlightData(int row, int place, int flightId, int profileId);

        void RemoveTicketPreOrder(TicketPreOrder ticketPreOrder);

        void MarkFlightTicketPreOrdersAsDeletedForUser(int flightId, int profileId);

        void AddTickets(List<Ticket> tickets);

        List<Ticket> GetTicketsForUser(int profileId);

        int GetSeatType(int planeId, int row, int place);

        List<Plane> GetAllPlanes();

        List<int> GetSeatTypesForPlane(int planeId);

        decimal GetPriceBySeatTypeId(int seatTypeId, int flightId);

        List<Flight> GetFlightsThisWeek();

        void DeletePhoto(Photo photo);
    }
}