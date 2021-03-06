// <copyright file="Startup.cs" company="Principal 33 Solutions">
// Copyright (c) Principal 33 Solutions. All rights reserved.
// </copyright>


using HelloWorldWeb.Controllers;
using HelloWorldWeb.Services;
using HelloWorldWebMVC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using HelloWorldWeb.Data;

namespace HelloWorldWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            
        }

      

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            //  services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)

            //.AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            
            services.AddControllersWithViews();
            services.AddSingleton<IWeatherControllerSettings, WeatherControllerSettings>();
            services.AddSingleton<ITeamService, TeamService>();
            services.AddSingleton<ITimeService, TimeService>();
            services.AddScoped<ITeamService, DbTeamService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hello World API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath,includeControllerXmlComments: true);
            });

            services.AddSignalR();
            services.AddSingleton<IBroadcastService, BroadcastService>();
            AssignRoleProgramaticaly(services.BuildServiceProvider());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHub<MessageHub>("/messagehub");

            });
            

           
        }

        private async void AssignRoleProgramaticaly(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var user = await userManager.FindByNameAsync("parpalea.radu98@gmail.com");
            await userManager.AddToRoleAsync(user, "Administrators");
        }

        public static string ConvertHerokuStringToAspnetString(string herokuConnectionString)
        {
            var databaseUri = new Uri(herokuConnectionString);
            string databaseUriArray = databaseUri.UserInfo;
            
            var databaseUriUsername = databaseUriArray.Split(':')[0];
            var databaseUriPassword = databaseUriArray.Split(':')[1];
            var databaseName = databaseUri.LocalPath.TrimStart('/'); 
            return $"Host={databaseUri.Host};Port={databaseUri.Port};Database={databaseName};User Id={databaseUriUsername};Password={databaseUriPassword};Pooling=true;SSL Mode=Require;TrustServerCertificate=True;";



        }
    }
}
