namespace Aircompany.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hall_to_plane : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sectors", "HallId", "dbo.Halls");
            DropForeignKey("dbo.Seances", "HallId", "dbo.Halls");
            DropIndex("dbo.Seances", new[] { "HallId" });
            DropIndex("dbo.Sectors", new[] { "HallId" });
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
                        PlanePicture = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Seances", "PlaneId", c => c.Int(nullable: false));
            AddColumn("dbo.Sectors", "PlaneId", c => c.Int(nullable: false));
            CreateIndex("dbo.Seances", "PlaneId");
            CreateIndex("dbo.Sectors", "PlaneId");
            AddForeignKey("dbo.Seances", "PlaneId", "dbo.Planes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sectors", "PlaneId", "dbo.Planes", "Id", cascadeDelete: true);
            DropColumn("dbo.Seances", "HallId");
            DropColumn("dbo.Sectors", "HallId");
            DropTable("dbo.Halls");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HallPicture = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Sectors", "HallId", c => c.Int(nullable: false));
            AddColumn("dbo.Seances", "HallId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PlaneLocalizations", "PlaneId", "dbo.Planes");
            DropForeignKey("dbo.Sectors", "PlaneId", "dbo.Planes");
            DropForeignKey("dbo.Seances", "PlaneId", "dbo.Planes");
            DropForeignKey("dbo.PlaneLocalizations", "LanguageId", "dbo.Languages");
            DropIndex("dbo.Sectors", new[] { "PlaneId" });
            DropIndex("dbo.Seances", new[] { "PlaneId" });
            DropIndex("dbo.PlaneLocalizations", new[] { "PlaneId" });
            DropIndex("dbo.PlaneLocalizations", new[] { "LanguageId" });
            DropColumn("dbo.Sectors", "PlaneId");
            DropColumn("dbo.Seances", "PlaneId");
            DropTable("dbo.Planes");
            DropTable("dbo.PlaneLocalizations");
            CreateIndex("dbo.Sectors", "HallId");
            CreateIndex("dbo.Seances", "HallId");
            AddForeignKey("dbo.Seances", "HallId", "dbo.Halls", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Sectors", "HallId", "dbo.Halls", "Id", cascadeDelete: true);
        }
    }
}
