namespace Win10_task1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstallMigration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubTasks", "Process_Id", "dbo.Processes");
            DropIndex("dbo.SubTasks", new[] { "Process_Id" });
            RenameColumn(table: "dbo.SubTasks", name: "Process_Id", newName: "ProcessId");
            AlterColumn("dbo.SubTasks", "ProcessId", c => c.Guid(nullable: false));
            CreateIndex("dbo.SubTasks", "ProcessId");
            AddForeignKey("dbo.SubTasks", "ProcessId", "dbo.Processes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubTasks", "ProcessId", "dbo.Processes");
            DropIndex("dbo.SubTasks", new[] { "ProcessId" });
            AlterColumn("dbo.SubTasks", "ProcessId", c => c.Guid());
            RenameColumn(table: "dbo.SubTasks", name: "ProcessId", newName: "Process_Id");
            CreateIndex("dbo.SubTasks", "Process_Id");
            AddForeignKey("dbo.SubTasks", "Process_Id", "dbo.Processes", "Id");
        }
    }
}
