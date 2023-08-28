namespace EWT_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changehallandaddbookingtomodelcs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AvailablSeats = c.Int(nullable: false),
                        BookingTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bookings");
        }
    }
}
