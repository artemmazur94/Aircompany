namespace Aircompany.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        CommentText = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Length = c.Int(nullable: false),
                        GenreId = c.Int(),
                        ReleaseDate = c.DateTime(nullable: false),
                        DirectorId = c.Int(),
                        Rating = c.Double(),
                        PhotoId = c.Int(),
                        VideoLink = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        RemoveExecutorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.DirectorId)
                .ForeignKey("dbo.Genres", t => t.GenreId)
                .ForeignKey("dbo.Photos", t => t.PhotoId)
                .ForeignKey("dbo.Profiles", t => t.RemoveExecutorId)
                .Index(t => t.GenreId)
                .Index(t => t.DirectorId)
                .Index(t => t.PhotoId)
                .Index(t => t.RemoveExecutorId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photos", t => t.PhotoId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.PersonLocalizations",
                c => new
                    {
                        LanguageId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.LanguageId, t.PersonId })
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.LanguageId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GenreLocalizations",
                c => new
                    {
                        GenreId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.GenreId, t.LanguageId })
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieLocalizations",
                c => new
                    {
                        LanguageId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.LanguageId, t.MovieId })
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.LanguageId)
                .Index(t => t.MovieId);
            
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
                "dbo.Ratings",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.ProfileId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Seances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        HallId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.HallId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HallPicture = c.Binary(),
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
                        HallId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .ForeignKey("dbo.SeatTypes", t => t.SeatTypeId, cascadeDelete: true)
                .Index(t => t.SeatTypeId)
                .Index(t => t.HallId);
            
            CreateTable(
                "dbo.SeatTypes",
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
                        SeanceId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.SeatTypeId, t.SeanceId })
                .ForeignKey("dbo.Seances", t => t.SeanceId, cascadeDelete: true)
                .ForeignKey("dbo.SeatTypes", t => t.SeatTypeId, cascadeDelete: true)
                .Index(t => t.SeatTypeId)
                .Index(t => t.SeanceId);
            
            CreateTable(
                "dbo.TicketPreOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Row = c.Int(nullable: false),
                        Place = c.Int(nullable: false),
                        SeanceId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .ForeignKey("dbo.Seances", t => t.SeanceId, cascadeDelete: true)
                .Index(t => t.SeanceId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.TicketPreOrdersDeleteds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Row = c.Int(nullable: false),
                        Place = c.Int(nullable: false),
                        SeanceId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .ForeignKey("dbo.Seances", t => t.SeanceId, cascadeDelete: true)
                .Index(t => t.SeanceId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Row = c.Int(nullable: false),
                        Place = c.Int(nullable: false),
                        SeanceId = c.Int(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        ProfileId = c.Int(nullable: false),
                        Guid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.ProfileId, cascadeDelete: true)
                .ForeignKey("dbo.Seances", t => t.SeanceId, cascadeDelete: true)
                .Index(t => t.SeanceId)
                .Index(t => t.ProfileId);
            
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
            
            CreateTable(
                "dbo.PersonMovies",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Movie_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Movie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SecurityTokens", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.ExternalAccounts", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.ExternalAccounts", "ExternalProviderId", "dbo.ExternalProviders");
            DropForeignKey("dbo.Comments", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Comments", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Tickets", "SeanceId", "dbo.Seances");
            DropForeignKey("dbo.Tickets", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.TicketPreOrdersDeleteds", "SeanceId", "dbo.Seances");
            DropForeignKey("dbo.TicketPreOrdersDeleteds", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.TicketPreOrders", "SeanceId", "dbo.Seances");
            DropForeignKey("dbo.TicketPreOrders", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Seances", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Seances", "HallId", "dbo.Halls");
            DropForeignKey("dbo.Sectors", "SeatTypeId", "dbo.SeatTypes");
            DropForeignKey("dbo.SectorTypePrices", "SeatTypeId", "dbo.SeatTypes");
            DropForeignKey("dbo.SectorTypePrices", "SeanceId", "dbo.Seances");
            DropForeignKey("dbo.Sectors", "HallId", "dbo.Halls");
            DropForeignKey("dbo.Movies", "RemoveExecutorId", "dbo.Profiles");
            DropForeignKey("dbo.Ratings", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Ratings", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Movies", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Movies", "DirectorId", "dbo.People");
            DropForeignKey("dbo.People", "PhotoId", "dbo.Photos");
            DropForeignKey("dbo.PersonLocalizations", "PersonId", "dbo.People");
            DropForeignKey("dbo.PersonLocalizations", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.MovieLocalizations", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieLocalizations", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.GenreLocalizations", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.GenreLocalizations", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.PersonMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.PersonMovies", "Person_Id", "dbo.People");
            DropIndex("dbo.PersonMovies", new[] { "Movie_Id" });
            DropIndex("dbo.PersonMovies", new[] { "Person_Id" });
            DropIndex("dbo.SecurityTokens", new[] { "AccountId" });
            DropIndex("dbo.ExternalAccounts", new[] { "ProfileId" });
            DropIndex("dbo.ExternalAccounts", new[] { "ExternalProviderId" });
            DropIndex("dbo.Tickets", new[] { "ProfileId" });
            DropIndex("dbo.Tickets", new[] { "SeanceId" });
            DropIndex("dbo.TicketPreOrdersDeleteds", new[] { "ProfileId" });
            DropIndex("dbo.TicketPreOrdersDeleteds", new[] { "SeanceId" });
            DropIndex("dbo.TicketPreOrders", new[] { "ProfileId" });
            DropIndex("dbo.TicketPreOrders", new[] { "SeanceId" });
            DropIndex("dbo.SectorTypePrices", new[] { "SeanceId" });
            DropIndex("dbo.SectorTypePrices", new[] { "SeatTypeId" });
            DropIndex("dbo.Sectors", new[] { "HallId" });
            DropIndex("dbo.Sectors", new[] { "SeatTypeId" });
            DropIndex("dbo.Seances", new[] { "MovieId" });
            DropIndex("dbo.Seances", new[] { "HallId" });
            DropIndex("dbo.Ratings", new[] { "ProfileId" });
            DropIndex("dbo.Ratings", new[] { "MovieId" });
            DropIndex("dbo.MovieLocalizations", new[] { "MovieId" });
            DropIndex("dbo.MovieLocalizations", new[] { "LanguageId" });
            DropIndex("dbo.GenreLocalizations", new[] { "LanguageId" });
            DropIndex("dbo.GenreLocalizations", new[] { "GenreId" });
            DropIndex("dbo.PersonLocalizations", new[] { "PersonId" });
            DropIndex("dbo.PersonLocalizations", new[] { "LanguageId" });
            DropIndex("dbo.People", new[] { "PhotoId" });
            DropIndex("dbo.Movies", new[] { "RemoveExecutorId" });
            DropIndex("dbo.Movies", new[] { "PhotoId" });
            DropIndex("dbo.Movies", new[] { "DirectorId" });
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropIndex("dbo.Comments", new[] { "ProfileId" });
            DropIndex("dbo.Comments", new[] { "MovieId" });
            DropIndex("dbo.Accounts", new[] { "ProfileId" });
            DropTable("dbo.PersonMovies");
            DropTable("dbo.SecurityTokens");
            DropTable("dbo.ExternalProviders");
            DropTable("dbo.ExternalAccounts");
            DropTable("dbo.Tickets");
            DropTable("dbo.TicketPreOrdersDeleteds");
            DropTable("dbo.TicketPreOrders");
            DropTable("dbo.SectorTypePrices");
            DropTable("dbo.SeatTypes");
            DropTable("dbo.Sectors");
            DropTable("dbo.Halls");
            DropTable("dbo.Seances");
            DropTable("dbo.Ratings");
            DropTable("dbo.Photos");
            DropTable("dbo.MovieLocalizations");
            DropTable("dbo.Genres");
            DropTable("dbo.GenreLocalizations");
            DropTable("dbo.Languages");
            DropTable("dbo.PersonLocalizations");
            DropTable("dbo.People");
            DropTable("dbo.Movies");
            DropTable("dbo.Comments");
            DropTable("dbo.Profiles");
            DropTable("dbo.Accounts");
        }
    }
}
