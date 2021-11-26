using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953505_Grits.Middleware;
using Microsoft.AspNetCore.Builder;

namespace WEB_953505_Grits.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this IApplicationBuilder app)=> app.UseMiddleware<LogMiddleware>();
    }
}
