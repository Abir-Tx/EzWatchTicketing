namespace EWT_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentAndSeatAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MethodName = c.String(),
                        Cardnum = c.Int(nullable: false),
                        Expirydate = c.DateTime(nullable: false),
                        Cvc = c.Int(nullable: false),
                        PostalCode = c.Int(nullable: false),
                        Country = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeatName = c.String(),
                        SeatType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Seats");
            DropTable("dbo.Payments");
        }
    }
}
