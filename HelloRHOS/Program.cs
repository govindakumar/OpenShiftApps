using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRHOS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddEnvironmentVariables("").Build();
            var url = config["ASPNETCORE_URLS"] ?? "http://*:5060";
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls(url)
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
            host.Run();
            //CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder().AddEnvironmentVariables("").Build();
            var url = config["ASPNETCORE_URLS"] ?? "http://*:5060";
            return  Host.CreateDefaultBuilder(args)

                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                        webBuilder.UseUrls(url);
                        webBuilder.UseKestrel();
                        
                        webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                        webBuilder.UseIISIntegration();

                    });


        }


    }
}
