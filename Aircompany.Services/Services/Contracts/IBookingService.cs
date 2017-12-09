using System;
using System.Collections.Generic;
using Aircompany.DataAccess.Entities;
using Aircompany.Services.Models;

namespace Aircompany.Services.Services.Contracts
{
    public interface IBookingService : IDisposable
    {
        void Commit();

        List<Flight> GetActiveFlightsByAirportIds(int departureAirportId, int arivingAirportId);

        Flight GetFlight(int id);

        List<Sector> GetSectorsByPlaneId(int planeId);

        bool IsTicketAbleToBook(int row, int place, int flightId);

        void AddTicketPreOrder(TicketPreOrder ticketPreOrder);

        List<Ticket> GetFlightTickets(int flightId);

        List<TicketPreOrder> GetFlightTicketPreOrdersOfOtherUsers(int flightId, int profileId);

        List<TicketPreOrder> GetFlightTicketPreOrdersForCurrentUser(int flightId, int profileId);

        bool IsSeatBindedToOtherUser(int row, int place, int flightId, int profileId);

        bool IsSeatBindedByCurrnetUser(int row, int place, int flightId, int profileId);

        void RemoveTicketPreOrderForUser(int row, int place, int seeanceId, int profileId);

        void MarkTicketPreOrdersAsDeletedForUser(int flightId, int profileId);

        void BookTickets(List<Ticket> tickets);

        void RemoveTicketPreOrdersForUser(int flightId, int profileId);

        List<Ticket> GetTicketsForUser(int profileId);

        int GetSeatType(int planeId, int row, int place);

        List<Plane> GetAllPlanes();

        void AddFlight(Flight flight);

        List<int> GetSeatTypesForPlane(int planeId);

        void SendTickets(List<NamedTicket> tickets, string serverPath, Profile profile);

        List<Flight> GetFlightsThisWeek();
    }
}