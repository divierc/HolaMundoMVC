using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolaMundoMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HolaMundoMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build(); // se cambia la ejecucion el run va a l final
            // para que no se quede en memoria se utilisa using
            using(var scope = host.Services.CreateScope())
            {   
                // se para que nada quede en memoria al terminar se usa using
                var services= scope.ServiceProvider;
                try {
                    var context = services.GetRequiredService<EscuelaContext>();
                    context.Database.EnsureCreated();
                }catch(Exception exception){
                    var logger = services.GetRequiredService<ILogger>();
                    logger.LogError(exception, "An error ocurred creating the Database.");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
