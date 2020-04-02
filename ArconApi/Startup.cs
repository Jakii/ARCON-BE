using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using ArconApi.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ArconApi.Features.Categories;
using ArconApi.Features.Users.UsersApps;
using Microsoft.OpenApi.Models;
using AutoMapper;
using ArconApi.Common;
using ArconApi.Feature.Activities;

namespace ArconApi
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
         

        services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        services.AddControllers();
             
        //Register the Swagger generator, defining 1 or more Swagger documents
        services.AddSwaggerGen(c =>
        {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Arcon Api", Version = "v1" });
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<CategoryAppServices>();
        services.AddTransient<UserAppServices>();
        services.AddTransient<ActivityAppServices>();

         var mappingConfig= new MapperConfiguration(mc=>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper= mappingConfig.CreateMapper();
           services.AddSingleton(mapper);
                // Add service and create Policy with options
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
                    
                    
           });
        // services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        //         .AddEntityFrameworkStores<ApplicationDbContext>();
        //     services.AddRazorPages();
        //          services.Configure<IdentityOptions>(options =>
        // {
        //     // Password settings.
        //     options.Password.RequireDigit = true;
        //     options.Password.RequireLowercase = true;
        //     options.Password.RequireNonAlphanumeric = true;
        //     options.Password.RequireUppercase = true;
        //     options.Password.RequiredLength = 6;
        //     options.Password.RequiredUniqueChars = 1;

        //     // Lockout settings.
        //     options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        //     options.Lockout.MaxFailedAccessAttempts = 5;
        //     options.Lockout.AllowedForNewUsers = true;

        //     // User settings.
        //     options.User.AllowedUserNameCharacters =
        //     "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        //     options.User.RequireUniqueEmail = false;
        // });

        // services.ConfigureApplicationCookie(options =>
        // {
        //     // Cookie settings
        //     options.Cookie.HttpOnly = true;
        //     options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

        //     options.LoginPath = "/Identity/Account/Login";
        //     options.AccessDeniedPath = "/Identity/Account/AccessDenied";
        //     options.SlidingExpiration = true;
        // });

}
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
             app.UseCors("CorsPolicy");
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
           

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            //specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Arcon Api V1");
            c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
            app.UseDeveloperExceptionPage();
           // app.UseDatabaseErrorPage();
            }
            // else
            // {
            //     app.UseExceptionHandler("/Error");
            //     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //     app.UseHsts();
            // }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapRazorPages();
            // });

            app.UseEndpoints(endpoints =>
            {
            endpoints.MapControllers();
            });
        }
    }
}
