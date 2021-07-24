using System.Linq;
using Microsoft.AspNetCore.Http;

namespace TweetBook.Extensions
{
    public static class GeneralExtensions
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            return httpContext?.User.Claims.Single(x => x.Type == "id").Value; // id from token
        }
    }
}
