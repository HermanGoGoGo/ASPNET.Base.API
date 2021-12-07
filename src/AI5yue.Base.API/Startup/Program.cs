using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AI5yue.Base.API.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .ConfigureAppConfiguration(configBuilder =>
                {
                    var environmentVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    configBuilder.AddJsonFile(Path.Combine(".", $"appsettings.{environmentVariable}.json"));
                    //configBuilder.AddXmlFile("log4net.config", false, true);
                })
                .Build();

            host.Run();
        }
    }
}


