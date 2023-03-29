using MasterOfCoinsAPI.Interfaces;
using MasterOfCoinsAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System.Data;
using System.Data.SqlClient;

namespace MasterOfCoinsAPI
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
            var connectionString = this.Configuration.GetConnectionString("MasterOfCoins");
            services.AddTransient<IDbConnection>(conn => new SqlConnection(connectionString));
            services.AddScoped<IBuddyRepository, BuddyRepository>();
            services.AddScoped<IGroupDetailsRepository, GroupDetailsRepository>();
            services.AddCors(c => {
                c.AddPolicy("AllowOrigin",
                    options => options.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
            });

            //services.AddControllersWithViews()
            //    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            //    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
