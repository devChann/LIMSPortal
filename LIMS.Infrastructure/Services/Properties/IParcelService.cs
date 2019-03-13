using System.Collections.Generic;
using System.Threading.Tasks;
using LIMS.Core.Entities;

namespace LIMS.Infrastructure.Services.Properties
{
	public interface IParcelService
	{
		Task RegisterParcel(Parcel parcel);
		Task UpdateParcel(string number);
		Task DeleteParcel(string parcelNumber);
		IEnumerable<Parcel> GetParcels();
		IEnumerable<Parcel> GetParcelbyFilter(string filter);
		Task<Parcel> GetParcelByNumber(string parcelnumber);
		Task<Parcel> GetParcelById(int parcelId);
		Task<Owner> GetPartyById(string partyId);		
		IEnumerable<Parcel> GetParcelsByOwner(string parcelnumber);
		
	}
}
