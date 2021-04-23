using BL;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RatzKatzvi.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        //GetAllUsers    
        public IHttpActionResult GetAllKeyWords()
        {
            return Ok(UsersBL.GetAllUsers());
        }
        //GetUserById
        [Route("GetUserById/{userId}")]
        public IHttpActionResult GetById(int userId)
        {
            try
            {
                return Ok(UsersBL.GetUserById(userId));
            }
            catch
            {
                return NotFound();
            }
        }
        //GeByUserName
        [Route("GeByUserName/{userName}")]
        public IHttpActionResult GeByUserName(string userName)
        {
            try
            {
                return Ok(UsersBL.GeByUserName(userName));
            }
            catch
            {
                return NotFound();
            }
        }
        // POST: api/Users   
        

        
        public IHttpActionResult Post([FromBody] Users1 newUser)
        {
            try
            {
                UsersBL.AddUser(newUser);
                return Ok();
            }
            catch
            {
                return Conflict();
            }
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login([FromBody] Users1 user)
        {
            try
            {

                Users1 user1 = UsersBL.Login(user.Email, user.Password);
                if (user1 == null)
                    throw new Exception();
                return Ok(user1);
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: api/Users/5
        //UPDATE
        [HttpPut]
        [Route("Put")]
        public IHttpActionResult Put([FromBody] Users1 user)
        {
            try
            {
                UsersBL.UpdateUser(user);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        // DELETE: api/Users/5
        public IHttpActionResult Delete(int id, [FromBody] Users1 user)
        {
            try
            {
                UsersBL.DeleteUser(user);
                return Ok();
            }
            catch
            {
                return Conflict();
            }
        }
        //Email
        [HttpPost]
        [Route("SendAnEmail")]
        public IHttpActionResult SendAnEmail([FromBody] Users1 message)
        {
            //string Name = message.Name;
            //string Phone = message.Phone;
            //string Email = message.Email;
            //string MessageToSend = message.Message;

            string Name = "u65u";
            string Phone = "0545";
            string Email = message.Email;
            string MessageToSend = "knyuk";
            try
            {
                UsersBL.SendAnEmail(Name,Phone,  Email, MessageToSend);
                return Ok();
            }
            catch
            {
                return Conflict();
            }
        }
        
    }
}
