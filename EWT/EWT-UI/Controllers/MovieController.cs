using EWT_BLL.DTOs;
using EWT_BLL.Services;
using EWT_UI.AuthFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EWT_UI.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
        [Route("api/movie/all")]
        public HttpResponseMessage All()
        {
            try { return Request.CreateResponse(HttpStatusCode.OK, MovieService.Get()); }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        [HttpGet]
        [Route("api/movie/get/{id}")]
        public HttpResponseMessage GetById(int id)
        {
            try { return Request.CreateResponse(HttpStatusCode.OK, MovieService.Get(id)); }
            catch (Exception ex) { return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message); }
        }

        // Authorized Endpoints
        [HttpPost]
        [Route("api/movie/create")]
        [EmployeeFilter]
        public HttpResponseMessage Create(MovieDTO movie)
        {
            MovieService.Create(movie);
            return Request.CreateResponse(HttpStatusCode.OK, "Movie id: " + movie.Id + " has been added to the database");
        }

        [HttpPut]
        [Route("api/movie/update")]
        [EmployeeFilter]
        public HttpResponseMessage Update(MovieDTO movie)
        {
            MovieService.Update(movie);
            return Request.CreateResponse(HttpStatusCode.OK, "Movie ID: " + movie.Id + " has been updated successfully");
        }

        [HttpDelete]
        [Route("api/movie/delete/{id}")]
        [EmployeeFilter]
        public HttpResponseMessage Delete(int id)
        {
            if (MovieService.Delete(id)) return Request.CreateResponse(HttpStatusCode.OK, "The movie with ID: " + id + " has been deleted successfully");
            else return Request.CreateResponse(HttpStatusCode.BadRequest, "Cannot delete the requested movie");
        }

    }
}
