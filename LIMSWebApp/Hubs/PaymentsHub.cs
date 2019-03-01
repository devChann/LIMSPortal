using LIMSInfrastructure.Services.Notification;
using LIMSInfrastructure.Services.Property;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIMSWebApp.Hubs
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
			_parcelService.GetFilteredParcels(query);
			return Clients.All.SendAsync("UpdateParcels", _parcelService.GetAllParcels());
		}

		public async Task SellProduct(string query)
		{
			_parcelService.GetFilteredParcels(query);
			await Clients.All.SendAsync("UpdateParcels", _parcelService.GetAllParcels());
		}


		public void Notify()
		{
			// See constructor optional parameters to configure it according to your needs
			var listener = new SqlDependencyEx(_configuration.GetConnectionString("LIMSCoreDbConnection"), "LIMSCoreDb", "MpesaTransaction");

			

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
