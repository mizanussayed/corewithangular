using BackEnd.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(ob => ob.EnableEndpointRouting = false);
            services.AddDbContext<Context>();
            services.AddCors();
        }

    
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(ob =>
            {
                ob.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
            });

            app.UseMvcWithDefaultRoute();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
               endpoints.MapGet("/", async context =>
                {
                   await context.Response.WriteAsync("Hello World!");
               });
            });
        }
    }
}
