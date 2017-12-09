using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Aircompany.DataAccess.Entities;

namespace Aircompany.Web.Models.Booking
{
    public class PlaneSeat
    {
        [Required]
        [Display(Name = "Row: ")]
        public int Row { get; set; }
        
        [Required]
        [Display(Name = "Place: ")]
        public int Place { get; set; }

        [Required]
        [Display(Name = "Seat class: ")]
        public int Type { get; set; }

        [Required]
        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surbname: ")]
        public string Surname { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(100)]
        [Display(Name = "Passport number: ")]
        public string PassportNumber { get; set; }

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