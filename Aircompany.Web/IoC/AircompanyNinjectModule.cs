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
            Bind<IGenreService>().To<GenreService>();
            Bind<IMovieService>().To<MovieService>();
            Bind<IPersonService>().To<PersonService>();

            Bind<IAccountRepository>().To<AccountRepository>();
            Bind<IMovieRepository>().To<MovieRepository>();
            Bind<ISecurityTokenRepository>().To<SecurityTokenRepository>();
            Bind<IGenreRepository>().To<GenreRepository>();
            Bind<IPersonRepository>().To<PersonRepository>();
            Bind<ISeanceRepository>().To<SeanceRepository>();
        }
    }
}