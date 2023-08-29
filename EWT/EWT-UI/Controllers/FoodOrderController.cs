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
    public class FoodOrderController : ApiController
    {
        [HttpPost]
        [Route("api/orderfood/create")]
        public HttpResponseMessage Create(OrderFoodDTO obj)
        {
            try
            {
                OrderFoodService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = "order Created" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/orderfood/all")]
        public HttpResponseMessage All()
        {
            try
            {
                var data = OrderFoodService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/order/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = OrderFoodService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/orderfood/update")]
        public HttpResponseMessage Update(OrderFoodDTO obj)
        {
            try
            {
                OrderFoodService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = " Updated" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/orderfood/delete")]
        public HttpResponseMessage Delete(int obj)
        {
            try
            {
                OrderFoodService.Delete(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { msg = " Deleted" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        
    }
}
