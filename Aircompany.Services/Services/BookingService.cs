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
        private readonly string _airlinesCode;

        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _airlinesCode = ConfigurationManager.AppSettings["FlightCode"];
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public List<Flight> GetActiveFlightsByAirportIds(int departureAirportId, int arivingAirportId)
        {
            return _unitOfWork.FlightRepository.Find(x => 
                x.DepartureAirportId == departureAirportId 
                && x.ArivingAirportId == arivingAirportId
                && x.DepartureDateTime > DateTime.Now).ToList();
        }

        public Flight GetFlight(int id)
        {
            return _unitOfWork.FlightRepository.Get(id);
        }

        public List<Sector> GetSectorsByPlaneId(int planeId)
        {
            return _unitOfWork.FlightRepository.GetSectorsByPlaneId(planeId);
        }

        public bool IsTicketAbleToBook(int row, int place, int flightId)
        {
            return !_unitOfWork.FlightRepository.IsExistTicket(row, place, flightId);
        }

        public void AddTicketPreOrder(TicketPreOrder ticketPreOrder)
        {
            _unitOfWork.FlightRepository.AddTicketPreOrder(ticketPreOrder);
        }

        public List<Ticket> GetFlightTickets(int flightId)
        {
            return _unitOfWork.FlightRepository.GetFlightTickets(flightId);
        }

        public List<TicketPreOrder> GetFlightTicketPreOrdersOfOtherUsers(int flightId, int profileId)
        {
            return _unitOfWork.FlightRepository.GetFlightTicketPreOrdersOfOtherUsers(flightId, profileId);
        }

        public List<TicketPreOrder> GetFlightTicketPreOrdersForCurrentUser(int flightId, int profileId)
        {
            return _unitOfWork.FlightRepository.GetFlightTicketPreOrdersForUser(flightId, profileId);
        }

        public bool IsSeatBindedToOtherUser(int row, int place, int flightId, int profileId)
        {
            return _unitOfWork.FlightRepository.IsSeatBindedToOtherUser(row, place, flightId, profileId);
        }

        public bool IsSeatBindedByCurrnetUser(int row, int place, int flightId, int profileId)
        {
            return _unitOfWork.FlightRepository.IsSeatBindedByCurrnetUser(row, place, flightId, profileId);
        }

        public void RemoveTicketPreOrderForUser(int row, int place, int flightId, int profileId)
        {
            TicketPreOrder ticketPreOrder = _unitOfWork.FlightRepository.GetTicketPreOrderByFlightData(row, place, flightId, profileId);
            _unitOfWork.FlightRepository.RemoveTicketPreOrder(ticketPreOrder);
        }

        public void MarkTicketPreOrdersAsDeletedForUser(int flightId, int profileId)
        {
            _unitOfWork.FlightRepository.MarkFlightTicketPreOrdersAsDeletedForUser(flightId, profileId);
        }

        public void BookTickets(List<Ticket> tickets)
        {
            tickets.ForEach(ticket => ticket.Guid = Guid.NewGuid());
            _unitOfWork.FlightRepository.AddTickets(tickets);
        }

        public void SendTickets(List<NamedTicket> tickets, string serverPath, Profile profile)
        {
            List<TicketPDFModel> ticketModels = new List<TicketPDFModel>();
            int flightId = tickets.First().Ticket.FlightId;
            tickets.ForEach(ticket => ticketModels.Add(new TicketPDFModel
            {
                FlightCode = $"{_airlinesCode} {ticket.Ticket.FlightId:D4}",
                Date = ticket.Ticket.Flight.DepartureDateTime.ToLocalTime().Date,
                Time = ticket.Ticket.Flight.DepartureDateTime.ToLocalTime().TimeOfDay,
                PlaneModel = $"{ticket.Ticket.Flight.Plane.Manufacturer} {ticket.Ticket.Flight.Plane.Model}",
                DepartureAirportCode = ticket.Ticket.Flight.DepartureAirport.Code,
                DepartureCountry = ticket.Ticket.Flight.DepartureAirport.Country,
                DepartureCity = ticket.Ticket.Flight.DepartureAirport.City,
                ArivingAirportCode = ticket.Ticket.Flight.ArivingAirport.Code,
                ArivingCountry = ticket.Ticket.Flight.ArivingAirport.Country,
                ArivingCity = ticket.Ticket.Flight.ArivingAirport.City,
                Place = ticket.Ticket.Place,
                Row = ticket.Ticket.Row,
                Guid = ticket.Ticket.Guid,
                SeatTypeId = _unitOfWork.FlightRepository.GetSeatType(ticket.Ticket.Flight.PlaneId, ticket.Ticket.Row, ticket.Ticket.Place),
                HandLuggage = ticket.Ticket.Flight.HandLuggage,
                Luggage = ticket.Ticket.Flight.Luggage,
                Name = ticket.Name,
                Surname = ticket.Surname,
                PassportNumber = ticket.PassportNumber
            }));

            ticketModels.ForEach(x => x.Price = _unitOfWork.FlightRepository.GetPriceBySeatTypeId(x.SeatTypeId, flightId));

            var discount = _unitOfWork.AccountRepository.GetCurrentDiscount();
            if (discount != null)
            {
                ticketModels.ForEach(x => x.Price = (x.Price * (1 - ((decimal)discount / 100))));
            }

            List<string> pathes = tickets.Select(x => serverPath + ConfigurationManager.AppSettings[TICKETS_DIRECTORY_KEY] +
                                    $"\\Ticket-{x.Ticket.Guid}.pdf").ToList();
            ticketModels.ForEach(x => PDFManager.CreateTicket(x, serverPath));
            EmailManager.TicketEmail(pathes, profile.Email,
                $"{profile.Name} {profile.Surname}");
        }

        public List<Flight> GetFlightsThisWeek()
        {
            return _unitOfWork.FlightRepository.GetFlightsThisWeek();
        }

        public void RemoveTicketPreOrdersForUser(int flightId, int profileId)
        {
            List<TicketPreOrder> ticketPreOrders = GetFlightTicketPreOrdersForCurrentUser(flightId, profileId);
            ticketPreOrders.ForEach(x => _unitOfWork.FlightRepository.RemoveTicketPreOrder(x));
        }

        public List<Ticket> GetTicketsForUser(int profileId)
        {
            return _unitOfWork.FlightRepository.GetTicketsForUser(profileId);
        }

        public int GetSeatType(int planeId, int row, int place)
        {
            return _unitOfWork.FlightRepository.GetSeatType(planeId, row, place);
        }

        public List<Plane> GetAllPlanes()
        {
            return _unitOfWork.FlightRepository.GetAllPlanes();
        }

        public void AddFlight(Flight flight)
        {
            _unitOfWork.FlightRepository.Add(flight);
        }

        public List<int> GetSeatTypesForPlane(int planeId)
        {
            return _unitOfWork.FlightRepository.GetSeatTypesForPlane(planeId);
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