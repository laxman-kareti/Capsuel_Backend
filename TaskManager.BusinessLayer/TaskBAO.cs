using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataLayer;
using TaskManager.Entities;


namespace TaskManager.BusinessLayer
{
    public class TaskBAO
    {

        public List<TaskEntity> GetAllTasks()
        {

            TaskContext tstDb = new TaskContext();
            
            return tstDb.Tasks.ToList();

        }

        public TaskEntity GetTaskById(int taskId)
        {
            TaskContext tstDb = new TaskContext();
            var tasks = from tsk in tstDb.Tasks where tsk.TaskId == taskId select tsk;
             TaskEntity t = new TaskEntity();
            foreach (var item in tasks)
            {

                t.TaskId = item.TaskId;
                t.TaskName = item.TaskName;
                t.Priority = item.Priority;
                t.ParentId = item.ParentId;
                t.StartDate = item.StartDate;
                t.EndDate = item.EndDate;
                
            }

            return t;
            
        }

        public int AddTask(TaskEntity task)
        {
                TaskContext tstDb = new TaskContext();
            
                TaskEntity t = new TaskEntity();
                
                t.TaskName = task.TaskName;
                t.Priority = task.Priority;
                t.ParentId = task.ParentId;
                t.StartDate = task.StartDate;
                t.EndDate = task.EndDate;
                 tstDb.Tasks.Add(t);
                int Retval = tstDb.SaveChanges();
                return Retval;

        

        }

        public int UpdateTask(int taskId,TaskEntity task)
        {
            TaskContext tstDb = new TaskContext();
            TaskEntity t = tstDb.Tasks.Find(taskId);
            
            t.TaskName = task.TaskName;
            t.Priority = task.Priority;
            t.ParentId = task.ParentId;
            t.StartDate = task.StartDate;

            tstDb.Entry(t).State = EntityState.Modified;
            int Retval = tstDb.SaveChanges();
            return Retval;
        }
        public List<TaskEntity> DeleteTask(int taskId)
        {
            TaskContext tstDb = new TaskContext();
            TaskEntity t = tstDb.Tasks.Find(taskId);
            tstDb.Entry(t).State = EntityState.Deleted;
            tstDb.Tasks.Remove(t);
            int Retval = tstDb.SaveChanges();
            return tstDb.Tasks.ToList();

        }

    }
}
