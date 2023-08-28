using EWT_BLL.Services;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EWT_UI.AuthFilters
{
    public class UserFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var header = actionContext.Request.Headers.Authorization;
            if (header == null) 
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Msg = "No token Supplied" });
            
            }
            else
            {
                var token = header.ToString();
                if (token != null && !AuthService.IsUser(token)) 
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Msg = "supplied token is invalid or expired" });
                }
            }

            base.OnAuthorization(actionContext);
        }
    }
}