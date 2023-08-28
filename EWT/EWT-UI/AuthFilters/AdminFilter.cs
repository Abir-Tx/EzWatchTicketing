﻿using EWT_BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EWT_UI.AuthFilters
{
    public class AdminFilter : AuthorizationFilterAttribute
    {
            public override void OnAuthorization(HttpActionContext actionContext)
            {
                var header = actionContext.Request.Headers.Authorization;
                if (header == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Msg = "No token supplied" });
                }
                else
                {
                    var token = header.ToString();
                    if (token != null && !AuthService.IsAdmin(token))
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Msg = "Supplied token is invalid or expired" });
                    }
                }

                base.OnAuthorization(actionContext);
        }
    }
}