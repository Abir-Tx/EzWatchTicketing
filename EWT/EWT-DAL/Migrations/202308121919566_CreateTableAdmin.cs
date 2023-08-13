namespace EWT_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Address", c => c.String());
            AddColumn("dbo.Users", "Salary", c => c.Double());
            AddColumn("dbo.Users", "City", c => c.String());
            AddColumn("dbo.Users", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Discriminator");
            DropColumn("dbo.Users", "City");
            DropColumn("dbo.Users", "Salary");
            DropColumn("dbo.Users", "Address");
        }
    }
}
