using System.Linq;
using Aircompany.DataAccess.Entities;
using EntityFramework.Extensions;

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
            context.Profiles.Where(x => x.Email == "artemmazur94@gmail.com").Delete();

            context.Languages.Add(new Language {LanguageCode = "EN"});

            context.Accounts.Add(new Account
            {
                Id = 1,
                Profile = new Profile
                {
                    Email = "artemmazur94@gmail.com",
                    IsAdmin = true,
                    IsBlocked = false,
                    Name = "admin",
                    Surname = "admin"
                },
                Login = "admin",
                Password = "GidqPxQsKQiL7Gbrq0tTTQ==", // 123123123
                Salt = "at/euHaa5Rt8taJZFvIENw=="
            });

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
