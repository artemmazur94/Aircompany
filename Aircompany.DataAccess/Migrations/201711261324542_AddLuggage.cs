namespace Aircompany.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLuggage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "HandLuggage", c => c.Int(nullable: false, defaultValue: 5));
            AddColumn("dbo.Flights", "Luggage", c => c.Int(nullable: false, defaultValue: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "Luggage");
            DropColumn("dbo.Flights", "HandLuggage");
        }
    }
}
