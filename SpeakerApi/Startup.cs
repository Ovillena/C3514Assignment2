using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SpeakerApi.Data;

namespace SpeakerApi
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

            // Add Cors
            services.AddCors(o => o.AddPolicy("Policy", builder => {
                builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
            }));

            //          services.AddDbContext<SpeakerDbContext>(
            //option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            var host = Configuration["DBHOST"] ?? "localhost";
            var port = Configuration["DBPORT"] ?? "1444";
            var user = Configuration["DBUSER"] ?? "sa";
            var pwd = Configuration["DBPASSWORD"] ?? "SqlExpress!";
            var conStr = $"Server=tcp:{host},{port};Database=speakerdb;UID={user};PWD={pwd};";
            services.AddDbContext<SpeakerDbContext>(options => options.UseSqlServer(conStr));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpeakerApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SpeakerDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpeakerApi v1"));
            }

            context.Database.Migrate();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            context.Database.Migrate();

            app.UseCors("Policy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
