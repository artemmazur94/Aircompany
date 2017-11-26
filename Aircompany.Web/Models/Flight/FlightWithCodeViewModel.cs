namespace Aircompany.Web.Models.Flight
{
    public class FlightWithCodeViewModel : DataAccess.Entities.Flight
    { 
        public FlightWithCodeViewModel(DataAccess.Entities.Flight x)
        {
            DepartureDateTime = x.DepartureDateTime;
            ArivingAirportId = x.ArivingAirportId;
            Id = x.Id;
            ArivingDateTime = x.ArivingDateTime;
            ArivingAirport = x.ArivingAirport;
            ArivingAirportId = x.ArivingAirportId;
            DepartureAirport = x.DepartureAirport;
            PlaneId = x.PlaneId;
            IsDeleted = x.IsDeleted;
            RemoveExecutorId = x.RemoveExecutorId;
    }

        public string Code { get; set; }
    }
}