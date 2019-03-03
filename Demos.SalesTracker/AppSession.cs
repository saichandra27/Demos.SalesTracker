using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Demos.SalesTracker
{
    public class AppSession
    {
        public static string UserId
        {
            get
            {
                var principal = ClaimsPrincipal.Current;
                var identity = (ClaimsIdentity)principal.Identity;
                var nameClaim = identity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                var userId = nameClaim.Value;
                return userId;
            }
        }
    }
}