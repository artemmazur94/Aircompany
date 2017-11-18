using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AircompanyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AircompanyContext context)
        {
            context.Languages.Add(new Language {LanguageCode = "EN"});

            // airports

            // planes

            // sectors

            context.SaveChanges();

            // todo: call skrip to feed DB with data

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
