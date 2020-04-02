using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tryplication.Middleware
{
    public class MyHeaderPass
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration configuration;
        private readonly ILogger _logger;

        public MyHeaderPass(RequestDelegate next, IConfiguration configuration, ILoggerFactory factory)
        {
            this.next = next;
            this.configuration = configuration;
            _logger = factory.CreateLogger("MyHeaderPassMiddleware");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //if (!(context.Request.Headers["check-header-filter"] != configuration.GetValue<string>("ApiKey")))
            if (context.Request.Headers["check-header-filter"] != configuration.GetValue<string>("ApiKey"))
            {
                _logger.LogError("The header check was invalid !!");
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Invalid Pass");
                return;
            }
            _logger.LogTrace("The header check was succesfully done!!");
            await next(context);
        }
    }
}
