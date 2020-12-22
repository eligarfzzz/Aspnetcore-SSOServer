using Microsoft.AspNetCore.Http;
using System;

namespace Utilities
{
    public class CookiesHelper
    {
        private HttpContext _httpContext;
        public CookiesHelper(HttpContext context)
        {
            _httpContext = context;
        }
        public string GetCookieValue(string key)
        {
            return _httpContext.Request.Cookies[key];
        }
        public void SetCookieValue(string key,string value)
        {
            _httpContext.Response.Cookies.Append(key, value, new CookieOptions()
            {
                MaxAge = new TimeSpan(1, 0, 0)
            });
        }
        public void SetCORSCookieValue(string key, string value)
        {
            _httpContext.Response.Cookies.Append(key, value, new CookieOptions()
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true,
                MaxAge = new TimeSpan(1, 0, 0)
            });
        }
    }
}
