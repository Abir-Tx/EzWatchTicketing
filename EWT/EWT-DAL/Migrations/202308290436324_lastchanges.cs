namespace EWT_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Halls", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Halls", "MovieId");
            AddForeignKey("dbo.Halls", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Halls", "MovieId", "dbo.Movies");
            DropIndex("dbo.Halls", new[] { "MovieId" });
            DropColumn("dbo.Halls", "MovieId");
        }
    }
}
