using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LIMS.Core.Entities;

namespace LIMS.Infrastructure.Services.Properties
{
	public interface IParcelService
	{
		Task AddParcel(Parcel parcel);
		Task UpdateParcel(string number);
		Task DeleteParcel(string parcelId);
		Task<IEnumerable<Parcel>> GetParcels();
		IEnumerable<Parcel> GetParcelbyFilter(string filter);
		Task<Parcel> GetParcel(Guid? id);		
		Task<Parcel> GetParcelById(int parcelId);
		Task<Owner> GetPartyById(string partyId);		
		Task<IEnumerable<Parcel>> GetParcelsByOwner(Guid? ownerId);
		
	}
}
