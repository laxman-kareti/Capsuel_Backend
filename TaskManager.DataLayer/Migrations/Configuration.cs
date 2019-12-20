namespace TaskManager.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManager.DataLayer.TaskContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaskManager.DataLayer.TaskContext context)
        {
            context.Tasks.AddOrUpdate(p => p.TaskId,
            new Entities.TaskEntity { TaskName = "Task1", Priority = 11, StartDate = DateTime.Parse("2019-12-16") },
            new Entities.TaskEntity { TaskName = "Task2", Priority = 12, StartDate = DateTime.Parse("2019-12-12") },
            new Entities.TaskEntity { TaskName = "Task3", Priority = 13, StartDate = DateTime.Parse("2019-12-13") },
            new Entities.TaskEntity { TaskName = "Task4", Priority = 14, StartDate = DateTime.Parse("2019-12-14") }
            );
        }
    }
}
