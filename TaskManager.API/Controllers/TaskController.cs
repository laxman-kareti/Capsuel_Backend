
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TaskManager.BusinessLayer;
using TaskManager.Entities;


namespace TaskManager.API.Controllers
{

    public class TaskController : ApiController
    {
       private TaskBAO BO = new TaskBAO();
        [HttpGet]
        [ActionName("GetAllTasks")]
        public IHttpActionResult GetAllTasks()

        {
            try
            {
               return Ok(BO.GetAllTasks());

            }
            catch (Exception)
            {

                throw;
            }



        }
        [HttpGet]
        [ActionName("ParentTask")]
        public IHttpActionResult GeParentTasks()

        {
            try
            {
                return Ok(BO.GetParentTasks());

            }
            catch (Exception)
            {

                throw;
            }



        }

        // GET 
        // [Route("api/Task/{id}")]
        [HttpGet]
        [ActionName("GetTaskById")]
        public IHttpActionResult GetTaskById(int id)
        {
            TaskEntity  task = BO.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
        //PUT
        //[Route("api/UpdateTask/{id}")]
        [HttpPut]
        [ActionName("UpdateTask")]
        public IHttpActionResult PutTask(int id,[FromBody]TaskEntity task)
        {
            try
            {
                BO.UpdateTask(id,task);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
           
            }
           

            return StatusCode(HttpStatusCode.NoContent);

        }
        // POST api/CRUD  
       // [Route("api/AddTask")]
        public IHttpActionResult PostTask([FromBody] TaskEntity task)
        {
            try
            {
                BO.AddTask(task);
            }
            catch (Exception)
            {

                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
            
            
        }
        [HttpPut]
        [ActionName("EndTask")]
        public IHttpActionResult EndTask(int id,[FromBody] TaskEntity task)
        {
            try
            {
                BO.EndTask(id,task);
            }
            catch (Exception)
            {

                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);


        }
        // DELETE api/CRUD/5  
        //[HttpDelete, Route("api/Task/Delete/{id}")]
        [ActionName("DeleteTask")]
        public IHttpActionResult DeleteTask(int Id)
        {
            try
            {
                BO.DeleteTask(Id);
            }
            catch (Exception)
            {

                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
      
        }

       

    }
}
