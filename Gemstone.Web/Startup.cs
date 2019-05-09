using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Gemstone.Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Gemstone.Core.Interfaces;
using Gemstone.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Gemstone.Infrastructure;
using Gemstone.Core.DomainModels;

namespace Gemstone
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<SpecialistService>().As<ISpecialistService>().InstancePerLifetimeScope();
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepository<Account>, AccountRepository>();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GemstoneDbContext>(dbContextOptionsBuilder =>
                dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("GemstoneDatabase")));

            AddRepositories(services);

            services.AddMvc(mvcOptions =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                mvcOptions.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(cookieAuthenticationOptions =>
                {
                    cookieAuthenticationOptions.LoginPath = new PathString("/Account/LogIn");
                    cookieAuthenticationOptions.LogoutPath = new PathString("/Account/LogOut");
                });

            services.AddAuthorization(authorizationOptions =>
            {
                authorizationOptions.AddPolicy("AssignorOnly", policy => policy.RequireRole("Assignor"));
            });

            services.AddHttpContextAccessor(); // best possible way to register HttpContext

            // todo this is required by session but suprisingly I didnt use it so far and it worked fine
            services.AddDistributedMemoryCache();

            // todo should be rather part of auth middleware
            services.AddSession(sessionOptions =>
            {
                sessionOptions.Cookie.Name = ".session";
                sessionOptions.Cookie.Path = "/";
                sessionOptions.Cookie.HttpOnly = true; // client-side scripting won't access cookie, http request only
                sessionOptions.Cookie.IsEssential = true;
                sessionOptions.IdleTimeout = TimeSpan.FromSeconds(10); // how long session can be idle before it is abandoned (does not affect cookie on client browser)
            });


            var builder = new ContainerBuilder();

            RegisterTypes(builder);

            builder.Populate(services);

            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // detailed info, stack trace etc
            }
            else
            {
                app.UseExceptionHandler(error =>
                {
                    error.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/html";

                        await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
                        await context.Response.WriteAsync("Exception<br><br>\r\n");

                        var exceptionHandlerPathFeature =
                            context.Features.Get<IExceptionHandlerPathFeature>();

                        if (exceptionHandlerPathFeature?.Error is Exception)
                        {
                            await context.Response.WriteAsync("Generic exception thrown<br><br>\r\n");
                        }

                        await context.Response.WriteAsync("<a href=\"/\">Home</a><br>\r\n");
                        await context.Response.WriteAsync("</body></html>\r\n");
                    });
                });
            }

            app.UseHttpsRedirection();

            app.UseCookiePolicy(); // adds CookiePolicyMiddleware required by auth
            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvcWithDefaultRoute();
        }
    }
}