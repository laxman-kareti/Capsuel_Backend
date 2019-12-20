using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TaskManager.Entities;
   

namespace TaskManager.DataLayer
{
    public class TaskContext : DbContext
    {
        public TaskContext() 
        {

        }


        public DbSet<TaskEntity> Tasks { get; set; }
    }
}

