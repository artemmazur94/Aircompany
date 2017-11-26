using System.Collections.Generic;
using System.Linq;
using Aircompany.DataAccess.Entities;
using Aircompany.DataAccess.Enums;

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
            if (!context.Profiles.Any())
            {
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
                context.SaveChanges();
            }

            if (!context.Languages.Any())
            {
                context.Languages.Add(new Language {LanguageCode = "EN"});
                context.SaveChanges();
            }

            if (!context.ExternalProviders.Any())
            {
                context.ExternalProviders.AddRange(new List<ExternalProvider>
                {
                    new ExternalProvider {Id = 1, Name = "Facebook"},
                    new ExternalProvider {Id = 2, Name = "Google"}
                });
            }

            if (!context.SeatTypeClasses.Any())
            {
                context.SeatTypeClasses.AddRange(new List<SeatTypeClass>
                {
                    new SeatTypeClass {Type = SeatType.First.ToString()},
                    new SeatTypeClass {Type = SeatType.Business.ToString()},
                    new SeatTypeClass {Type = SeatType.Econom.ToString()}
                });
                context.SaveChanges();
            }

            // airports

            if (!context.Airports.Any())
            {
                context.Airports.AddRange(new List<Airport>
                {
                    new Airport
                    {
                        Code = "KPB",
                        City = "Kyiv",
                        Country = "Ukraine",
                        PhotoId = null,
                        AirportLocalizations = new List<AirportLocalization>
                        {
                            new AirportLocalization
                            {
                                LanguageId = context.Languages.First(x => x.LanguageCode == "EN").Id,
                                Name = "Boryspil International Airport",
                                Description = "Boryspil International Airport is an international airport in Boryspil, 29 km (18 mi) east of Kiev, the capital of Ukraine. It is the country's largest airport, serving 65% of its passenger air traffic, including all its intercontinental flights and a majority of international flights. It is one of two passenger airports that serve Kiev along with the smaller Zhulyany Airport. Boryspil International Airport is a member of Airports Council International."
                            }
                        }
                    },
                    new Airport
                    {
                        Code = "DNK",
                        City = "Dnipro",
                        Country = "Ukraine",
                        PhotoId = null,
                        AirportLocalizations = new List<AirportLocalization>
                        {
                            new AirportLocalization
                            {
                                LanguageId = context.Languages.First(x => x.LanguageCode == "EN").Id,
                                Name = "Dnipropetrovsk International Airport",
                                Description = "Dnipropetrovsk International Airport is an airport serving Dnipro, a city in Dnipropetrovsk Oblast, Ukraine. It is located 15 kilometres (8 NM) southeast from the city center."
                            }
                        }
                    },
                    new Airport
                    {
                        Code = "DOC",
                        City = "Donetsk",
                        Country = "Ukraine",
                        PhotoId = null,
                        AirportLocalizations = new List<AirportLocalization>
                        {
                            new AirportLocalization
                            {
                                LanguageId = context.Languages.First(x => x.LanguageCode == "EN").Id,
                                Name = "Donetsk Sergey Prokofiev International Airport",
                                Description = "Donetsk Sergey Prokofiev International Airport is a nonoperational airport located 10 km (6.2 mi) northwest of Donetsk, Ukraine, that was destroyed in 2014 during the War in Donbass. It was built in the 1940s and 1950s and rebuilt in 1973 and again from 2011 to 2012. The airport is named for 20th-century composer Sergei Prokofiev, who was a native of Donetsk Oblast."
                            }
                        }
                    }
                });
                context.SaveChanges();
            }

            // planes

            if (!context.Planes.Any())
            {
                context.Planes.AddRange(new List<Plane>
                {
                    new Plane
                    {
                        Manufacturer = "Airbus",
                        Model = "A320neo",
                        PhotoId = null,
                        MaxSpeed = 890,
                        PlaneLocalizations = new List<PlaneLocalization>
                        {
                            new PlaneLocalization
                            {
                                LanguageId = context.Languages.First(x => x.LanguageCode == "EN").Id,
                                Name = "Airbus A320neo",
                                Description = "The Airbus A320neo family is a development of the A320 family of narrow-body airliners, launched on 1 December 2010 by Airbus. They are essentially a re-engine; neo stands for new engine option, with a choice of CFM International LEAP-1A or Pratt & Whitney PW1000G engines. The original family is now called A320ceo, for current engine option."
                            }
                        },
                        Sectors = new List<Sector>
                        {
                            new Sector
                            {
                                SeatTypeId =context.SeatTypeClasses.First(x => x.Type == SeatType.First.ToString()).Id,
                                FromPlace = 1,
                                ToPlace = 8,
                                FromRow = 1,
                                ToRow = 5
                            },
                            new Sector
                            {
                                SeatTypeId =context.SeatTypeClasses.First(x => x.Type == SeatType.Econom.ToString()).Id,
                                FromPlace = 1,
                                ToPlace = 8,
                                FromRow = 6,
                                ToRow = 15
                            }
                        }
                    },
                    new Plane
                    {
                        Manufacturer = "Boeing",
                        Model = "737 MAX 10",
                        PhotoId = null,
                        MaxSpeed = 840,
                        PlaneLocalizations = new List<PlaneLocalization>
                        {
                            new PlaneLocalization
                            {
                                LanguageId = context.Languages.First(x => x.LanguageCode == "EN").Id,
                                Name = "Boeing 737 MAX 10",
                                Description = "The Boeing 737 MAX is an American narrow-body aircraft series designed and produced by Boeing Commercial Airplanes as the fourth generation of the Boeing 737, succeeding the Boeing 737 Next Generation (NG). The program was launched on August 30, 2011. The first flight was on January 29, 2016. It gained FAA certification on March 9, 2017. The first delivery was a MAX 8 on May 6, 2017 to Malindo Air, which debuted it on May 22, 2017."
                            }
                        },
                        Sectors = new List<Sector>
                        {
                            new Sector
                            {
                                SeatTypeId =context.SeatTypeClasses.First(x => x.Type == SeatType.First.ToString()).Id,
                                FromPlace = 1,
                                ToPlace = 6,
                                FromRow = 1,
                                ToRow = 11
                            },
                            new Sector
                            {
                                SeatTypeId =context.SeatTypeClasses.First(x => x.Type == SeatType.Business.ToString()).Id,
                                FromPlace = 1,
                                ToPlace = 8,
                                FromRow = 12,
                                ToRow = 15
                            },
                            new Sector
                            {
                                SeatTypeId =context.SeatTypeClasses.First(x => x.Type == SeatType.Econom.ToString()).Id,
                                FromPlace = 1,
                                ToPlace = 10,
                                FromRow = 16,
                                ToRow = 20
                            }
                        }
                    },
                    new Plane
                    {
                        Manufacturer = "Comac",
                        Model = "C919",
                        PhotoId = null,
                        MaxSpeed = 940,
                        PlaneLocalizations = new List<PlaneLocalization>
                        {
                            new PlaneLocalization
                            {
                                LanguageId = context.Languages.First(x => x.LanguageCode == "EN").Id,
                                Name = "Comac C919",
                                Description = "The Comac C919 is a narrow-body twinjet airliner developed by Chinese aerospace manufacturer Comac. The programme was launched in 2008 and production of the prototype began in December 2011. It rolled out on 2 November 2015 and first flew on 5 May 2017, for a planned introduction in 2020. The aircraft is mainly made out of aluminium. It is powered by CFM International LEAP turbofan engines and can carry 156 to 168 passengers in a usual operating configuration up to 3,000 nautical miles (5,555 km). It is intended to compete with the Boeing 737 MAX and Airbus A320neo. The last purchase agreements on 19 September 2017 brought the order book to 730 from 27 leasing companies or airlines, mostly Chinese although American engine provider GE has 20 commitments."
                            }
                        },
                        Sectors = new List<Sector>
                        {
                            new Sector
                            {
                                SeatTypeId =context.SeatTypeClasses.First(x => x.Type == SeatType.Econom.ToString()).Id,
                                FromPlace = 1,
                                ToPlace = 10,
                                FromRow = 1,
                                ToRow = 12
                            }
                        }
                    },
                    new Plane
                    {
                        Manufacturer = "Antonov",
                        Model = "148",
                        PhotoId = null,
                        MaxSpeed = 870,
                        PlaneLocalizations = new List<PlaneLocalization>
                        {
                            new PlaneLocalization
                            {
                                LanguageId = context.Languages.First(x => x.LanguageCode == "EN").Id,
                                Name = "An-148",
                                Description = "The Antonov An-148 is a regional jet airliner designed by the Ukrainian Antonov company and produced by Antonov itself and, until 2017, also on outsource by Russia's Voronezh Aircraft Production Association. Development of the aircraft was started in the 1990s, and the maiden flight took place on 17 December 2004. The aircraft completed its certification programme on 26 February 2007. The An-148 has a maximum range of 2,100–4,400 km (1,100–2,400 nmi; 1,300–2,700 mi) and is able to carry 68–85 passengers, depending on the configuration."
                            }
                        },
                        Sectors = new List<Sector>
                        {
                            new Sector
                            {
                                SeatTypeId =context.SeatTypeClasses.First(x => x.Type == SeatType.Business.ToString()).Id,
                                FromPlace = 1,
                                ToPlace = 6,
                                FromRow = 1,
                                ToRow = 4
                            },
                            new Sector
                            {
                                SeatTypeId =context.SeatTypeClasses.First(x => x.Type == SeatType.Econom.ToString()).Id,
                                FromPlace = 1,
                                ToPlace = 8,
                                FromRow = 5,
                                ToRow = 12
                            }
                        }
                    }
                });
                context.SaveChanges();
            }

            context.SaveChanges();

            // todo: call skrip to feed DB with data

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
