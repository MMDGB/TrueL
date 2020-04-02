using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Tryplication.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger _logger;

        public ErrorController(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger("TicketController");
        }

        [Route("api/error")]
        public IActionResult LogError()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>(); 
            if(exception != null)
            {
                string path = exception.Path;
                Exception ex = exception.Error;

                switch (exception.GetType().Name)
                {
                    case "ExceptionHandlerMiddleware":
                    case "ExceptionHandlerFeature":
                    case "NotImplementedException":
                    case "FormatException":
                        _logger.LogError("Exception not handled: {error}", ex.Message);
                        var error = new { ErrorMessage = ex.Message, ErrorPath = path };
                        return BadRequest(error);

                    default:
                        return Ok();
                }

            }
            return Ok();
        }
    }
}
