namespace Win10_task1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstallMigration6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PasswordHash", c => c.String());
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            DropColumn("dbo.Users", "PasswordHash");
        }
    }
}
