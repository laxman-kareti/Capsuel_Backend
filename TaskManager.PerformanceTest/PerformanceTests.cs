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


            int result = Bo.AddTask(task);

        }




        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement, NumberOfIterations = 500, SkipWarmups = true)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        public void Check_GarbageCollection_GetTasks()
        {
            GetAllTasks();

        }

        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void Check_MemoryUsage_GetTasks()
        {
            GetAllTasks();

        }

        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Test)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000)]
        public void Check_ElapsedTime_GetTasks()
        {
            GetAllTasks();

        }

        public List<TaskEntity> GetAllTasks()
        {

            TaskContext tstDb = new TaskContext();


            var task = from tsk in tstDb.Tasks
                       join parenttsk in tstDb.Tasks
                       on tsk.ParentId equals parenttsk.TaskId into TaskInfo
                       from tsks in TaskInfo.DefaultIfEmpty()
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


        [PerfBenchmark(RunMode = RunMode.Throughput, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Test)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000)]
        public void Check_ElapsedTime_UpdateTask()
        {
            TaskBAO Bo = new TaskBAO();

            TaskEntity task = new TaskEntity();

            task.TaskId = 5048;
            task.ParentId = null;
            task.TaskName = "Task101";
            task.Priority = 11;
            task.StartDate = DateTime.Parse("2019-12-25");
            task.EndDate = DateTime.Parse("2019-12-29");

            int taskid = task.TaskId;


            int result = Bo.UpdateTask(taskid, task);

          
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, NumberOfIterations = 500, SkipWarmups = true, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void Check_MemoryUsage_UpdateTask()
        {
            TaskBAO Bo = new TaskBAO();

            TaskEntity task = new TaskEntity();

            task.TaskId = 5048;
            task.ParentId = null;
            task.TaskName = "Task101";
            task.Priority = 11;
            task.StartDate = DateTime.Parse("2019-12-25");
            task.EndDate = DateTime.Parse("2019-12-29");

            int taskid = task.TaskId;


            int result = Bo.UpdateTask(taskid, task);


        }
        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement, NumberOfIterations = 500, SkipWarmups = true)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        public void Check_GarbageCollection_UpdateTask()
        {
            TaskBAO Bo = new TaskBAO();

            TaskEntity task = new TaskEntity();

            task.TaskId = 5048;
            task.ParentId = null;
            task.TaskName = "Task101";
            task.Priority = 11;
            task.StartDate = DateTime.Parse("2019-12-25");
            task.EndDate = DateTime.Parse("2019-12-29");

            int taskid = task.TaskId;


            int result = Bo.UpdateTask(taskid, task);


        }
    }
}
