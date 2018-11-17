using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace knapsack
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IGreeting, Greeting>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeting greeting)
        {
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
    }
}