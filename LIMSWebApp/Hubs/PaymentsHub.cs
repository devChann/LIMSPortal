using LIMSInfrastructure.Services.Property;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIMSWebApp.Hubs
{
    public class PaymentsHub: Hub
    {
		private readonly ParcelService _parcelService;

		public PaymentsHub(ParcelService parcelService)
		{
			_parcelService = parcelService;
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
	}
}
