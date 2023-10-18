using API_NetCore.Helpers;
using Microsoft.AspNetCore.Identity;

namespace API_NetCore.Authorization
{
    public class JwtMiddleware 
    {
        public readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, AppSettings appSettings)
        {
            _next = next;
            _appSettings = appSettings;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {

        }

        public interface IUserService
        {
        }
    }
}
