using EWT_BLL.DTOs;
using EWT_BLL.Services;
using EWT_UI.AuthFilters;
using EWT_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EWT_UI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("api/employee/all")]
        //[Authorize(Roles = "Employee")]
        [LoginFilter]
        public HttpResponseMessage All()
        {
            try
            {
                var data = EmployeeService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/employee/create")]
        public HttpResponseMessage Create(EmployeeDTO employee)
        {
            try
            {
                var data = EmployeeService.Create(employee);
                return Request.CreateResponse(HttpStatusCode.OK, "New Employee Added Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/employee/get/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var data = EmployeeService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/employee/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            if (EmployeeService.Delete(id)) return Request.CreateResponse(HttpStatusCode.OK, "The Employee with ID: " + id + " has been deleted successfully");
            else return Request.CreateResponse(HttpStatusCode.BadRequest, "Cannot delete the requested Employee");
        }

        [HttpPut]
        [Route("api/employee/update")]
        public HttpResponseMessage Update(EmployeeDTO emp)
        {
            EmployeeService.Update(emp);
            return Request.CreateResponse(HttpStatusCode.OK, "Employee ID: " + emp.Id + " has been updated successfully");
        }

        [HttpPost]
        [Route("api/employee/login")]
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