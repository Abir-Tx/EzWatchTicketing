namespace EWT_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foodandorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "MovieID", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "SeatId", c => c.Int(nullable: false));
            AddColumn("dbo.Halls", "TotalSeats", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "MovieID");
            CreateIndex("dbo.Bookings", "SeatId");
            AddForeignKey("dbo.Bookings", "MovieID", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "SeatId", "dbo.Seats", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "SeatId", "dbo.Seats");
            DropForeignKey("dbo.Bookings", "MovieID", "dbo.Movies");
            DropIndex("dbo.Bookings", new[] { "SeatId" });
            DropIndex("dbo.Bookings", new[] { "MovieID" });
            DropColumn("dbo.Halls", "TotalSeats");
            DropColumn("dbo.Bookings", "SeatId");
            DropColumn("dbo.Bookings", "MovieID");
        }
    }
}
