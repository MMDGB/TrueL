using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Tryplication.Services;

namespace TryplicationTest
{
    public class TicketsEmployeeApiWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(c =>
            {
                c.AddSingleton<ITicketGenerator, TicketGenerator>();
            });
        }
    }
}
