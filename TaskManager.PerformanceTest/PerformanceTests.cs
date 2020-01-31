using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;
using TaskManager.Entities;
using TaskManager.BusinessLayer;
using TaskManager.DataLayer;

namespace TaskManager.PerformanceTest
{
    public class PerformanceTests
    {
        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void Check_MemoryUsage_AddTask()
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



        }

        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Test)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000)]
        public void CheckElapsedTime_AddTask()
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



        }


        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement, NumberOfIterations = 500, SkipWarmups = true)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        public void Check_GarbageCollection_AddTask()
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

        }




        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement, NumberOfIterations = 500, SkipWarmups = true)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        public void Check_GarbageCollection_GetTasks()
        {
            int projectId = 8;
            GetAllTasks(projectId);

        }

        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 5000, SkipWarmups = true, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void Check_MemoryUsage_GetTasks()
        {
            int projectId = 8;
            GetAllTasks(projectId);

        }

        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations =500, SkipWarmups = true, TestMode = TestMode.Test)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000)]
        public void Check_ElapsedTime_GetTasks()
        {
            int projectId = 8;
            GetAllTasks(projectId);

        }

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


        [PerfBenchmark(RunMode = RunMode.Throughput, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Test)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000)]
        public void Check_ElapsedTime_UpdateTask()
        {
            TaskBAO Bo = new TaskBAO();

            TaskEntity task = new TaskEntity();

            task.TaskId = 9665;
            task.ParentId = null;
            task.TaskName = "Task101";
            task.Priority = 11;
            task.StartDate = DateTime.Parse("2019-12-25");
            task.EndDate = DateTime.Parse("2019-12-29");
            task.ProjectId = 8;
            task.UserId = 2006;
            int taskid = task.TaskId;
            int result = Bo.UpdateTask(taskid, task);

          
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void Check_MemoryUsage_UpdateTask()
        {
            TaskBAO Bo = new TaskBAO();

            TaskEntity task = new TaskEntity();

            task.TaskId = 9665;
            task.ParentId = null;
            task.TaskName = "Task101";
            task.Priority = 11;
            task.StartDate = DateTime.Parse("2019-12-25");
            task.EndDate = DateTime.Parse("2019-12-29");
            task.ProjectId = 8;
            task.UserId = 2006;
            int taskid = task.TaskId;
            int result = Bo.UpdateTask(taskid, task);


        }
        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement, NumberOfIterations = 500, SkipWarmups = true)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        public void Check_GarbageCollection_UpdateTask()
        {
            TaskBAO Bo = new TaskBAO();

            TaskEntity task = new TaskEntity();

            task.TaskId = 9665;
            task.ParentId = null;
            task.TaskName = "Task101";
            task.Priority = 11;
            task.StartDate = DateTime.Parse("2019-12-25");
            task.EndDate = DateTime.Parse("2019-12-29");
            task.ProjectId = 8;
            task.UserId = 2006;
            int taskid = task.TaskId;
            int result = Bo.UpdateTask(taskid, task);


        }

        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void Check_MemoryUsage_AddUser()
        {
            UserBAO Bo = new UserBAO();

         
            User u = new User();

            u.FirstName = "laxman";
            u.LastName = "kareti";
            u.EmployeeId = 1030;
            int result = Bo.AddUser(u);



        }

        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Test)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000)]
        public void CheckElapsedTime_AddUser()
        {
            

            UserBAO Bo = new UserBAO();


            User u = new User();

            u.FirstName = "laxman";
            u.LastName = "kareti";
            u.EmployeeId = 1030;
            int result = Bo.AddUser(u);



        }


        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement, NumberOfIterations = 500, SkipWarmups = true)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        public void Check_GarbageCollection_AddUser()
        {
            UserBAO Bo = new UserBAO();


            User u = new User();

            u.FirstName = "laxman";
            u.LastName = "kareti";
            u.EmployeeId = 1030;
            int result = Bo.AddUser(u);

        }




        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement, NumberOfIterations = 500, SkipWarmups = true)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        public void Check_GarbageCollection_GetUsers()
        {
            GetAllUsers();

        }

        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void Check_MemoryUsage_GetUsers()
        {
            GetAllUsers();

        }

        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Test)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000)]
        public void Check_ElapsedTime_GetUsers()
        {
            GetAllUsers();

        }

        public List<User> GetAllUsers()
        {

            TaskContext tstDb = new TaskContext();


            var user = from usr in tstDb.Users
                       select usr;
            List<User> users = new List<User>();

            foreach (var item in user)
            {
                User u = new User();
                u.UserId = item.UserId;
                u.FirstName = item.FirstName;
                u.LastName = item.LastName;
                u.EmployeeId = item.EmployeeId;

                users.Add(u);
            }


            return users;

        }


        [PerfBenchmark(RunMode = RunMode.Throughput, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Test)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000)]
        public void Check_ElapsedTime_UpdateUser()
        {
            UserBAO Bo = new UserBAO();

            User user = new User();
            user.UserId = 2006;
            user.FirstName = "Praveen";
            user.LastName = "Kumar";
            user.EmployeeId = 1301;
            
            int userid = user.UserId;

            int result = Bo.UpdateUser(userid, user);


        }

        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void Check_MemoryUsage_UpdateUser()
        {
            UserBAO Bo = new UserBAO();

            User user = new User();
            user.UserId = 2006;
            user.FirstName = "Praveen";
            user.LastName = "Kumar";
            user.EmployeeId = 1301;

            int userid = user.UserId;

            int result = Bo.UpdateUser(userid, user);



        }
        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement, NumberOfIterations = 500, SkipWarmups = true)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        public void Check_GarbageCollection_UpdateUser()
        {
            UserBAO Bo = new UserBAO();

            User user = new User();
            user.UserId = 2006;
            user.FirstName = "Praveen";
            user.LastName = "Kumar";
            user.EmployeeId = 1301;

            int userid = user.UserId;

            int result = Bo.UpdateUser(userid, user);

        }


        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void Check_MemoryUsage_AddProject()
        {
            ProjectBAO Bo = new ProjectBAO();

            Project proj = new Project();


            proj.ProjectName = "Project 100";
            proj.UserId = 2006;
            proj.StartDate = DateTime.Parse("2019-12-24");
            proj.EndDate = DateTime.Parse("2019-12-28");
            int result = Bo.AddProject(proj);



        }

        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Test)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000)]
        public void CheckElapsedTime_AddProject()
        {


            ProjectBAO Bo = new ProjectBAO();

            Project proj = new Project();


            proj.ProjectName = "Project 100";
            proj.UserId = 2006;
            proj.StartDate = DateTime.Parse("2019-12-24");
            proj.EndDate = DateTime.Parse("2019-12-28");
            int result = Bo.AddProject(proj);



        }


        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement, NumberOfIterations = 500, SkipWarmups = true)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        public void Check_GarbageCollection_AddProject()
        {
            ProjectBAO Bo = new ProjectBAO();

            Project proj = new Project();


            proj.ProjectName = "Project 100";
            proj.UserId = 2006;
            proj.StartDate = DateTime.Parse("2019-12-24");
            proj.EndDate = DateTime.Parse("2019-12-28");
            int result = Bo.AddProject(proj);

        }




        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement, NumberOfIterations = 500, SkipWarmups = true)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        public void Check_GarbageCollection_GetProjects()
        {
            GetAllProjects();

        }

        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void Check_MemoryUsage_GetProjects()
        {
            GetAllProjects();

        }

        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Test)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000)]
        public void Check_ElapsedTime_GetProjects()
        {
            GetAllProjects();

        }

       public List<Project> GetAllProjects()
        {

            TaskContext tstDb = new TaskContext();



            var projects =
                        (from c in tstDb.Projects // db is your DataContext                               
                        select new
                        {   ProjectId = c.ProjectId,
                            ProjectName = c.ProjectName,
                            Priority = c.Priority,
                            StartDate = c.StartDate,
                            EndDate = c.EndDate,
                            CompletedTasks = tstDb.Tasks.Count(r => r.Status.ToUpper() == "Completed" && (r.ProjectId == c.ProjectId)),
                            TotalTasks = tstDb.Tasks.Count(s => s.ProjectId == c.ProjectId)
                        }).ToList();


            List<Project> proj = new List<Project>();

            foreach (var item in projects)
            {
                Project p = new Project();

                p.ProjectId = item.ProjectId;
                p.ProjectName = item.ProjectName;
                p.Priority = item.Priority;
                p.StartDate = item.StartDate;
                p.EndDate = item.EndDate;
                p.CompletedTasks = item.CompletedTasks;
                p.TotalTasks = item.TotalTasks;
                proj.Add(p);

            }
            return proj;

        }



        [PerfBenchmark(RunMode = RunMode.Throughput, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Test)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000)]
        public void Check_ElapsedTime_UpdateProject()
        {
            ProjectBAO Bo = new ProjectBAO();

            Project proj = new Project();
            proj.ProjectId = 1015;
            proj.ProjectName = "Project 101";
            proj.UserId = 2006;
            proj.StartDate = DateTime.Parse("2019-12-24");
            proj.EndDate = DateTime.Parse("2019-12-29");
            int projectid = proj.ProjectId;

            int result = Bo.UpdateProject(projectid, proj);



        }

        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void Check_MemoryUsage_UpdateProject()
        {
            ProjectBAO Bo = new ProjectBAO();

            Project proj = new Project();
            proj.ProjectId = 1015;
            proj.ProjectName = "Project 101";
            proj.UserId = 2006;
            proj.StartDate = DateTime.Parse("2019-12-24");
            proj.EndDate = DateTime.Parse("2019-12-29");

            int projectid = proj.ProjectId;

            int result = Bo.UpdateProject(projectid, proj);




        }
        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement, NumberOfIterations = 500, SkipWarmups = true)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        public void Check_GarbageCollection_UpdateProject()
        {
            ProjectBAO Bo = new ProjectBAO();

            Project proj = new Project();
            proj.ProjectId = 1015;
            proj.ProjectName = "Project 101";
            proj.UserId = 2006;
            proj.StartDate = DateTime.Parse("2019-12-24");
            proj.EndDate = DateTime.Parse("2019-12-29");

            int projectid = proj.ProjectId;

            int result = Bo.UpdateProject(projectid, proj);


        }
    }
}
