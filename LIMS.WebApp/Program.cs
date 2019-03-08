﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;

namespace LIMS.WebApp
{
	public class Program
    {
        public static void Main(string[] args)
        {
			var appBasePath = System.IO.Directory.GetCurrentDirectory();
			NLog.GlobalDiagnosticsContext.Set("appbasepath", appBasePath); //does't work in IIS

			// NLog: setup the logger first to catch all errors
			var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
			try
			{
				logger.Debug("init main");

				var host = CreateWebHostBuilder(args).Build();
				host.Run();
			}
			catch (Exception ex)
			{
				//NLog: catch setup errors
				logger.Error(ex, "Stopped program because of exception");
				throw;
			}
			finally
			{
				// Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
				NLog.LogManager.Shutdown();
			}			
		}


		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)				
			.UseStartup<Startup>()
			.ConfigureLogging(logging => {
				logging.ClearProviders();
				logging.SetMinimumLevel(LogLevel.Trace);
			})
			.UseNLog();



	}

}