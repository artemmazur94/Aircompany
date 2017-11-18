using System.Data.Entity;
using Aircompany.DataAccess.Entities;
using Aircompany.DataAccess.EntityMappings;

namespace Aircompany.DataAccess
{
    public class AircompanyContext : DbContext
    {
        public AircompanyContext() : base("name=AircompanyContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new ExternalAccountMap());
            modelBuilder.Configurations.Add(new ExternalProviderMap());
            modelBuilder.Configurations.Add(new GenreMap());
            modelBuilder.Configurations.Add(new GenreLocalizationMap());
            modelBuilder.Configurations.Add(new PlaneMap());
            modelBuilder.Configurations.Add(new PlaneLocalizationMap());
            modelBuilder.Configurations.Add(new LanguageMap());
            modelBuilder.Configurations.Add(new MovieMap());
            modelBuilder.Configurations.Add(new MovieLocalizationMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new PersonLocalizationMap());
            modelBuilder.Configurations.Add(new PhotoMap());
            modelBuilder.Configurations.Add(new ProfileMap());
            modelBuilder.Configurations.Add(new RatingMap());
            modelBuilder.Configurations.Add(new SeanceMap());
            modelBuilder.Configurations.Add(new SeatTypeMap());
            modelBuilder.Configurations.Add(new SectorMap());
            modelBuilder.Configurations.Add(new SectorTypePriceMap());
            modelBuilder.Configurations.Add(new SecurityTokenMap());
            modelBuilder.Configurations.Add(new TicketMap());
            modelBuilder.Configurations.Add(new TicketPreOrderMap());
            modelBuilder.Configurations.Add(new TicketPreOrdersDeletedMap());
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ExternalAccount> ExternalAccounts { get; set; }
        public virtual DbSet<ExternalProvider> ExternalProviders { get; set; }
        public virtual DbSet<GenreLocalization> GenreLocalizations { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<MovieLocalization> MovieLocalizations { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<PersonLocalization> PersonLocalizations { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Seance> Seances { get; set; }
        public virtual DbSet<SeatTypeClass> SeatTypeClasses { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<SectorTypePrice> SectorTypePrices { get; set; }
        public virtual DbSet<SecurityToken> SecurityTokens { get; set; }
        public virtual DbSet<TicketPreOrder> TicketPreOrders { get; set; }
        public virtual DbSet<TicketPreOrdersDeleted> TicketPreOrdersDeleted { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
    }
}