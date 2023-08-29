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
    public class BookingController : ApiController
    {
        [HttpGet]
        [Route("api/booking/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = BookingService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/booking/create")]
        public HttpResponseMessage Create(BookingDTO obj)
        {
            try
            {

                obj.Status = 0;

                BookingService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Created" });
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/booking/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = BookingService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/booking/update/{id}")]
        public HttpResponseMessage Update(BookingDTO obj)
        {
            try
            {
                BookingService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/booking/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                BookingService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
