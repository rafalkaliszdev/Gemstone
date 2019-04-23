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

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var builder = new ContainerBuilder();

            // register all Gemstone services
            RegisterServices(builder);

            builder.Populate(services);
            this.ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }

        public void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ProfessionalService>().As<IProfessionalService>().InstancePerLifetimeScope();
        }
    }
}
