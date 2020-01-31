using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TaskManager.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TaskManager.DataLayer
{
    public class TaskContext : DbContext
    {
        public TaskContext() 
        {

        }


        public DbSet<TaskEntity> Tasks { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

       

    }
}

