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

		public Task DeleteParcel(string parcelId)
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

		public async Task<Parcel> GetParcel(Guid? id)
		{
			var parcel = await _context.Parcel
				.Include(p => p.Administration)
				.Include(p => p.LandUse)
				.Include(p => p.Owner)
				.Include(p => p.OwnershipRight)
				.Include(p => p.Rate)
				.Include(p => p.Registration)
				.Include(p => p.Responsibility)
				.Include(p => p.Restriction)
				.Include(p => p.SpatialUnit)
				.Include(p => p.Tenure)
				.Include(p => p.Valuation)
				.FirstOrDefaultAsync(m => m.ParcelId == id);

			return parcel;
		}

		public async Task<IEnumerable<Parcel>> GetParcels()
		{
			var parcels = await _context.Parcel
				.Include(p => p.Administration)
				.Include(p => p.LandUse)
				.Include(p => p.Owner)
				.Include(p => p.OwnershipRight)
				.Include(p => p.Rate)
				.Include(p => p.Registration)
				.Include(p => p.Responsibility)
				.Include(p => p.Restriction)
				.Include(p => p.SpatialUnit)
				.Include(p => p.Tenure)
				.Include(p => p.Valuation).ToListAsync();

			return parcels;
		}

		public async Task<IEnumerable<Parcel>> GetParcelsByOwner(Guid? ownerId)
		{
			var parcel = await _context.Parcel
				.Include(p => p.Administration)
				.Include(p => p.LandUse)
				.Include(p => p.Owner)
				.Include(p => p.OwnershipRight)
				.Include(p => p.Rate)
				.Include(p => p.Registration)
				.Include(p => p.Responsibility)
				.Include(p => p.Restriction)
				.Include(p => p.SpatialUnit)
				.Include(p => p.Tenure)
				.Include(p => p.Valuation)
				.Where(m => m.OwnerId == ownerId)
				.ToListAsync();

			return parcel;
		}

		public Task<Owner> GetPartyById(string partyId)
		{
			throw new NotImplementedException();
		}

		public Task AddParcel(Parcel parcel)
		{
			throw new NotImplementedException();
		}

		public Task UpdateParcel(string number)
		{
			throw new NotImplementedException();
		}
	}
}
