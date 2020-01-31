namespace TaskManager.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDBModelV2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "ProjectId", c => c.Int());
            AlterColumn("dbo.Users", "TaskId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "TaskId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "ProjectId", c => c.Int(nullable: false));
        }
    }
}
