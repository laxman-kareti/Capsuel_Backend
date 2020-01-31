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
    public class UserController : ApiController
    {

        private UserBAO BO = new UserBAO();
        [HttpGet]
        [ActionName("GetAllUsers")]
        public IHttpActionResult GetAllUsers()

        {
            try
            {
                return Ok(BO.GetAllUsers());

            }
            catch (Exception)
            {

                throw;
            }



        }
        
        // GET 

        [HttpGet]
        [ActionName("GetUserById")]
        public IHttpActionResult GetUserById(int id)
        {
            User user = BO.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        //PUT

        [HttpPut]
        [ActionName("UpdateUser")]
        public IHttpActionResult PutUser(int id, [FromBody] User user)
        {
            try
            {
                BO.UpdateUser(id, user);
            }
            catch (Exception)
            {

                throw;

            }


            return StatusCode(HttpStatusCode.NoContent);

        }
        // POST  

        [HttpPost]
        [ActionName("CreateUser")]
        public IHttpActionResult PostUser([FromBody] User user)
        {
            try
            {
                BO.AddUser(user);
            }
            catch (Exception)
            {

                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);


        }
        // DELETE 

        [ActionName("DeleteUser")]
        public IHttpActionResult DeleteUser(int Id)
        {
            try
            {
                BO.DeleteUser(Id);
            }
            catch (Exception)
            {

                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);

        }


    }
}
