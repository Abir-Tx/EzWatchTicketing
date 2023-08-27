using System;
using System.Web.Http.Controllers;

namespace EWT_UI.AuthFilters
{
    public class AuthenticationFilterAttribute
    {
        internal void OnAuthorization(HttpActionContext actionContext)
        {
            throw new NotImplementedException();
        }
    }
}