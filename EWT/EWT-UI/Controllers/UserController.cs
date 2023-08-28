using EWT_BLL.DTOs;
using EWT_BLL.Services;
using EWT_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EWT_UI.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/user/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = UserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/user/create")]
        public HttpResponseMessage Create(UserDTO user)
        {
            try
            {
                var data = UserService.Create(user);
                return Request.CreateResponse(HttpStatusCode.OK, "New user added successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/user/get/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = UserService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpDelete]
        [Route("api/user/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            if (UserService.Delete(id))
                return Request.CreateResponse(HttpStatusCode.OK, "The user with id :" + id + "has been deleted successfully");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, "cannot delete the requested user");
        }

        [HttpPut]
        [Route("api/user/update")]
        public HttpResponseMessage Update(UserDTO user)
        {
            UserService.Update(user);
            return Request.CreateResponse(HttpStatusCode.OK, "User Id:" + user.Id + "has been updated successfully");
        }

        [HttpPost]
        [Route("api/user/login")]
        public HttpResponseMessage Login(LoginModel login)
        {
            try
            {
                var token = AuthService.Login(login.Username, login.Password);
                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, token);

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "username or password invalid");

                }
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
