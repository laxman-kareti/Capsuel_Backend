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

        public List<TaskEntity> GetAllTasks(int projectId)
        {

            TaskContext tstDb = new TaskContext();


            var task = from tsk in tstDb.Tasks
                       join parenttsk in tstDb.Tasks
                       on tsk.ParentId equals parenttsk.TaskId into TaskInfo
                       from tsks in TaskInfo.DefaultIfEmpty()
                       where tsk.ProjectId == projectId
                       select new
                       {
                           tsk.TaskId,
                           tsk.TaskName,
                           tsk.Priority,
                           tsk.StartDate,
                           tsk.EndDate,
                           tsk.ParentId,
                           tsk.Status,
                           tsk.UserId,
                           tsk.ProjectId,
                           parentTask = tsks.TaskName
                       };
            List<TaskEntity> tasks = new List<TaskEntity>();

            foreach (var item in task)
            {
                TaskEntity t = new TaskEntity();

                t.TaskId = item.TaskId;
                t.TaskName = item.TaskName;
                t.Priority = item.Priority;
                t.StartDate = item.StartDate;
                t.EndDate = item.EndDate;
                t.ParentId = item.ParentId;
                t.ParentTask = item.parentTask;
                t.Status = item.Status;
                t.ProjectId = item.ProjectId;
                t.UserId = item.UserId;
                tasks.Add(t);
            }


            return tasks;

        }

        public List<TaskEntity> GetParentTasks()
        {

            TaskContext tstDb = new TaskContext();
            var parent = from tsk in tstDb.Tasks
                         select new { tsk.TaskId, tsk.TaskName };

            List<TaskEntity> parenttasks = new List<TaskEntity>();

            foreach (var item in parent)
            {
                TaskEntity t = new TaskEntity();
                t.ParentId = item.TaskId;
                t.ParentTask = item.TaskName;
                parenttasks.Add(t);
            }
            return parenttasks;


        }

        public TaskEntity GetTaskById(int taskId)
        {
            TaskContext tstDb = new TaskContext();
            var task = from tsk in tstDb.Tasks
                       join parenttsk in tstDb.Tasks
                       on tsk.ParentId equals parenttsk.TaskId into TaskInfo
                       from tsks in TaskInfo.DefaultIfEmpty()
                       where tsk.TaskId == taskId
                       select new
                       {
                           tsk.TaskId,
                           tsk.TaskName,
                           tsk.Priority,
                           tsk.StartDate,
                           tsk.EndDate,
                           tsk.ParentId,
                           tsk.UserId,
                           tsk.ProjectId,
                           parentTask = tsks.TaskName
                       };
            TaskEntity t = new TaskEntity();
            foreach (var item in task)
            {

                t.TaskId = item.TaskId;
                t.TaskName = item.TaskName;
                t.Priority = item.Priority;
                t.ParentId = item.ParentId;
                t.ParentTask = item.parentTask;
                t.StartDate = item.StartDate;
                t.EndDate = item.EndDate;
                t.ProjectId = item.ProjectId;
                t.UserId = item.UserId;

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
            t.UserId = task.UserId;
            t.ProjectId = task.ProjectId;
            tstDb.Tasks.Add(t);
            int Retval = tstDb.SaveChanges();
            return Retval;



        }

        public int UpdateTask(int taskId, TaskEntity task)
        {
            TaskContext tstDb = new TaskContext();
            TaskEntity t = tstDb.Tasks.Find(taskId);

            t.TaskName = task.TaskName;
            t.Priority = task.Priority;
            t.ParentId = task.ParentId;
            t.StartDate = task.StartDate;
            t.EndDate = task.EndDate;
            t.ProjectId = task.ProjectId;
            t.UserId = task.UserId; 

            tstDb.Entry(t).State = EntityState.Modified;
            int Retval = tstDb.SaveChanges();
            return Retval;
        }

        public int EndTask(int taskId, TaskEntity task)
        {
            TaskContext tstDb = new TaskContext();
            
            TaskEntity t = tstDb.Tasks.Find(taskId);

            t.EndDate = DateTime.Now;
            t.Status = "Completed";
            tstDb.Entry(t).State = EntityState.Modified;
            int Retval = tstDb.SaveChanges();
            return Retval;
        }
        public int DeleteTask(int taskId)
        {
            TaskContext tstDb = new TaskContext();
            TaskEntity t = tstDb.Tasks.Find(taskId);
            tstDb.Tasks.Remove(t);
            int Retval = tstDb.SaveChanges();
            return Retval;

        }

    }
}
