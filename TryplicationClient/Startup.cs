using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TryplicationClient.Services;

namespace TryplicationClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IClientCredentials, ClientCredentials>();
            services.AddSingleton<IAccessTokenStore, AccessTokenStore>();
            services.AddTransient<AuthenticationDelegatingHandler>();
            services.AddHttpClient<AccessTokenService>();
            services.AddHttpClient<TicketsAPIService>()
                    .AddHttpMessageHandler<AuthenticationDelegatingHandler>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.Authority = "https://localhost:5000";
                        options.Audience = "Tryplication";
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                    policy.RequireClaim("Scope", new string[] { "ticketapi.admin" }));

                options.AddPolicy("RegularUser", policy =>
                    policy.RequireClaim("Scope", new string[] { "ticketapi.admin", "ticketapi.readwrite" }));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}