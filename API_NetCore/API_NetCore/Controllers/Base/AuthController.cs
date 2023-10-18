using Microsoft.AspNetCore.Mvc;
using OKEA.Library.Models.Cache;
using static API_NetCore.Common.Constants;

namespace OKEA.Service.Main.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("admin")]
        public AdminCache GetCurrentAdmin()
        {
            return (AdminCache)RouteData.Values[Regular.CurrentUserAdminKey];
        }

        [HttpGet("user")]
        public UserCache GetCurrentUser()
        {
            return (UserCache)RouteData.Values[Regular.CurrentUserCustomerKey];
        }

        [HttpGet("isAdminAuthenticated")]
        public bool IsAdminAuthenticated()
        {
            return GetCurrentAdmin() != null;
        }

        [HttpGet("isMemberUserAuthenticated")]
        public bool IsMemberUserAuthenticated()
        {
            return GetCurrentUser() != null;
        }

        [HttpGet("isSuperAdmin")]
        public bool IsSuperAdmin()
        {
            var currentAdmin = GetCurrentAdmin();
            return currentAdmin != null && currentAdmin.IsSupperAdmin;
        }

        [HttpGet("isAdmin")]
        public bool IsAdmin()
        {
            return IsAdminAuthenticated();
        }

        [HttpGet("isMemberUser")]
        public bool IsMemberUser()
        {
            return IsMemberUserAuthenticated();
        }

    }
}
