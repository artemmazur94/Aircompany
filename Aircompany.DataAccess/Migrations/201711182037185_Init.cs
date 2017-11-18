namespace Aircompany.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(),
                        Email = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        IsBlocked = c.Boolean(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        PassportNumber = c.String(),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExternalAccounts",
                c => new
                    {
                        ExternalProviderId = c.Int(nullable: false),
                        UserIdentity = c.String(nullable: false, maxLength: 128),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExternalProviderId, t.UserIdentity })
                .ForeignKey("dbo.ExternalProviders", t => t.ExternalProviderId, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ExternalProviderId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.ExternalProviders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartureAirportId = c.Int(nullable: false),
                        ArivingAirportId = c.Int(nullable: false),
                        DepartureDateTime = c.DateTime(nullable: false),
                        ArivingDateTime = c.DateTime(nullable: false),
                        PlaneId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        RemoveExecutorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airports", t => t.ArivingAirportId, cascadeDelete: false)
                .ForeignKey("dbo.Airports", t => t.DepartureAirportId, cascadeDelete: false)
                .ForeignKey("dbo.Planes", t => t.PlaneId, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.RemoveExecutorId)
                .Index(t => t.DepartureAirportId)
                .Index(t => t.ArivingAirportId)
                .Index(t => t.PlaneId)
                .Index(t => t.RemoveExecutorId);
            
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        PhotoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photos", t => t.PhotoId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.AirportLocalizations",
                c => new
                    {
                        AirportId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.AirportId, t.LanguageId })
                .ForeignKey("dbo.Airports", t => t.AirportId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.AirportId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlaneLocalizations",
                c => new
                    {
                        LanguageId = c.Int(nullable: false),
                        PlaneId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.LanguageId, t.PlaneId })
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Planes", t => t.PlaneId, cascadeDelete: true)
                .Index(t => t.LanguageId)
                .Index(t => t.PlaneId);
            
            CreateTable(
                "dbo.Planes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(),
                        Model = c.String(),
                        MaxSpeed = c.Int(nullable: false),
                        PhotoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photos", t => t.PhotoId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        Guid = c.Guid(nullable: false),
                        Filename = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromRow = c.Int(nullable: false),
                        ToRow = c.Int(nullable: false),
                        FromPlace = c.Int(nullable: false),
                        ToPlace = c.Int(nullable: false),
                        SeatTypeId = c.Int(nullable: false),
                        PlaneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Planes", t => t.PlaneId, cascadeDelete: true)
                .ForeignKey("dbo.SeatTypeClasses", t => t.SeatTypeId, cascadeDelete: true)
                .Index(t => t.SeatTypeId)
                .Index(t => t.PlaneId);
            
            CreateTable(
                "dbo.SeatTypeClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SectorTypePrices",
                c => new
                    {
                        SeatTypeId = c.Int(nullable: false),
                        FlightId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.SeatTypeId, t.FlightId })
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .ForeignKey("dbo.SeatTypeClasses", t => t.SeatTypeId, cascadeDelete: true)
                .Index(t => t.SeatTypeId)
                .Index(t => t.FlightId);
            
            CreateTable(
                "dbo.TicketPreOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Row = c.Int(nullable: false),
                        Place = c.Int(nullable: false),
                        FlightId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.FlightId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.TicketPreOrdersDeleteds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Row = c.Int(nullable: false),
                        Place = c.Int(nullable: false),
                        FlightId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.FlightId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Row = c.Int(nullable: false),
                        Place = c.Int(nullable: false),
                        FlightId = c.Int(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        ProfileId = c.Int(nullable: false),
                        Guid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flights", t => t.FlightId, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.FlightId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.SecurityTokens",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AccountId = c.Int(nullable: false),
                        ResetRequestDateTime = c.DateTime(nullable: false),
                        IsUsed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SecurityTokens", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Tickets", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Tickets", "FlightId", "dbo.Flights");
            DropForeignKey("dbo.TicketPreOrdersDeleteds", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.TicketPreOrdersDeleteds", "FlightId", "dbo.Flights");
            DropForeignKey("dbo.TicketPreOrders", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.TicketPreOrders", "FlightId", "dbo.Flights");
            DropForeignKey("dbo.Flights", "RemoveExecutorId", "dbo.Profiles");
            DropForeignKey("dbo.Flights", "PlaneId", "dbo.Planes");
            DropForeignKey("dbo.Flights", "DepartureAirportId", "dbo.Airports");
            DropForeignKey("dbo.Flights", "ArivingAirportId", "dbo.Airports");
            DropForeignKey("dbo.Airports", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.AirportLocalizations", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.PlaneLocalizations", "PlaneId", "dbo.Planes");
            DropForeignKey("dbo.Sectors", "SeatTypeId", "dbo.SeatTypeClasses");
            DropForeignKey("dbo.SectorTypePrices", "SeatTypeId", "dbo.SeatTypeClasses");
            DropForeignKey("dbo.SectorTypePrices", "FlightId", "dbo.Flights");
            DropForeignKey("dbo.Sectors", "PlaneId", "dbo.Planes");
            DropForeignKey("dbo.Planes", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.PlaneLocalizations", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.AirportLocalizations", "AirportId", "dbo.Airports");
            DropForeignKey("dbo.ExternalAccounts", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.ExternalAccounts", "ExternalProviderId", "dbo.ExternalProviders");
            DropIndex("dbo.SecurityTokens", new[] { "AccountId" });
            DropIndex("dbo.Tickets", new[] { "ProfileId" });
            DropIndex("dbo.Tickets", new[] { "FlightId" });
            DropIndex("dbo.TicketPreOrdersDeleteds", new[] { "ProfileId" });
            DropIndex("dbo.TicketPreOrdersDeleteds", new[] { "FlightId" });
            DropIndex("dbo.TicketPreOrders", new[] { "ProfileId" });
            DropIndex("dbo.TicketPreOrders", new[] { "FlightId" });
            DropIndex("dbo.SectorTypePrices", new[] { "FlightId" });
            DropIndex("dbo.SectorTypePrices", new[] { "SeatTypeId" });
            DropIndex("dbo.Sectors", new[] { "PlaneId" });
            DropIndex("dbo.Sectors", new[] { "SeatTypeId" });
            DropIndex("dbo.Planes", new[] { "PhotoId" });
            DropIndex("dbo.PlaneLocalizations", new[] { "PlaneId" });
            DropIndex("dbo.PlaneLocalizations", new[] { "LanguageId" });
            DropIndex("dbo.AirportLocalizations", new[] { "LanguageId" });
            DropIndex("dbo.AirportLocalizations", new[] { "AirportId" });
            DropIndex("dbo.Airports", new[] { "PhotoId" });
            DropIndex("dbo.Flights", new[] { "RemoveExecutorId" });
            DropIndex("dbo.Flights", new[] { "PlaneId" });
            DropIndex("dbo.Flights", new[] { "ArivingAirportId" });
            DropIndex("dbo.Flights", new[] { "DepartureAirportId" });
            DropIndex("dbo.ExternalAccounts", new[] { "ProfileId" });
            DropIndex("dbo.ExternalAccounts", new[] { "ExternalProviderId" });
            DropIndex("dbo.Accounts", new[] { "ProfileId" });
            DropTable("dbo.SecurityTokens");
            DropTable("dbo.Tickets");
            DropTable("dbo.TicketPreOrdersDeleteds");
            DropTable("dbo.TicketPreOrders");
            DropTable("dbo.SectorTypePrices");
            DropTable("dbo.SeatTypeClasses");
            DropTable("dbo.Sectors");
            DropTable("dbo.Photos");
            DropTable("dbo.Planes");
            DropTable("dbo.PlaneLocalizations");
            DropTable("dbo.Languages");
            DropTable("dbo.AirportLocalizations");
            DropTable("dbo.Airports");
            DropTable("dbo.Flights");
            DropTable("dbo.ExternalProviders");
            DropTable("dbo.ExternalAccounts");
            DropTable("dbo.Profiles");
            DropTable("dbo.Accounts");
        }
    }
}
