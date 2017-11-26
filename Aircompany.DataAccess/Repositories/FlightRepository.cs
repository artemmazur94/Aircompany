using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Aircompany.DataAccess.Entities;
using Aircompany.DataAccess.Repositories.Contracts;

namespace Aircompany.DataAccess.Repositories
{
    public class FlightRepository : GenericRepositrory<Flight>, IFlightRepository
    {
        private AircompanyContext FlightContext => Context;

        public FlightRepository(AircompanyContext context) : base(context)
        {
        }

        public List<Sector> GetSectorsByPlaneId(int planeId)
        {
            return FlightContext.Sectors.Where(x => x.PlaneId == planeId).ToList();
        }

        public bool IsExistTicketPreOrder(int row, int place, int flightId)
        {
            return FlightContext.TicketPreOrders.FirstOrDefault(x =>
                x.Place == place &&
                x.Row == row &&
                x.FlightId == flightId) != null;
        }

        public bool IsExistTicket(int row, int place, int flightId)
        {
            return FlightContext.Tickets.FirstOrDefault(x =>
                x.Place == place &&
                x.Row == row &&
                x.FlightId == flightId) != null;
        }

        public void AddTicketPreOrder(TicketPreOrder ticketPreOrder)
        {
            FlightContext.TicketPreOrders.Add(ticketPreOrder);
        }

        public List<Ticket> GetFlightTickets(int flightId)
        {
            return FlightContext.Tickets.Where(x => x.FlightId == flightId).ToList();
        }

        public List<TicketPreOrder> GetFlightTicketPreOrdersOfOtherUsers(int flightId, int profileId)
        {
            return FlightContext.TicketPreOrders.Where(x =>
                x.FlightId == flightId &&
                x.ProfileId != profileId).ToList();
        }

        public List<TicketPreOrder> GetFlightTicketPreOrdersForUser(int flightId, int profileId)
        {
            return FlightContext.TicketPreOrders.Where(x =>
                x.FlightId == flightId &&
                x.ProfileId == profileId).ToList();
        }

        public bool IsSeatBindedToOtherUser(int row, int place, int flightId, int profileId)
        {
            return FlightContext.TicketPreOrders.FirstOrDefault(x =>
                x.FlightId == flightId &&
                x.Place == place &&
                x.Row == row &&
                x.ProfileId != profileId) != null;
        }

        public bool IsSeatBindedByCurrnetUser(int row, int place, int flightId, int profileId)
        {
            return FlightContext.TicketPreOrders.FirstOrDefault(x =>
                x.ProfileId == profileId &&
                x.FlightId == flightId &&
                x.Row == row &&
                x.Place == place) != null;
        }

        public TicketPreOrder GetTicketPreOrderByFlightData(int row, int place, int flightId, int profileId)
        {
            return FlightContext.TicketPreOrders.FirstOrDefault(x =>
                x.Row == row &&
                x.Place == place &&
                x.FlightId == flightId &&
                x.ProfileId == profileId);
        }

        public void RemoveTicketPreOrder(TicketPreOrder ticketPreOrder)
        {
            FlightContext.TicketPreOrders.Remove(ticketPreOrder);
        }

        public void MarkFlightTicketPreOrdersAsDeletedForUser(int flightId, int profileId)
        {
            List<TicketPreOrder> ticketPreOrders = GetFlightTicketPreOrdersForUser(flightId, profileId);
            FlightContext.TicketPreOrders.RemoveRange(ticketPreOrders);
            var ticketPreOrdersDeleted = new List<TicketPreOrdersDeleted>();
            ticketPreOrders.ForEach(x => ticketPreOrdersDeleted.Add(new TicketPreOrdersDeleted()
            {
                ProfileId = profileId,
                DateTime = DateTime.Now,
                Place = x.Place,
                Row = x.Row,
                FlightId = x.FlightId
            }));
            FlightContext.TicketPreOrdersDeleted.AddRange(ticketPreOrdersDeleted);
        }

        public void AddTickets(List<Ticket> tickets)
        {
            FlightContext.Tickets.AddRange(tickets);
        }

        public List<Ticket> GetTicketsForUser(int profileId)
        {
            return FlightContext.Tickets.Where(x => x.ProfileId == profileId).Include(x => x.Flight).ToList();
        }

        public int GetSeatType(int planeId, int row, int place)
        {
            var sector = FlightContext.Sectors
                .FirstOrDefault(x => x.PlaneId == planeId
                    && x.FromRow <= row 
                    && x.ToRow >= row 
                    && x.FromPlace <= place 
                    && x.ToPlace >= place);

            if (sector != null)
            {
                return sector.SeatTypeId;
            }

            throw new Exception($"Invalid data input data. PlaneId:{planeId}, row:{row}, place:{place}");
        }

        public List<Plane> GetAllPlanes()
        {
            return FlightContext.Planes.ToList();
        }

        public List<int> GetSeatTypesForPlane(int planeId)
        {
            return (from sector in FlightContext.Sectors.Where(x => x.PlaneId == planeId)
                    select sector.SeatTypeId).Distinct().ToList();
        }

        public decimal GetPriceBySeatTypeId(int seatTypeId, int flightId)
        {
            var sectorTypePrice = FlightContext.SectorTypePrices
                .FirstOrDefault(x => x.FlightId == flightId && x.SeatTypeId == seatTypeId);

            if (sectorTypePrice != null)
            {
                return sectorTypePrice.Price;
            }

            throw new Exception($"Invalid data input data. SeatTypeId:{seatTypeId}, flightId:{flightId}");
        }

        public List<Flight> GetFlightsThisWeek()
        {
            var dateFrom = DateTime.Now;
            var dateTo = dateFrom.AddDays(7);

            return FlightContext.Flights.Where(x => 
                x.DepartureDateTime >= dateFrom 
                && x.DepartureDateTime <= dateTo).ToList();
        }
    }
}