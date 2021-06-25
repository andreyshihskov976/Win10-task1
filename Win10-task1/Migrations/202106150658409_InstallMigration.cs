namespace Win10_task1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstallMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Processes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Ready = c.Boolean(nullable: false, defaultValue: false),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.SubTasks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SubTaskName = c.String(),
                        SubTaskDescription = c.String(),
                        SubTaskStatus = c.Boolean(nullable: false, defaultValue: false),
                        Process_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Processes", t => t.Process_Id)
                .Index(t => t.Process_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        SurName = c.String(),
                        Login = c.String(nullable: false, maxLength: 16),
                        Password = c.String(nullable: false, maxLength: 18),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Processes", "User_Id", "dbo.Users");
            DropForeignKey("dbo.SubTasks", "Process_Id", "dbo.Processes");
            DropIndex("dbo.SubTasks", new[] { "Process_Id" });
            DropIndex("dbo.Processes", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.SubTasks");
            DropTable("dbo.Processes");
        }
    }
}
