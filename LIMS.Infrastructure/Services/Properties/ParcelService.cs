using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIMS.Core.Entities;
using LIMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LIMS.Infrastructure.Services.Properties
{
	public class ParcelService : IParcelService
	{
		private readonly LIMSCoreDbContext _context;

		public ParcelService(LIMSCoreDbContext context)
		{
			_context = context;
		}

		public Task DeleteParcel(string parcelNumber)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Parcel> GetParcelbyFilter(string filter)
		{
			throw new NotImplementedException();
		}

		public Task<Parcel> GetParcelById(int parcelId)
		{
			throw new NotImplementedException();
		}

		public Task<Parcel> GetParcelByNumber(string parcelnumber)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Parcel> GetParcels()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Parcel> GetParcelsByOwner(string parcelnumber)
		{
			throw new NotImplementedException();
		}

		public Task<Owner> GetPartyById(string partyId)
		{
			throw new NotImplementedException();
		}

		public Task RegisterParcel(Parcel parcel)
		{
			throw new NotImplementedException();
		}

		public Task UpdateParcel(string number)
		{
			throw new NotImplementedException();
		}
	}
}
