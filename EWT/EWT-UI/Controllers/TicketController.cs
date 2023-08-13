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
    public class TicketController : ApiController
    {
        [HttpGet]
        [Route("api/ticket/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = TicketService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        [Route("api/ticket/get/{id}")]
        public HttpResponseMessage Get(int id)
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
        [Route("api/ticket/create")]
        public HttpResponseMessage Create(TicketDTO obj)
        {
            try
            {
                TicketService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Ticket Created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/ticket/update")]
        public HttpResponseMessage Update(TicketDTO obj)
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
        [Route("api/ticket/delete")]
        public HttpResponseMessage Delete(int obj)
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
    }
}
