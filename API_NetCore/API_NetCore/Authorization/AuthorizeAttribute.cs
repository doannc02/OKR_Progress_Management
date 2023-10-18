using API_NetCore.Models.Entitiess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace API_NetCore.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly Role _role;
        public AuthorizeAttribute(Role roles)
        {
            _role = roles;
        }
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            // skip authoriztion if action id decorated with allowanonymuos attibute
            var allowAnonymous = filterContext.ActionDescriptor.EndpointMetadata.OfType<AllowAnoymousAttribute>();
            if (allowAnonymous.Any()) { return; };

            // authorization 
            var user = (User)filterContext.HttpContext.Items["User"];
            if (user == null || (_role.Name == user.Role))
            {
                filterContext.Result = new JsonResult(new { message = "Unauthorized" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };

            }

        }
    }
}
