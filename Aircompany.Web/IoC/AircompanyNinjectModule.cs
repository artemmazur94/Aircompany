using Aircompany.DataAccess;
using Aircompany.DataAccess.Repositories;
using Aircompany.DataAccess.Repositories.Contracts;
using Aircompany.Services.Services;
using Aircompany.Services.Services.Contracts;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Aircompany.Web.IoC
{
    public class AircompanyNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<AircompanyContext>().ToSelf().InRequestScope();

            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            Bind<IAccountService>().To<AccountService>();
            Bind<IBookingService>().To<BookingService>();
            Bind<IAirportService>().To<AirportService>();
            Bind<IFlightService>().To<FlightService>();
            Bind<IPlaneService>().To<PlaneService>();

            Bind<IAccountRepository>().To<AccountRepository>();
            Bind<ISecurityTokenRepository>().To<SecurityTokenRepository>();
            Bind<IAirportRepository>().To<AirportRepository>();
            Bind<IFlightRepository>().To<FlightRepository>();
            Bind<IPlaneRepository>().To<PlaneRepository>();
        }
    }
}