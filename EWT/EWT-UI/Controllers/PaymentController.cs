using EWT_BLL.DTOs;
using EWT_BLL.Services;
using System;
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
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Payment created successfully." });
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

        [HttpGet]
        [Route("api/payment/{id}")]
        public HttpResponseMessage GetPayment(int id)
        {
            try
            {
                var payment = PaymentServices.Get(id);
                if (payment == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { msg = "Payment not found." });

                return Request.CreateResponse(HttpStatusCode.OK, payment);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/payment/update")]
        public HttpResponseMessage Update(PaymentDTO obj)
        {
            try
            {
                var updated = PaymentServices.Update(obj);
                if (!updated)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { msg = "Payment not updated." });

                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Payment updated successfully." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/payment/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var deleted = PaymentServices.Delete(id);
                if (!deleted)
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { msg = "Payment not deleted." });

                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "Payment deleted successfully." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
