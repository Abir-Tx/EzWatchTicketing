namespace EWT_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketMovieRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "MovieId");
            AddForeignKey("dbo.Tickets", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "MovieId", "dbo.Movies");
            DropIndex("dbo.Tickets", new[] { "MovieId" });
            DropColumn("dbo.Tickets", "MovieId");
        }
    }
}
