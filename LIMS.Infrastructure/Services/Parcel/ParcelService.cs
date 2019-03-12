using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIMS.Core.Entities;
using LIMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LIMS.Infrastructure.Services.Property
{
	public class ParcelService : IParcelService
	{
		private readonly LIMSCoreDbContext _context;

		public ParcelService(LIMSCoreDbContext context)
		{
			_context = context;
		}
		public Task AddParcel(Parcel parcel)
		{
			throw new NotImplementedException();
		}

		public Task DeleteParcel(string parcelNumber)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Parcel> GetAllParcels()
		{
			throw new NotImplementedException();
		}

		public Parcel GetParcelByNumber(string parcelNumber)
		{
			return _context.Parcel
				.Include(i => i.Administration)
				.Include(i => i.LandUse)
				.Include(i => i.Registration)
				.Include(i => i.Restriction.Charge)
				.Include(i => i.Restriction.Mortgage)
				.Include(i => i.SpatialUnit)
				.Include(i => i.Tenure)
				.Include(p => p.Invoices)
				.Include(i => i.Valuation)
				.Include(i => i.Owner)
				.Where(a => a.ParcelNum == parcelNumber).SingleOrDefault();
		}

		public IEnumerable<Parcel> GetFilteredParcels(string searchQuery)
		{
			throw new NotImplementedException();
		}

		public Task UpdateParcel(string number)
		{
			throw new NotImplementedException();
		}

		public Owner GetParcelOwnerByUsername(string name)
		{
			throw new NotImplementedException();
		}

		public Owner GetParcelOwnerByIdNumber(string id)
		{
			throw new NotImplementedException();
		}

		public Parcel GetParcelById(int id)
		{
			throw new NotImplementedException();
		}

		public void ChangeOwner (Parcel parcel, Owner owner)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Parcel> GetParcelsByOwner(string id)
		{
			throw new NotImplementedException();
		}
	}
}
