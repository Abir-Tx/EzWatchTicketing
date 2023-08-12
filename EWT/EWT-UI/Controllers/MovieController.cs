using EWT_BLL.DTOs;
using EWT_BLL.Services;
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

        [HttpPost]
        [Route("api/movie/create")]
        public HttpResponseMessage Create(MovieDTO movie)
        {
            MovieService.Create(movie);
            return Request.CreateResponse(HttpStatusCode.OK, "Movie id: " + movie.Id + " has been added to the database");
        }
    }
}
