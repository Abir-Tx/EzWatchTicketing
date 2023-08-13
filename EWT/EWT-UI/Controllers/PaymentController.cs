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
    public class PaymentController : ApiController
    {

        [HttpPost]
        [Route("api/payment/create")]
        public HttpResponseMessage Create(PaymentDTO obj)
        {
            try
            {
                PaymentServices.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "added" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/payment/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = PaymentServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }

}
