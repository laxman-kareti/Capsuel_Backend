namespace TaskManager.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedBModelV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        StartDate = c.DateTime(storeType: "date"),
                        EndDate = c.DateTime(storeType: "date"),
                        Priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Task", "ProjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Task", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Task", "Status");
            DropColumn("dbo.Task", "ProjectId");
            DropTable("dbo.Users");
            DropTable("dbo.Projects");
        }
    }
}
