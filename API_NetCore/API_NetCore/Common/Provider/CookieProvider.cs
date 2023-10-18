using Microsoft.AspNetCore.Http;
using System;

namespace OKEA.Library.Common.Providers
{
    public class CookieProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CookieProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void Set(string key, string value, int? expireTime = 3600)
        {
            expireTime ??= 3600;

            var option = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(expireTime.Value)
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, option);
        }
        public string Get(string key)
        {
            return _httpContextAccessor.HttpContext.Request.Cookies[key];
        }
        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }
        public void RemoveAlls()
        {
            foreach (string key in _httpContextAccessor.HttpContext.Request.Cookies.Keys)
            {
                Remove(key);
            }
        }
    }
}
