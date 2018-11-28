using System;
using knapsack.Controllers;
using knapsack.DependencyResolver;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace knapsack
{
    public class Startup
    {
        private readonly Container _container;

        public Startup(IConfiguration configuration, Container container)
        {
            _container = container;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IGreeting, Greeting>();
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(this._container));
            return this.IntegrateSimpleInjector(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeting greeting)
        {
            _container.AutoCrossWireAspNetComponents(app);
            _container.RegisterMvcControllers(app);
            Bootstrapper.InitializeContainer(this._container);
 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            


            app.UseStaticFiles();
            app.UseMvc(routeBuilder => routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}"));

//            app.Use(next =>
//            {
//                return async context =>
//                {
//                    if (context.Request.Path.StartsWithSegments("/wtf"))
//                    {
//                        await context.Response.WriteAsync("WTF Bro!!");
//                    }
//                    else
//                    {
//                        await next(context);
//                    }
//                };
//            });
            
//            app.Run(async (context) =>
//            {
//                await context.Response.WriteAsync(greeting.GetGreeting());
//                
//            });
        }

        private IServiceProvider IntegrateSimpleInjector(IServiceCollection services)
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            _container.Options.DefaultLifestyle = Lifestyle.Scoped;
            
            services.EnableSimpleInjectorCrossWiring(this._container);
            services.UseSimpleInjectorAspNetRequestScoping(this._container);
            return services.BuildServiceProvider();
        }
    }
}