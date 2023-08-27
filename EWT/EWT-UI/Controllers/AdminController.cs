using EWT_BLL.DTOs;
using EWT_BLL.Services;
using EWT_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EWT_UI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/admin/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = AdminService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        [Route("api/admin/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = AdminService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/admin/create")]
        public HttpResponseMessage Create(AdminDTO obj)
        {
            try
            {
                AdminService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new {msg="Admin Created"});
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/admin/Update")]
        public HttpResponseMessage Update(AdminDTO obj)
        {
            try
            {
                AdminService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Admin Updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/admin/delete")]
        public HttpResponseMessage Delete(int obj)
        {
            try
            {
                AdminService.Delete(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Admin Deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/admin/login")]
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
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Username or password invalid");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
