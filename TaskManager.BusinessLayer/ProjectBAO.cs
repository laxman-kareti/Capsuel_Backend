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
    public class ProjectBAO
    {

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


        public Project GetProjectById(int projId)
        {
            TaskContext tstDb = new TaskContext();
            var proj = from prj in tstDb.Projects
                       where prj.ProjectId == projId
                       select prj;
            Project p = new Project();
            foreach (var item in proj)
            {

                p.ProjectId = item.ProjectId;
                p.ProjectName = item.ProjectName;
                p.StartDate = item.StartDate;
                p.EndDate = item.EndDate;
                p.Priority = item.Priority;
                p.UserId = item.UserId;


            }

            return p;

        }


        public int EndProject(int projId, Project proj)
        {
            TaskContext tstDb = new TaskContext();
            Project p = tstDb.Projects.Find(projId);

            p.EndDate = DateTime.Now;
            
            tstDb.Entry(p).State = EntityState.Modified;
            int Retval = tstDb.SaveChanges();
            return Retval;
        }

        public int AddProject(Project proj)
        {
            TaskContext tstDb = new TaskContext();

            Project p = new Project();

            p.ProjectName = proj.ProjectName;
            p.Priority = proj.Priority;
            p.StartDate = proj.StartDate;
            p.EndDate = proj.EndDate;
            p.UserId = proj.UserId;
            tstDb.Projects.Add(p);
            int Retval = tstDb.SaveChanges();
            return Retval;



        }

        public int UpdateProject(int projId, Project proj)
        {
            TaskContext tstDb = new TaskContext();
            Project p = tstDb.Projects.Find(projId);

            p.ProjectName = proj.ProjectName;
            p.Priority = proj.Priority;
            p.StartDate = proj.StartDate;
            p.EndDate = proj.EndDate;
            p.UserId = proj.UserId;

            tstDb.Entry(p).State = EntityState.Modified;
            int Retval = tstDb.SaveChanges();
            return Retval;
        }
        public int DeleteProject(int projId)
        {
            TaskContext tstDb = new TaskContext();
            Project p = tstDb.Projects.Find(projId);
            tstDb.Projects.Remove(p);
            int Retval = tstDb.SaveChanges();
            return Retval;

        }
    }
}
