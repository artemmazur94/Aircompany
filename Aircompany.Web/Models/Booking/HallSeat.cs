﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Aircompany.DataAccess.Entities;

namespace Aircompany.Web.Models.Booking
{
    public class PlaneSeat
    {
        [Display(Name = "Row: ")]
        public int Row { get; set; }
        
        [Display(Name = "Place: ")]
        public int Place { get; set; }

        [Display(Name = "Seat type: ")]
        public int Type { get; set; }

        public static List<PlaneSeat> GetAllSeats(List<Ticket> tickets, List<TicketPreOrder> ticketPreOrders)
        {
            List<PlaneSeat> seats = tickets.Select(x => new PlaneSeat
            {
                Row = x.Row,
                Place = x.Place
            }).ToList();

            seats.AddRange(ticketPreOrders.Distinct().Select(x => new PlaneSeat
            {
                Row = x.Row,
                Place = x.Place
            }));

            return seats;
        }

        public static List<PlaneSeat> GetAllSeats(List<TicketPreOrder> ticketPreOrders)
        {
            return ticketPreOrders.Select(x => new PlaneSeat
            {
                Row = x.Row,
                Place = x.Place
            }).ToList();
        }

        public static void SetSeatTypes(List<PlaneSeat> selectedSeats, List<Sector> sectors)
        {
            selectedSeats.ForEach( x =>
                    x.Type =
                        sectors.First( z =>
                                x.Row >= z.FromRow && 
                                x.Row <= z.ToRow && 
                                x.Place >= z.FromPlace && 
                                x.Place <= z.ToPlace)
                            .SeatTypeClass.Id);
        }
    }
}