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

            //var courseInfo = from course in odDataContext.COURSEs
            //                 join student in odDataContext.STUDENTs
            //                 on course.course_id equals student.course_id into studentInfo
            //                 from students in studentInfo.DefaultIfEmpty()

            var task = from tsk in tstDb.Tasks
                         join parenttsk in tstDb.Tasks
                         on tsk.ParentId equals parenttsk.TaskId into TaskInfo 
                         from tsks in TaskInfo.DefaultIfEmpty()
                       select new  { tsk.TaskId,
                           tsk.TaskName,
                           tsk.Priority,
                           tsk.StartDate,
                           tsk.EndDate,
                           tsk.ParentId,
                           parentTask = tsks.TaskName  };
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
                tasks.Add(t);
            }

        
            return tasks;

        }

        public List<TaskEntity> GetParentTasks()
        {

            TaskContext tstDb = new TaskContext();
            var parent = from tsk in tstDb.Tasks
                        where tsk.EndDate == null
                        select new {tsk.TaskId, tsk.TaskName };
     
            List<TaskEntity> parenttasks = new List<TaskEntity>();
           // parenttasks = parent.ToList<TaskEntity>();
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
                t.EndDate = item.EndDate ;
                
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

        public int EndTask(int taskId, TaskEntity task)
        {
            TaskContext tstDb = new TaskContext();
            TaskEntity t = tstDb.Tasks.Find(taskId);

            t.EndDate = DateTime.Now;
           

            tstDb.Entry(t).State = EntityState.Modified;
            int Retval = tstDb.SaveChanges();
            return Retval;
        }
        public int DeleteTask(int taskId)
        {
            TaskContext tstDb = new TaskContext();
            TaskEntity t = tstDb.Tasks.Find(taskId);
           // tstDb.Entry(t).State = EntityState.Deleted;
            tstDb.Tasks.Remove(t);
            int Retval = tstDb.SaveChanges();
            return Retval;

        }

    }
}
