using fakeLook_dal.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fakeLook_starter.Interfaces;
using fakeLook_starter.Repositories;

namespace fakeLook_starter
{
    public class Startup
    {
        private readonly string _MyAllowSpecificOrigin = "myAlloworigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            #region Setting repository and services interfaces
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            #endregion
            #region Setting DB configuration
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
            #endregion
            #region Setting cors policy
            services.AddCors(options =>
            {
                options.AddPolicy(name: _MyAllowSpecificOrigin, builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            #endregion
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "fakeLook_starter", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext data)
        {
            data.Database.EnsureCreated();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "fakeLook_starter v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
