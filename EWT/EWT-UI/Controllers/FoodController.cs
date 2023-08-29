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
    public class FoodController : ApiController
    {

        [HttpGet]
        [Route("api/food/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = FoodService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpPost]
        [Route("api/food/create")]
        public HttpResponseMessage Create(FoodDTO obj)
        {
            try
            {
                FoodService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Created" });

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/food/get/{id}")]

        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = FoodService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/food/update/{id}")]
        public HttpResponseMessage Update(FoodDTO obj)
        {
            try
            {
                FoodService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/food/delete/{id}")]
        public HttpResponseMessage Delete(int obj)
        {
            try
            {
                FoodService.Delete(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
    