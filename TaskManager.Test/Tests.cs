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
            task.ProjectId = 8;
            task.UserId = 2006;
            int result = Bo.AddTask(task);

            Assert.AreEqual(1, result);



        }

        [Test]
        public void EndTask_Returns_Success()
        {
            TaskBAO Bo = new TaskBAO();

            TaskEntity task = new TaskEntity();

            task.TaskId = 9676;
          
            int taskid = task.TaskId;
            int result = Bo.EndTask(taskid, task);

            Assert.AreEqual(1, result);

        }


        [Test]
        public void UpdateTask_Returns_Success()
        {
            TaskBAO Bo = new TaskBAO();

            TaskEntity task = new TaskEntity();
           
            task.TaskId = 8664;
            task.ParentId = null;
            task.TaskName = "Task101";
            task.Priority = 11;
            task.StartDate = DateTime.Parse("2019-12-25");
            task.EndDate = DateTime.Parse("2019-12-29");
            task.ProjectId = 8;
            task.UserId = 2006;
       
            int taskid = task.TaskId;
             int result = Bo.UpdateTask(taskid, task);

            Assert.AreEqual(1, result);

        }

      

        [Test]
        public void GetTasks_Returns_Success()
        {
            TaskBAO Bo = new TaskBAO();
              int projectid = 8;
            List<TaskEntity> result = Bo.GetAllTasks(projectid);
            Assert.IsNotNull(result.Count.ToString());

        }

        [Test]
        public void GetParentTasks_Returns_Success()
        {
            TaskBAO Bo = new TaskBAO();
            List<TaskEntity> result = Bo.GetParentTasks();

            Assert.IsNotEmpty(result.Count.ToString(),"Parent tasks not empty");

        }

        [Test]
        public void GetTasksById_Returns_Success()
        {
            TaskBAO Bo = new TaskBAO();

            int taskid = 9665;

            TaskEntity result = Bo.GetTaskById(taskid);

            Assert.AreEqual(9665, result.TaskId);

        }

        [Test]
        public void AddProject_Returns_Success()
        {
            ProjectBAO Bo = new ProjectBAO();

            Project proj = new Project();


            proj.ProjectName = "Project 100";
            proj.UserId = 2006;
            proj.StartDate = DateTime.Parse("2019-12-24");
            proj.EndDate = DateTime.Parse("2019-12-28");
            int result = Bo.AddProject(proj);

            Assert.AreEqual(1, result);

        }

        [Test]
        public void UpdateProject_Returns_Success()
        {
            ProjectBAO Bo = new ProjectBAO();

            Project proj = new Project();
            proj.ProjectId = 1012;
            proj.ProjectName = "Project 101";
            proj.UserId = 2006;
            proj.StartDate = DateTime.Parse("2019-12-24");
            proj.EndDate = DateTime.Parse("2019-12-29");
            proj.Priority = 8;
         

            int projectid = proj.ProjectId;
            
            int result = Bo.UpdateProject(projectid, proj);

            Assert.AreEqual(1, result);

        }

      

        [Test]
        public void Getprojects_Returns_Success()
        {
            ProjectBAO Bo = new ProjectBAO();
            
            List<Project> result = Bo.GetAllProjects();
            Assert.IsNotNull(result.Count.ToString());

        }

      

        [Test]
        public void GetProjectById_Returns_Success()
        {
            ProjectBAO Bo = new ProjectBAO();

            int projectId = 8;

            Project result = Bo.GetProjectById(projectId);

            Assert.AreEqual(8, result.ProjectId);

        }
        [Test]
        public void AddUser_Returns_Success()
        {
            UserBAO Bo = new UserBAO();

            User user = new User();
            user.FirstName = "laxman";
            user.LastName = "kareti";
            user.EmployeeId = 1301;
            
            int result = Bo.AddUser(user);

            Assert.AreEqual(1, result);

        }

        [Test]
        public void UpdateUser_Returns_Success()
        {
            UserBAO Bo = new UserBAO();

            User user = new User();
            user.UserId = 2006;
            user.FirstName = "Praveen";
            user.LastName = "Kumar";
            user.EmployeeId = 1301;

        

            int userid = user.UserId;

            int result = Bo.UpdateUser(userid, user);

            Assert.AreEqual(1, result);

        }

     

        [Test]
        public void GetUsers_Returns_Success()
        {
            UserBAO Bo = new UserBAO();

            List<User> result = Bo.GetAllUsers();
            Assert.IsNotNull(result.Count.ToString());

        }



        [Test]
        public void GetUserById_Returns_Success()
        {
            UserBAO Bo = new UserBAO();

            int userId = 2007;

            User result = Bo.GetUserById(userId);

            Assert.AreEqual(2007, result.UserId);

        }

        [Test]
        public void DeleteUser_Returns_Success()
        {
            UserBAO Bo = new UserBAO();
            int userid = 3009;
            int result = Bo.DeleteUser(userid);

            Assert.AreEqual(result, 1);

        }

        [Test]
        public void DeleteProject_Returns_Success()
        {
            ProjectBAO Bo = new ProjectBAO();
            int projectid = 1014;
            int result = Bo.DeleteProject(projectid);

            Assert.AreEqual(result, 1);

        }
        [Test]
        public void DeleteTask_Returns_Success()
        {
            TaskBAO Bo = new TaskBAO();
            int taskid = 9678;
            int result = Bo.DeleteTask(taskid);

            Assert.AreEqual(result, 1);

        }



    }
}
