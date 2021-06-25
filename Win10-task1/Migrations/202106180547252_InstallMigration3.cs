namespace Win10_task1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstallMigration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Processes", "User_Id", "dbo.Users");
            DropIndex("dbo.Processes", new[] { "User_Id" });
            RenameColumn(table: "dbo.Processes", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Processes", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Processes", "UserId");
            AddForeignKey("dbo.Processes", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Processes", "UserId", "dbo.Users");
            DropIndex("dbo.Processes", new[] { "UserId" });
            AlterColumn("dbo.Processes", "UserId", c => c.Guid());
            RenameColumn(table: "dbo.Processes", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Processes", "User_Id");
            AddForeignKey("dbo.Processes", "User_Id", "dbo.Users", "Id");
        }
    }
}
