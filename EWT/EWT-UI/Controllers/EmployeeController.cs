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
        [EmployeeFilter]
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

        // The Login API for Employee
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

        // -------------------------------------------- Employee Feature APIs ---------------------------------------------

        // Update the movie by movie name
        [HttpPost]
        [Route("api/employee/movie/update")]
        [EmployeeFilter]
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


        [HttpGet]
        [Route("api/employee/movie/all")]
        [EmployeeFilter]
        public HttpResponseMessage GetAllMovie()
        {
            try { return Request.CreateResponse(HttpStatusCode.OK, MovieService.Get()); }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpPost]
        [Route("api/employee/movie/create")]
        [EmployeeFilter]
        public HttpResponseMessage AddNewMovie(MovieDTO movie)
        {
            MovieService.Create(movie);
            return Request.CreateResponse(HttpStatusCode.OK, "Movie id: " + movie.Id + " has been added to the database");
        }

        [HttpDelete]
        [Route("api/employee/movie/delete/{id}")]
        [EmployeeFilter]
        public HttpResponseMessage DeleteMovie(int id)
        {
            if (MovieService.Delete(id)) return Request.CreateResponse(HttpStatusCode.OK, "The movie with ID: " + id + " has been deleted successfully");
            else return Request.CreateResponse(HttpStatusCode.BadRequest, "Cannot delete the requested movie");
        }

        // ------------------------- ticket management --------------------------------------

        // Get Movie Tickets From Emp Endpoint
        [HttpGet]
        [Route("api/employee/movie/tickets")]
        [EmployeeFilter]
        public HttpResponseMessage GetMovieTickets() { 
            try { return Request.CreateResponse(HttpStatusCode.OK, MovieService.GetMovieTickets()); }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        // Delete a movie ticket by ID
        [HttpDelete]
        [Route("api/employee/movie/tickets/delete/{id}")]
        [EmployeeFilter]
        public HttpResponseMessage DeleteTicketsById(int id)
        {
            if (TicketService.Delete(id)) return Request.CreateResponse(HttpStatusCode.OK, "The ticket with ID: " + id + " has been deleted successfully");
            else return Request.CreateResponse(HttpStatusCode.BadRequest, "Can not delete the requested movie ticket");
        }

        // Update a ticket
        [HttpPost]
        [Route("api/employee/movie/tickets/update")]
        [EmployeeFilter]
        public HttpResponseMessage UpdateMovieTickets(TicketDTO ticket)
        {
            try
            {
                bool updateSuccessful = TicketService.Update(ticket);

                if (updateSuccessful)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Movie Ticket updated successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Movie Ticket not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // ------------------------------------------------------------- General User Management ------------------------------------------------


        // Get all user list
        [HttpGet]
        [Route("api/employee/user/userlist")]
        [EmployeeFilter]
        public HttpResponseMessage GetAllUserList()
        {
            try { return Request.CreateResponse(HttpStatusCode.OK, UserService.Get()); }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        // Get specific user using ID
        [HttpGet]
        [Route("api/employee/user/{id}")]
        [EmployeeFilter]
        public HttpResponseMessage GetSingleUser(int id)
        {
            try { return Request.CreateResponse(HttpStatusCode.OK, UserService.Get(id)); }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }
    }
}