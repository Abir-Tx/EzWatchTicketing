namespace EWT_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminRoleId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Admins", "RoleId");
            AddForeignKey("dbo.Admins", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "RoleId", "dbo.Roles");
            DropIndex("dbo.Admins", new[] { "RoleId" });
            DropColumn("dbo.Admins", "RoleId");
        }
    }
}
