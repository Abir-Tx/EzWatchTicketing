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
    public class HallController : ApiController
    {
        [HttpPost]
        [Route("api/hall/create")]
        public HttpResponseMessage Create(HallDTO obj)
        {
            try
            {
                HallService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "New Cinema Hall Created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/hall/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = HallService.Get();
                return Request.CreateResponse(HttpStatusCode.OK,data);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/hall/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = HallService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/hall/update")]
        public HttpResponseMessage Update(HallDTO obj)
        {
            try
            {
                HallService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Ticket Updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/hall/delete")]
        public HttpResponseMessage Delete(int obj)
        {
            try
            {
                HallService.Delete(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "hall Deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/hall/{id}/seat")]
        public HttpResponseMessage GetSeatbyHall(int id)
        {
            try
            {
                var data = HallService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
