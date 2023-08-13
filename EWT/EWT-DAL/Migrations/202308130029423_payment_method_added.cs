namespace EWT_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class payment_method_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PayMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Payments", "payId", c => c.Int(nullable: false));
            AddColumn("dbo.Seats", "HallId", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "Country", c => c.String());
            CreateIndex("dbo.Seats", "HallId");
            CreateIndex("dbo.Payments", "payId");
            AddForeignKey("dbo.Seats", "HallId", "dbo.Halls", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "payId", "dbo.PayMethods", "Id", cascadeDelete: true);
            DropColumn("dbo.Payments", "MethodName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "MethodName", c => c.String());
            DropForeignKey("dbo.Payments", "payId", "dbo.PayMethods");
            DropForeignKey("dbo.Seats", "HallId", "dbo.Halls");
            DropIndex("dbo.Payments", new[] { "payId" });
            DropIndex("dbo.Seats", new[] { "HallId" });
            AlterColumn("dbo.Payments", "Country", c => c.Int(nullable: false));
            DropColumn("dbo.Seats", "HallId");
            DropColumn("dbo.Payments", "payId");
            DropTable("dbo.PayMethods");
        }
    }
}
