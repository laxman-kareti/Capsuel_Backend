using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TaskManager.BusinessLayer;
using System.Web.Http.Results;
using System.Web.Http;
using TaskManager.Entities;
using System.Net.Http;

namespace TaskManager.Test
{
    [TestFixture]
    public class TaskManagerTest
    {

      
        [Test]
        public void AddTask_Returns_Success()
        {
            TaskBAO Bo = new TaskBAO();

            TaskEntity task = new TaskEntity();

           
            task.ParentId = null;
            task.TaskName = "Task100";
             task.Priority = 10;
            task.StartDate = DateTime.Parse("2019-12-24");
            task.EndDate = DateTime.Parse("2019-12-28");
         

            int result = Bo.AddTask(task);

            Assert.AreEqual(1, result);



        }

        [Test]
        public void UpdateTask_Returns_Success()
        {
            TaskBAO Bo = new TaskBAO();

            TaskEntity task = new TaskEntity();
           
            task.TaskId = 3;
            task.ParentId = null;
            task.TaskName = "Task101";
            task.Priority = 11;
            task.StartDate = DateTime.Parse("2019-12-25");
            task.EndDate = DateTime.Parse("2019-12-29");
       
            int taskid = task.TaskId;


            int result = Bo.UpdateTask(taskid, task);

            Assert.AreEqual(1, result);



        }

        [Test]
        public void DeleteTask_Returns_Success()
        {
            TaskBAO Bo = new TaskBAO();

            int taskid = 12;

            int result = Bo.DeleteTask(taskid);

            Assert.AreEqual(1, result);



        }

        [Test]
        public void GetTasks_Returns_Success()
        {
            TaskBAO Bo = new TaskBAO();
            int taskcount = 7;

            List<TaskEntity> result = Bo.GetAllTasks();

            Assert.AreEqual(taskcount, result.Count);

        }

        [Test]
        public void GetParentTasks_Returns_Success()
        {
            TaskBAO Bo = new TaskBAO();
            int taskcount = 2;

            List<TaskEntity> result = Bo.GetParentTasks();

            Assert.AreEqual(taskcount,result.Count);

        }

        [Test]
        public void GetTasksById_Returns_Success()
        {
            TaskBAO Bo = new TaskBAO();

            int taskid = 1037;

            TaskEntity result = Bo.GetTaskById(taskid);

            Assert.AreEqual(1037, result.TaskId);



        }



    }
}
