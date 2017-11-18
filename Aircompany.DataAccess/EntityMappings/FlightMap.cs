using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class FlightMap : EntityTypeConfiguration<Flight>
    {
        public FlightMap()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Plane).WithMany(x => x.Flights).HasForeignKey(x => x.PlaneId);
            HasRequired(x => x.DepartureAirport).WithMany(x => x.FlightsAsDeparture).HasForeignKey(x => x.DepartureAirportId);
            HasRequired(x => x.ArivingAirport).WithMany(x => x.FlightsAsArriving).HasForeignKey(x => x.ArivingAirportId);
            HasOptional(x => x.RemoveExecutor).WithMany(x => x.RemovedFlights).HasForeignKey(x => x.RemoveExecutorId);
        }
    }
}