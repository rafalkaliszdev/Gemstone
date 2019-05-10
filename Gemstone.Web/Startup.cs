﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using Gemstone.Core.DomainModels;
using Gemstone.Core.Interfaces;
using Gemstone.Core.Services;
using Gemstone.Infrastructure;
using Gemstone.Infrastructure.DataInitialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

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
                throw new NotImplementedException();
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