using Autofac;
using Autofac.Extensions.DependencyInjection;
using Gemstone.Core.DomainModels;
using Gemstone.Core.Interfaces;
using Gemstone.Core.Services;
using Gemstone.Infrastructure;
using Gemstone.Infrastructure.Data;
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
using AutoMapper;
using Gemstone.Web.Extensions;
using Swashbuckle.AspNetCore.Swagger;

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
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerLifetimeScope();
            builder.RegisterType<SpecialistService>().As<ISpecialistService>().InstancePerLifetimeScope();
            builder.RegisterType<AssignorService>().As<IAssignorService>().InstancePerLifetimeScope();
            builder.RegisterType<AssignmentService>().As<IAssignmentService>().InstancePerLifetimeScope();
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepository<Account>, AccountRepository>();
            services.AddScoped<IRepository<Specialist>, SpecialistRepository>();
            services.AddScoped<IRepository<Assignor>, AssignorRepository>();
            services.AddScoped<IRepository<Assignment>, AssignmentRepository>();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EfDbContext>(dbContextOptionsBuilder =>
                dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            AddRepositories(services);

            services.AddMvc(mvcOptions =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                mvcOptions.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddDistributedMemoryCache();
            services.AddSession(sessionOptions =>
            {
                sessionOptions.Cookie.Name = ".session";
                sessionOptions.Cookie.Path = "/";
                sessionOptions.Cookie.HttpOnly = true;
                sessionOptions.Cookie.IsEssential = true;
                sessionOptions.IdleTimeout = TimeSpan.FromSeconds(10);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(cookieAuthenticationOptions =>
                {
                    cookieAuthenticationOptions.LoginPath = new PathString("/Account/Login");
                    cookieAuthenticationOptions.LogoutPath = new PathString("/Account/Logout");
                });

            services.AddAuthorization(authorizationOptions =>
            {
                authorizationOptions.AddPolicy("AssignorOnly", policy => policy.RequireRole("Assignor"));
            });

            services.AddHttpContextAccessor();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mappingConfig.CreateMapper());

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Account Entity API", Description = "Account is base abstract class for all instantiated users" });
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
                app.UseDeveloperExceptionPage();
            }
            else
            {
                throw new NotImplementedException();
            }

            app.UseHttpsRedirection();

            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseSession();

            app.UseSwagger();
            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Account API"));

            app.UseMvcWithDefaultRoute();
        }
    }
}