using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using JosueWebApiTest.Models;

namespace JosueWebApiTest.Controllers
{
    public class UserController : ApiController
    {
        private IUserContext _userContext;

        public UserController(IUserContext userContext)
        {
            _userContext = userContext;
        }

        // GET api/user
        public IHttpActionResult Get()
        {
            var userList = _userContext.Users.ToList();
            if (userList != null)
            {
                return Ok(new { results = userList });
            }
           
            return BadRequest("No se ha registrado ningun Usuario aun!");
        }

        // GET api/user/5
        public User Get(int id)
        {
            User user = _userContext.FindUserById(id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user;
        }

        // POST api/user
        public IHttpActionResult Post([FromBody]User user)
        {
            try
            {
                _userContext.Add(user);
                _userContext.SaveChanges();
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return Ok("El usuario se ha creado satisfactoriamente!");

        }

        // PUT api/user/5
        public IHttpActionResult Put(int id, [FromBody]User user)
        {
            try
            {
                var userFound = _userContext.FindUserById(id);
                if (userFound != null)
                {
                    userFound.Name = user.Name;
                    userFound.LastName = user.LastName;
                    userFound.Address = user.Address;
                    userFound.UpdateDate = DateTime.Today;

                    _userContext.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return Ok("El usuario se ha actualizado satisfactoriamente!");
        }

        // DELETE api/user/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var userFound = _userContext.FindUserById(id);
                if (userFound != null)
                {
                    _userContext.Delete(userFound);
                    _userContext.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return Ok("El usuario se ha eliminado satisfactoriamente!");

        }
    }
}
