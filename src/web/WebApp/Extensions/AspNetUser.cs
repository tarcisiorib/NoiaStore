using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace WebApp.Extensions
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AspNetUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Name => _httpContextAccessor.HttpContext.User.Identity.Name;

        public IEnumerable<Claim> GetClaims()
        {
            return _httpContextAccessor.HttpContext.User.Claims;
        }

        public HttpContext GetHttpContext()
        {
            return _httpContextAccessor.HttpContext;
        }

        public string GetUserEmail()
        {
            return IsAuthenticated() ? _httpContextAccessor.HttpContext.User.GetUserEmail() : "";
        }

        public Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(_httpContextAccessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }

        public string GetUserToken()
        {
            return IsAuthenticated() ? _httpContextAccessor.HttpContext.User.GetUserToken() : "";
        }

        public bool HasRole(string role)
        {
            return _httpContextAccessor.HttpContext.User.IsInRole(role);
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst("sub");
            return claim?.Value;
        }
        
        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst("email");
            return claim?.Value;
        }
        
        public static string GetUserToken(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));

            var claim = principal.FindFirst("JWT");
            return claim?.Value;
        }
    }
}
