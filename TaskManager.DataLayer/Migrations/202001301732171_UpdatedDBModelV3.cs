namespace TaskManager.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDBModelV3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Task", "UserId", c => c.Int(nullable: false));
       
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "TaskId", c => c.Int());
            AddColumn("dbo.Users", "ProjectId", c => c.Int());
          
        }
    }
}
