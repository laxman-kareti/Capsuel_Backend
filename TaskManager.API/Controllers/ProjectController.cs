using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.BusinessLayer;
using TaskManager.Entities;

namespace TaskManager.API.Controllers
{
    public class ProjectController : ApiController
    {
        private ProjectBAO BO = new ProjectBAO();
        [HttpGet]
        [ActionName("GetAllProjects")]
        public IHttpActionResult GetAllProjects()

        {
            try
            {
                return Ok(BO.GetAllProjects());

            }
            catch (Exception)
            {

                throw;
            }



        }

        [HttpPut]
        [ActionName("EndProject")]
        public IHttpActionResult EndProject(int id, [FromBody] Project proj)
        {
            try
            {
                BO.EndProject(id, proj);
            }
            catch (Exception)
            {

                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);


        }

        // GET 

        [HttpGet]
        [ActionName("GetProjectById")]
        public IHttpActionResult GetProjectById(int id)
        {
            Project proj = BO.GetProjectById(id);
            if (proj == null)
            {
                return NotFound();
            }
            return Ok(proj);
        }
        //PUT

        [HttpPut]
        [ActionName("UpdateProject")]
        public IHttpActionResult PutProject(int id, [FromBody] Project proj)
        {
            try
            {
                BO.UpdateProject(id, proj);
            }
            catch (Exception)
            {

                throw;

            }


            return StatusCode(HttpStatusCode.NoContent);

        }
        // POST  

        [HttpPost]
        [ActionName("CreateProject")]
        public IHttpActionResult PostProject([FromBody] Project proj)
        {
            try
            {
                BO.AddProject(proj);
            }
            catch (Exception)
            {

                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);


        }
        // DELETE 

        [ActionName("DeleteProject")]
        public IHttpActionResult DeleteProject(int Id)
        {
            try
            {
                BO.DeleteProject(Id);
            }
            catch (Exception)
            {

                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);

        }



    }
}
