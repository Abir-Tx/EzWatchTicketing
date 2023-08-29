using EWT_BLL.DTOs;
using EWT_BLL.Services;
using EWT_UI.AuthFilters;
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
        [AdminFilter]
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
        [AdminFilter]
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
        [AdminFilter]
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
        [AdminFilter]
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
        [AdminFilter]
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

        [HttpPost]
        [Route("api/admin/movie/update")]
        [AdminFilter]
        public HttpResponseMessage UpdateMovie(MovieDTO movie)
        {
            try
            {
                bool updateSuccessful = MovieService.Update(movie);

                if (updateSuccessful)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Movie updated successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Movie not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/admin/ticket/update")]
        [AdminFilter]
        public HttpResponseMessage TicketUpdate(TicketDTO tic)
        {
            try
            {
                bool updateSuccessful = TicketService.Update(tic);

                if (updateSuccessful)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Movie updated successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Movie not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/admin/ticket/all")]
        [AdminFilter]
        public HttpResponseMessage TicketAll()
        {
            try
            {
                var data = TicketService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [AdminFilter]
        [Route("api/admin/ticket/get/{id}")]
        public HttpResponseMessage GetTicket(int id)
        {
            try
            {
                var data = TicketService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [AdminFilter]
        [Route("api/admin/ticket/update")]
        public HttpResponseMessage UpdateTicket(TicketDTO obj)
        {
            try
            {
                TicketService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Ticket Updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [AdminFilter]
        [Route("api/admin/ticket/delete")]
        public HttpResponseMessage DeleteTicket(int obj)
        {
            try
            {
                TicketService.Delete(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Ticket Deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [AdminFilter]
        [Route("api/admin/hall/all")]
        public HttpResponseMessage AllHall()
        {
            try
            {
                var data = HallService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [AdminFilter]
        [Route("api/admin/user/all")]
        public HttpResponseMessage AllUser()
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
        [HttpGet]
        [AdminFilter]
        [Route("api/admin/user/get/{id}")]
        public HttpResponseMessage GetUser(int id)
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
        [AdminFilter]
        [Route("api/admion/user/delete/{id}")]
        public HttpResponseMessage DeleteUser(int id)
        {
            if (UserService.Delete(id))
                return Request.CreateResponse(HttpStatusCode.OK, "The user with id: " + id + " has been deleted successfully");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, "cannot delete the requested user");
        }
    }
}
