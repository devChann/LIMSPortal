﻿using LIMS.Infrastructure.Services.Notification;
using LIMS.Infrastructure.Services.Properties;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIMS.WebApp.Hubs
{
    public class PaymentsHub: Hub
    {
		private readonly IParcelService _parcelService;
		private readonly IConfiguration _configuration;

		public PaymentsHub(IParcelService parcelService,IConfiguration configuration)
		{
			_parcelService = parcelService;
			_configuration = configuration;
		}

		public Task RegisterProduct(string query)
		{
			_parcelService.GetParcelbyFilter(query);
			return Clients.All.SendAsync("UpdateParcels", _parcelService.GetParcels());
		}

		public async Task SellProduct(string query)
		{
			_parcelService.GetParcelbyFilter(query);
			await Clients.All.SendAsync("UpdateParcels", _parcelService.GetParcels());
		}


		public void Notify()
		{

			var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(_configuration.GetConnectionString("LIMS.CoreDbConnection"));

			var server = builder.DataSource;
			var database = builder.InitialCatalog;
			// See constructor optional parameters to configure it according to your needs
			var listener = new SqlDependencyEx(_configuration.GetConnectionString("LIMS.CoreDbConnection"), database, "MpesaTransaction");

			

			// After you call the Start method you will receive table notifications with 
			// the actual changed data in the XML format
			listener.Start();

			// ... Your code is here
			// e.Data contains actual changed data in the XML format
			listener.TableChanged += (o, e) =>
			{
				Console.WriteLine($"Your table was changed!{e.Data}");
			};

			// Don't forget to stop the listener somewhere!
			//listener.Stop();
		}
	}
}
