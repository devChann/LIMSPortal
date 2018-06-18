using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using LIMSCore.Entities;


namespace LIMSCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            var host = CreateWebHostBuilder(args).Build(); 

            host.Run();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }

}
