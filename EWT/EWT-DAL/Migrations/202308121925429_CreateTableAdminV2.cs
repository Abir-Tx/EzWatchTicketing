namespace EWT_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableAdminV2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "Admins");
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Admins", "Email", c => c.String());
            AlterColumn("dbo.Admins", "Password", c => c.String());
            AlterColumn("dbo.Admins", "Salary", c => c.Double(nullable: false));
            DropColumn("dbo.Admins", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Admins", "Salary", c => c.Double());
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Admins", "Email", c => c.String(nullable: false, maxLength: 100));
            DropTable("dbo.Users");
            RenameTable(name: "dbo.Admins", newName: "Users");
        }
    }
}
