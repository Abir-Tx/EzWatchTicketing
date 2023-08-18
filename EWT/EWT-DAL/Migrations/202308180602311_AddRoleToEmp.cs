namespace EWT_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleToEmp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "RoleId");
            AddForeignKey("dbo.Employees", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "RoleId", "dbo.Roles");
            DropIndex("dbo.Employees", new[] { "RoleId" });
            DropColumn("dbo.Employees", "RoleId");
        }
    }
}
