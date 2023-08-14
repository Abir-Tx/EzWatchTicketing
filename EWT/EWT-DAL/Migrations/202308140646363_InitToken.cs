namespace EWT_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitToken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenKey = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Tokens");
        }
    }
}
