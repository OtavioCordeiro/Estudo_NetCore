﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Greetings
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeting, RandomGreeting>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeting greetings, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(next =>
            {
                return async context =>
                {
                    logger.Log(LogLevel.Information, "Entrada");
                    if (context.Request.Path.StartsWithSegments("/log"))
                    {
                        await context.Response.WriteAsync("Hit!!");
                        logger.LogInformation("Requisição tradada");
                    }
                    else
                    {
                        await next(context);
                        logger.LogInformation("Requisição invalida");
                    }
                };
            });

            app.UseWelcomePage("/bemvindo");

            app.UseMvc(ConfigurationRountes);

            app.Run(async (context) =>
            {
                var messageOfDay = greetings.GetMessageOfDay();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(messageOfDay);
            });
        }

        private void ConfigurationRountes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default",
                "{controller=home}/{action=index}/{id?}");

        }
    }
}
