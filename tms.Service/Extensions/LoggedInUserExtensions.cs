using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using tms.Entity.Entities;

namespace tms.Service.Extensions
{
    public static class LoggedInUserExtensions
    {

        public static string GetLoggidInUserEmail(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Email);
        }
    }
}
