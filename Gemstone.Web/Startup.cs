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

namespace Gemstone
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<SpecialistService>().As<ISpecialistService>().InstancePerLifetimeScope();
            builder.RegisterType<ExaminationService>().As<IExaminationService>().InstancePerLifetimeScope();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
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

            services.AddSession(options =>
            {
                options.Cookie.Name = ".session";
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.IsEssential = true;
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
