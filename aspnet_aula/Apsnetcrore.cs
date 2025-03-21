using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing.Matching;

namespace Aspnet_aula
{
    public class Apsnetcrore
    {
        public static void Main(string []args)
        {
            var Builder = WebApplication.CreateBuilder(args);
            var app = Builder.Build();
            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>{
                endpoints.MapGet("/", async context => {
                    context.Response.Redirect("/index.html");
                });
            });
            app.Run();
        }
        
    }
}