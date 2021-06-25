namespace Win10_task1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstallMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubTasks", "Name", c => c.String());
            AddColumn("dbo.SubTasks", "Description", c => c.String());
            AddColumn("dbo.SubTasks", "Ready", c => c.Boolean(nullable: false));
            DropColumn("dbo.SubTasks", "SubTaskName");
            DropColumn("dbo.SubTasks", "SubTaskDescription");
            DropColumn("dbo.SubTasks", "SubTaskStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubTasks", "SubTaskStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.SubTasks", "SubTaskDescription", c => c.String());
            AddColumn("dbo.SubTasks", "SubTaskName", c => c.String());
            DropColumn("dbo.SubTasks", "Ready");
            DropColumn("dbo.SubTasks", "Description");
            DropColumn("dbo.SubTasks", "Name");
        }
    }
}
